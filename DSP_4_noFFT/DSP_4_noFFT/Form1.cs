using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;
using System.Data;
using System.Runtime.InteropServices;

namespace DSP_4_noFFT
{
    public partial class Form1 : Form
    {
        private Bitmap pic;
        private Bitmap fragment;
        //private bool isBothOpen = false;

        public Form1()
        {
            InitializeComponent();
            generate_btn.Enabled = false;
            types_cb.SelectedIndex = 0;
        }

        static double CalculateMean(float[,] matrix)
        {
            double mean = 0;

            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    mean += matrix[i, j];
                }
            }

            mean /= width * height;

            return mean;
        }

        static string CalculateCrossCorrelationCoefficient(Bitmap img, Bitmap fragment)
        {
            int width = Math.Min(img.Width, fragment.Width);
            int height = Math.Min(img.Height, fragment.Height);

            float[,] imgData = PicToFloat(img);
            float[,] fragmentData = PicToFloat(fragment);

            double meanImg = CalculateMean(imgData);
            double meanFragment = CalculateMean(fragmentData);

            double numerator = 0;
            double denominator_part1 = 0;
            double denominator_part2 = 0;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    numerator += (imgData[i, j] - meanImg) * (fragmentData[i, j] - meanFragment);
                    denominator_part1 += Math.Pow((imgData[i, j] - meanImg), 2);
                    denominator_part2 += Math.Pow((fragmentData[i, j] - meanFragment), 2);
                }
            }

            double denominator = Math.Sqrt(denominator_part1) * Math.Sqrt(denominator_part2);

            // Вычисляем коэффициент взаимной корреляции
            double correlationCoefficient = numerator / denominator;

            return "Correlation coefficient: " + correlationCoefficient.ToString("F3");
        }

        static Point FindBestMatch(float[,] picMatrix, float[,] fragmentMatrix, out Bitmap crossCorrelationImage)
        {
            int width = picMatrix.GetLength(0) - fragmentMatrix.GetLength(0) + 1;
            int height = picMatrix.GetLength(1) - fragmentMatrix.GetLength(1) + 1;

            float[,] crossCorrelationResult = new float[width, height];

            double bestCorrelation = double.MinValue;
            Point bestMatch = Point.Empty;

            // Проходим по всем возможным сдвигам
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    // Вычисляем взаимную корреляцию для текущего сдвига
                    float correlation = CalculateCorrelation(picMatrix, fragmentMatrix, i, j);
                    crossCorrelationResult[i, j] = correlation;

                    // Обновляем лучшее значение
                    if (correlation > bestCorrelation)
                    {
                        bestCorrelation = correlation;
                        bestMatch = new Point(i, j);
                    }
                }
            }

            crossCorrelationImage = GenerateResultPic(crossCorrelationResult);
            //crossCorrelationImage.Save("D:\\labs\\DSP\\DSP_4_noFFT\\img\\cci.jpg");

            return bestMatch;
        }

        static float CalculateCorrelation(float[,] largeImage, float[,] smallImage, int offsetX, int offsetY)
        {
            int width = smallImage.GetLength(0);
            int height = smallImage.GetLength(1);

            double sum = 0;
            double sumLarge = 0;
            double sumSmall = 0;

            // Вычисляем сумму произведений яркостей пикселей для вычисления корреляции
            /*
             Для вычисления взаимной корреляции необходимо умножить яркости соответствующих пикселей в двух изображениях 
             и просуммировать результаты для всех пикселей. 
             Это дает величину взаимной корреляции при заданном сдвиге (offsetX,offsetY).
             */
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    float largeBrightness = largeImage[i + offsetX, j + offsetY];
                    float smallBrightness = smallImage[i, j];

                    sum += largeBrightness * smallBrightness;
                    sumLarge += Math.Pow(largeBrightness, 2);
                    sumSmall += Math.Pow(smallBrightness, 2);
                }
            }

            // Защита от деления на ноль
            if (sumLarge == 0 || sumSmall == 0)
                return 0;

            // Делим для нормализации в пределах [-1; 1]
            return (float)(sum / (Math.Sqrt(sumLarge) * Math.Sqrt(sumSmall)));
        }

        static Bitmap MarkLocation(Bitmap image, Point location, int width, int height)
        {
            using (Graphics g = Graphics.FromImage(image))
            {
                using (Pen pen = new Pen(Color.Red, 1))
                {
                    g.DrawRectangle(pen, location.X, location.Y, width, height);
                }
            }

            return image;
            //image.Save("D:\\labs\\DSP\\DSP_4_noFFT\\img\\marked_result.jpg");
        }

        private void generate_btn_Click(object sender, EventArgs e)
        {
            switch (types_cb.SelectedIndex)
            {
                // Корреляция двух изображений
                case 0:

                    string ccCoefficient = CalculateCrossCorrelationCoefficient(pic, fragment);
                    ccc_lb.Text = ccCoefficient;

                    Bitmap grayscaleImageO = ConvertToGrayscale(pic);
                    Bitmap grayscaleImageF = ConvertToGrayscale(fragment);

                    float[,] picFloat = PicToFloat(grayscaleImageO);
                    float[,] fragmentFloat = PicToFloat(grayscaleImageF);

                    Bitmap crossCorrelationImage;

                    Point bestMatch = FindBestMatch(picFloat, fragmentFloat, out crossCorrelationImage);
         
                    Bitmap newPic = MarkLocation(pic, bestMatch, fragment.Width, fragment.Height);

                    //Bitmap crossCorrelationImage = new Bitmap("D:\\labs\\DSP\\DSP_4_noFFT\\img\\cci.jpg");
                    result_pb.Image = crossCorrelationImage;

                    //Bitmap newPic = new Bitmap("D:\\labs\\DSP\\DSP_4_noFFT\\img\\marked_result.jpg");
                    original_pb.Image = newPic;
                    break;

                // Автокорреляция
                case 1:
                    int width = pic.Width;
                    int height = pic.Height;

                    Bitmap grayscaleImage = ConvertToGrayscale(pic);

                    float[,] imageFloat = PicToFloat(grayscaleImage);

                    float[,] autocorrelationResult = CalculateAutocorrelation(imageFloat, width, height);
                    
                    Bitmap autocorrelationImage = GenerateResultPic(autocorrelationResult);
                    result_pb.Image = autocorrelationImage;
                break;
            }
        }

        static float[,] CalculateAutocorrelation(float[,] imageFloat, int width, int height)
        {
            float[,] autocorrelationResult = new float[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    // Область изображения сдвигается на (i, j)
                    float[,] shiftedImage = ShiftImage(imageFloat, i, j);

                    // Вычисление элементов произведения
                    float sum = 0;
                    for (int x = 0; x < width; x++)
                    {
                        for (int y = 0; y < height; y++)
                        {
                            // яркость оригинала * яркость сдвинутого изображения
                            sum += imageFloat[x, y] * shiftedImage[x, y];
                        }
                    }

                    autocorrelationResult[i, j] = sum;
                }
            }

            // можно делить на квадратный корень из произведения суммы квадратов яркостей пикселей, чтобы нормализовать

            return autocorrelationResult;
        }

        static float[,] PicToFloat(Bitmap img)
        {
            int width = img.Width;  
            int height = img.Height;

            float[,] imageFloat = new float[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    imageFloat[i, j] = img.GetPixel(i, j).GetBrightness();
                }
            }

            return imageFloat;
        }

        static void NormalizeTo255(float[,] array, int width, int height)
        {
            float max = float.MinValue;
            float min = float.MaxValue;

            // Находим минимальное и максимальное значения
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                    }

                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                    }
                }
            }

            // Нормализуем массив в диапазон [0, 255]
            float range = max - min;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    // Проверяем, чтобы избежать деления на ноль
                    if (range != 0)
                    {
                        array[i, j] = ((array[i, j] - min) / range) * 255;
                    }
                    else
                    {
                        // Если range = 0, значит, все значения массива одинаковы,
                        // просто устанавливаем их в середину диапазона [0, 255]
                        array[i, j] = 127.5f;
                    }
                }
            }
        }

        static Bitmap GenerateResultPic(float[,] autocorrelationMatrix)
        {
            int width = autocorrelationMatrix.GetLength(0);
            int height = autocorrelationMatrix.GetLength(1);

            Bitmap autocorrelationImage = new Bitmap(width, height);

            NormalizeTo255(autocorrelationMatrix, width, height);

            // Преобразование значений в диапазон от 0 до 255 для оттенков серого
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int value = (int)autocorrelationMatrix[i, j];
                    autocorrelationImage.SetPixel(i, j, Color.FromArgb(value, value, value));
                }
            }

            return autocorrelationImage;
        }

        static Bitmap ConvertToGrayscale(Bitmap colorImage)
        {
            int width = colorImage.Width;
            int height = colorImage.Height;
            Bitmap grayscaleImage = new Bitmap(width, height);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Color color = colorImage.GetPixel(i, j);
                    int grayValue = (int)(0.299 * color.R + 0.587 * color.G + 0.114 * color.B);
                    grayscaleImage.SetPixel(i, j, Color.FromArgb(grayValue, grayValue, grayValue));
                }
            }

            return grayscaleImage;
        }


        static float[,] ShiftImage(float[,] image, int shiftX, int shiftY)
        {
            int width = image.GetLength(0);
            int height = image.GetLength(1);

            float[,] shiftedImage = new float[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    int x = (i + shiftX) % width;
                    int y = (j + shiftY) % height;

                    shiftedImage[i, j] = image[x, y];
                }
            }

            return shiftedImage;
        }        
        
        private void pic_btn_Click(object sender, EventArgs e)
        {
            original_pb.Image = null;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pic = new Bitmap(openFileDialog.FileName);
                original_pb.Image = pic;
                /*if (fragment != null)
                {
                    isBothOpen = true;
                }*/
            }

            generate_btn.Enabled = true;

            /*if (pic != null && types_cb.SelectedIndex == 1)
            {
                generate_btn.Enabled = true;
            }
            else if (isBothOpen && types_cb.SelectedIndex == 0)
            {
                generate_btn.Enabled = true;
            }
            else
            {
                generate_btn.Enabled = false;
            }*/
        }

        private void fragment_btn_Click(object sender, EventArgs e)
        {
            fragment_pb.Image = null;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fragment = new Bitmap(openFileDialog.FileName);
                fragment_pb.Image = fragment;
                /*if (pic != null)
                {
                    isBothOpen = true;
                }*/
            }

            generate_btn.Enabled = true;

            /*if (pic != null && types_cb.SelectedIndex == 1)
            {
                generate_btn.Enabled = true;
            }

            else if (isBothOpen && types_cb.SelectedIndex == 0)
            {
                generate_btn.Enabled = true;
            }
            else
            {
                generate_btn.Enabled = false;
            }*/

        }

        private void types_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (types_cb.SelectedIndex == 1)
            {
                fragment_pb.Image = null;
                ccc_lb.Text = "";
            }
        }
    }
}
