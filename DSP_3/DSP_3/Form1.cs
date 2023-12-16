using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DSP_3
{
    public partial class Form1 : Form
    {
        private Bitmap image;
        private bool isImgOpen = false;
        public Form1()
        {
            InitializeComponent();
            types_cb.SelectedIndex = 0;
            generate_btn.Enabled = false;
        }

        public void BoxBlur(Bitmap image, int kernelSize)
        {
            int width = image.Width;
            int height = image.Height;
            Bitmap outputImage = new Bitmap(width, height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int red = 0;
                    int green = 0;
                    int blue = 0;
                    int count = 0;

                    for (int i = -kernelSize / 2; i <= kernelSize / 2; i++)
                    {
                        for (int j = -kernelSize / 2; j <= kernelSize / 2; j++)
                        {
                            int newX = x + i;
                            int newY = y + j;

                            if (newX >= 0 && newX < width && newY >= 0 && newY < height)
                            {
                                Color pixel = image.GetPixel(newX, newY);
                                red += pixel.R;
                                green += pixel.G;
                                blue += pixel.B;
                                count++;
                            }
                        }
                    }

                    red /= count;
                    green /= count;
                    blue /= count;

                    Color newColor = Color.FromArgb(red, green, blue);
                    outputImage.SetPixel(x, y, newColor);
                }
            }

            created_pb.Image = outputImage;
        }

        public void GaussianBlur(Bitmap image, int kernelSize)
        {
            int width = image.Width;
            int height = image.Height;
            Bitmap outputImage = new Bitmap(width, height);

            double[,] kernel = GenerateGaussianKernel(kernelSize);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    double red = 0.0;
                    double green = 0.0;
                    double blue = 0.0;

                    for (int i = -kernelSize / 2; i <= kernelSize / 2; i++)
                    {
                        for (int j = -kernelSize / 2; j <= kernelSize / 2; j++)
                        {
                            int newX = Math.Min(Math.Max(x + i, 0), width - 1);//x + i;
                            int newY = Math.Min(Math.Max(y + i, 0), width - 1);

                            /*if (newX < 0)
                            {
                                newX = - x - i;
                            }
                            if (newX >= width)
                            {
                                newX = width - newX - 1;
                            }

                            if (newY < 0)
                            {
                                newY = - y - i;
                            }
                            if (newY >= height)
                            {
                                newY = 2 * width - newY - 1;
                            }*/

                            if (newX >= 0 && newX < width && newY >= 0 && newY < height)
                            {
                                Color pixel = image.GetPixel(newX, newY);
                                double kernelValue = kernel[i + kernelSize / 2, j + kernelSize / 2];

                                red += pixel.R * kernelValue;
                                green += pixel.G * kernelValue;
                                blue += pixel.B * kernelValue;
                            }
                        }
                    }

                    Color newColor = Color.FromArgb((int)red, (int)green, (int)blue);
                    outputImage.SetPixel(x, y, newColor);
                }
            }

            created_pb.Image = outputImage;
        } 

        static double[,] GenerateGaussianKernel(int size)
        {
            double[,] kernel = new double[size, size];
            double sum = 0.0;
            double sigma = size / 3.0;

            int halfSize = size / 2;

            for (int x = -halfSize; x <= halfSize; x++)
            {
                for (int y = -halfSize; y <= halfSize; y++)
                {
                    double exponent = -(x * x + y * y) / (2 * sigma * sigma);
                    double value = Math.Exp(exponent) / (2 * Math.PI * sigma * sigma);
                    kernel[x + halfSize, y + halfSize] = value;
                    sum += value;
                }
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    kernel[i, j] /= sum;
                }
            }

            return kernel;
        }

        public void MedianFilter(Bitmap image, int kernelSize)
        {
            int width = image.Width;
            int height = image.Height;
            Bitmap outputImage = new Bitmap(width, height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int[] values = new int[kernelSize * kernelSize];
                    int index = 0;

                    for (int i = -kernelSize / 2; i <= kernelSize / 2; i++)
                    {
                        for (int j = -kernelSize / 2; j <= kernelSize / 2; j++)
                        {
                            int newX = x + i;
                            int newY = y + j;

                            if (newX >= 0 && newX < width && newY >= 0 && newY < height)
                            {
                                Color pixel = image.GetPixel(newX, newY);
                                values[index] = (int)(0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B);
                                index++;
                            }
                        }
                    }

                    Array.Sort(values);

                    int medianValue = values[kernelSize * kernelSize / 2];

                    Color newColor = Color.FromArgb(medianValue, medianValue, medianValue);
                    outputImage.SetPixel(x, y, newColor);
                }
            }
            created_pb.Image = outputImage;
        }

        public void SobelOperator(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;
            Bitmap outputImage = new Bitmap(width, height);

            int[,] sobelX = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] sobelY = { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };

            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    int sumX = 0;
                    int sumY = 0;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            Color pixel = image.GetPixel(x + i, y + j);
                            int grayValue = (int)(0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B);

                            sumX += grayValue * sobelX[i + 1, j + 1];
                            sumY += grayValue * sobelY[i + 1, j + 1];
                        }
                    }

                    int gradient = (int)Math.Sqrt(sumX * sumX + sumY * sumY);

                    gradient = Math.Min(255, Math.Max(0, gradient));

                    Color newColor = Color.FromArgb(gradient, gradient, gradient);
                    outputImage.SetPixel(x, y, newColor);
                }
            }
            created_pb.Image = outputImage;
        }


    private void generate_btn_Click(object sender, EventArgs e)
        {
            //Bitmap image = new Bitmap("Image1.jpg");
            int kernelSize = Convert.ToInt32(kernel_tb.Text);

            switch (types_cb.SelectedIndex)
            {
                // Обычное размытие
                case 0:                    
                    BoxBlur(image, kernelSize);
                    break;
                // Размытие по Гауссу
                case 1:
                    GaussianBlur(image, kernelSize);
                    break;
                // Медианный фильтр
                case 2:
                    MedianFilter(image, kernelSize);
                    break;
                // Оператор Собеля
                case 3:
                    SobelOperator(image);
                    break;
            }
        }

        private void types_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (types_cb.SelectedIndex)
            {
                // Обычное размытие
                case 0:
                    created_pb.Image = null;
                    kernel_label.Visible = true;
                    kernel_tb.Visible = true;
                    break;
                // Размытие по Гауссу
                case 1:
                    created_pb.Image = null;
                    kernel_label.Visible = true;
                    kernel_tb.Visible = true;
                    break;
                // Медианный фильтр
                case 2:
                    created_pb.Image = null;
                    kernel_label.Visible = true;
                    kernel_tb.Visible = true;
                    break;
                // Оператор Собеля
                case 3:
                    created_pb.Image = null;
                    kernel_label.Visible = false;
                    kernel_tb.Visible = false;
                    break;
            }

        }

        private void open_img_btn_Click(object sender, EventArgs e)
        {
            original_pb.Image = null;
            created_pb.Image = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(openFileDialog.FileName);
                original_pb.Image = image;
                isImgOpen = true;
            }
            if (isImgOpen)
            {
                generate_btn.Enabled = true;
            }
        }
    }
}
