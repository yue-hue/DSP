using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using MathNet.Numerics.IntegralTransforms;
using System.Windows.Forms.DataVisualization.Charting;
using MathNet.Numerics;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;

namespace DSP_2
{
    public partial class Form1 : Form
    {
        double[] signal;
        Series original_series, reconstructed_series, amplitudes_series, phases_series;
        bool isDrawn = false;

        public Form1()
        {
            InitializeComponent();
            signal_cb.SelectedIndex = 0;
            lpf_btn.Enabled = false;
            hpf_btn.Enabled = false;
            bpf_btn.Enabled = false;

            label6.Visible = false;
            label7.Visible = false;
            a2_tb.Visible = false;
            f2_tb.Visible = false;

            original_chart.ChartAreas.Add(new ChartArea());
            original_series = original_chart.Series[0];
            reconstructed_series = original_chart.Series[1];

            original_chart.ChartAreas[0].AxisX = new Axis { Minimum = 0, Maximum = 512, IntervalOffset = 0, Interval = 32 };
            original_chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            original_chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;            

            original_series.BorderDashStyle = ChartDashStyle.Solid;
            original_series.Color = Color.LightSkyBlue;
            original_series.BorderWidth = 3;

            reconstructed_series.BorderDashStyle = ChartDashStyle.Dot;
            reconstructed_series.Color = Color.Black;
            reconstructed_series.BorderWidth = 1;

            a_spectrum.ChartAreas.Add(new ChartArea());
            amplitudes_series = a_spectrum.Series[0];
            amplitudes_series.Color = Color.LightSkyBlue;

            a_spectrum.ChartAreas[0].AxisX = new Axis { Minimum = 0, Maximum = 512, IntervalOffset = 0, Interval = 64 };
            a_spectrum.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            a_spectrum.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            ph_spectrum.ChartAreas.Add(new ChartArea());
            phases_series = ph_spectrum.Series[0];
            phases_series.Color = Color.LightSkyBlue;

            ph_spectrum.ChartAreas[0].AxisX = new Axis { Minimum = 0, Maximum = 512, IntervalOffset = 0, Interval = 64 };
            ph_spectrum.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            ph_spectrum.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
        }

        public Complex[] FFT(Complex[] buffer)
        {
            int N = buffer.Length;
            if (N <= 1)
                return buffer;

            Complex[] even = new Complex[N / 2];
            Complex[] odd = new Complex[N / 2];
            for (int i = 0; i < N / 2; i++)
            {
                even[i] = buffer[i * 2];
                odd[i] = buffer[i * 2 + 1];
            }

            even = FFT(even);
            odd = FFT(odd);

            Complex[] result = new Complex[N];
            for (int i = 0; i < N / 2; i++)
            {
                double angle = -2 * Math.PI * i / N;
                Complex e = new Complex(Math.Cos(angle), Math.Sin(angle)) * odd[i];
                result[i] = even[i] + e;
                result[i + N / 2] = even[i] - e;
            }
            return result;
        }

        private Complex[] FastFourierTransformation(double[] signal)
        {
            int N = signal.Length;
            Complex[] buffer = new Complex[N];
            for (int i = 0; i < N; i++)
                buffer[i] = new Complex(signal[i], 0);

            return FFT(buffer);
        }

        public Complex[] IFFT(Complex[] buffer)
        {
            int N = buffer.Length;
            Complex[] conjugateInput = new Complex[N];
            for (int i = 0; i < N; i++)
                conjugateInput[i] = Complex.Conjugate(buffer[i]);

            Complex[] fftResult = FFT(conjugateInput);

            Complex[] conjugateResult = new Complex[N];
            for (int i = 0; i < N; i++)
                conjugateResult[i] = Complex.Conjugate(fftResult[i]);

            for (int i = 0; i < N; i++)
                conjugateResult[i] /= N;

            return conjugateResult;
        }

        private double[] InverseFastFourierTransform(double[] amplitudeSpectrum, double[] phaseSpectrum)
        {
            int N = amplitudeSpectrum.Length;
            Complex[] buffer = new Complex[N];
            for (int i = 0; i < N; i++)
                buffer[i] = new Complex(amplitudeSpectrum[i] * Math.Cos(phaseSpectrum[i]), amplitudeSpectrum[i] * Math.Sin(phaseSpectrum[i]));

            Complex[] ifftResult = IFFT(buffer);

            double[] signal = new double[N];
            for (int i = 0; i < N; i++)
                signal[i] = (ifftResult[i].Real);

            return signal;
        }

        private Complex[] FourierTransformation(double[] signal)
        {
            int N = signal.Length;
            Complex[] spectrum = new Complex[N];
            for (int i = 0; i < N; i++)
            {
                spectrum[i] = new Complex(0, 0);
                for (int j = 0; j < N; j++)
                {
                    double angle = -2 * Math.PI * i * j / N;
                    Complex e = new Complex(Math.Cos(angle), Math.Sin(angle));
                    spectrum[i] += signal[j] * e;
                }
            }
            return spectrum;
        }

        private double[] InverseFourierTransform(double[] amplitudeSpectrum, double[] phaseSpectrum)
        {
            int N = amplitudeSpectrum.Length;
            double[] signal = new double[N];
            for (int i = 0; i < N; i++)
            {
                Complex sum = new Complex(0, 0);
                for (int j = 0; j < N; j++)
                {
                    double angle = 2 * Math.PI * j * i / N;
                    Complex e = new Complex(Math.Cos(angle), Math.Sin(angle));
                    Complex spectrum_j = new Complex(amplitudeSpectrum[j] * Math.Cos(phaseSpectrum[j]), amplitudeSpectrum[j] * Math.Sin(phaseSpectrum[j]));
                    sum += spectrum_j * e;
                }
                signal[i] = (sum.Real / N);
            }
            return signal;
        }

        private void generate_btn_Click(object sender, EventArgs e)
        {
            lpf_btn.Enabled = true;
            hpf_btn.Enabled = true;
            bpf_btn.Enabled = true;

            double amplitude = Convert.ToDouble(a_tb.Text);
            int sampleRate = Convert.ToInt32(N_tb.Text);
            double frequency = Convert.ToDouble(f_tb.Text);
            double phase0 = Convert.ToDouble(phase_tb.Text);
            frequency /= sampleRate;

            int numSamples = sampleRate;    

            signal = new double[numSamples];

            Random random = new Random();
            for (int i = 0; i < numSamples; i++)
            {
                switch (signal_cb.SelectedIndex)
                {
                    // Синусоида
                    case 0:
                        signal[i] = Sine(amplitude, frequency, phase0, i);
                        break;

                    // Импульс
                    case 1:
                        signal[i] = Square(amplitude, frequency, i);
                        break;

                    // Треугольный
                    case 2:
                        signal[i] = Triangle(amplitude, frequency, phase0, i);
                        break;

                    // Пилообразный
                    case 3:
                        signal[i] = Saw(amplitude, frequency, phase0, i);
                        break;

                    // Шум
                    case 4:
                        signal[i] = amplitude * 2 * (random.NextDouble() - 1);
                        break;

                    // Полигармонический (?)
                    case 5:                       
                        double[] amplitudes = new double[] { amplitude, Convert.ToDouble(a2_tb.Text) };
                        double[] frequencies = new double[] { frequency, Convert.ToDouble(f2_tb.Text) };

                        double sampleValue = 0.0;

                        for (int j = 0; j < amplitudes.Length; j++)
                        {
                            sampleValue += amplitudes[j] * Math.Sin(2 * Math.PI * frequencies[j] * i / sampleRate);
                        }

                        signal[i] = sampleValue;
                        break;
                }
            }

            Complex[] spectrum = null;
            // БПФ
            if (fft_cb.Checked)
            {
                spectrum = FastFourierTransformation(signal);
            }
            // ДПФ
            else
            {
                spectrum = FourierTransformation(signal);
            }

            double[] amplitudeSpectrum = spectrum.Select(x => x.Magnitude).ToArray();
            double[] normalizedAmplitudeSpectrum = amplitudeSpectrum.Select(x => (x / amplitudeSpectrum.Max()) * amplitude).ToArray();

            double[] phaseSpectrum = spectrum.Select(x => x.Phase).ToArray();

            double[] reconstructedSignal = null;
            // БПФ
            if (fft_cb.Checked)
            {
                reconstructedSignal = InverseFastFourierTransform(amplitudeSpectrum, phaseSpectrum);
            }
            // ДПФ
            else
            {
                reconstructedSignal = InverseFourierTransform(amplitudeSpectrum, phaseSpectrum);
            }

            DrawSignals(original_chart, original_series, signal);
            DrawSignals(original_chart, reconstructed_series, reconstructedSignal);

            DrawSpectrums(a_spectrum, amplitudes_series, normalizedAmplitudeSpectrum);
            DrawSpectrums(ph_spectrum, phases_series, phaseSpectrum);

            isDrawn = true;
            SaveWave(signal, sampleRate, "test.wav");
            SaveWave(reconstructedSignal, sampleRate, "test1.wav");            
        }

        public void DrawSignals(Chart chart, Series series, double[] signal)
        {
            if (isDrawn)
            {
                series.Points.Clear();
            }

            for (int i = 0; i < signal.Length; i++)
            {
                series.Points.AddY(signal[i]);
            }
            Controls.Add(chart);
        }

        public void DrawSpectrums(Chart chart, Series series, double[] spectrum)
        {
            if (isDrawn)
            {
                chart.Series[0].Points.Clear();
            }

            for (int i = 0; i < spectrum.Length; i++)
            {
                series.Points.AddY(spectrum[i]);
            }
            Controls.Add(chart);
        }

        private double[] LPF(double[] signal, int sampleRate)
        {
            double cutoffFrequency = Convert.ToDouble(lpf_tb.Text);

            double RC = 1.0 / (2.0 * Math.PI * cutoffFrequency);  // Постоянная времени
            double dt = 1.0 / sampleRate; // Интервал дискретизации
            double filtrationCoeff = dt / (RC + dt); 

            double[] filteredSignal = new double[signal.Length];
            double previousValue = 0.0;

            for (int i = 0; i < signal.Length; i++)
            {
                double currentValue = signal[i];
                double filteredValue = filtrationCoeff * currentValue + (1.0 - filtrationCoeff) * previousValue;
                filteredSignal[i] = filteredValue;
                previousValue = filteredValue;
            }
            return filteredSignal;
        }

        private void lpf_btn_Click(object sender, EventArgs e)
        {
            int sampleRate = Convert.ToInt32(N_tb.Text);
            double[] filteredSignal = new double[signal.Length];
            filteredSignal = LPF(signal, sampleRate);

            DrawSignals(a_spectrum, amplitudes_series, filteredSignal);
            SaveWave(filteredSignal, sampleRate, "filtered.wav");
        }

        private double[] HPF(double[] signal, int sampleRate)
        {
            double cutoffFrequency = Convert.ToDouble(hpf_tb.Text);            

            double RC = 1.0 / (2.0 * Math.PI * cutoffFrequency); // Постоянная времени
            double dt = 1.0 / sampleRate; // Интервал дискретизации
            double filtrationCoeff = RC / (RC + dt);

            double[] filteredSignal = new double[signal.Length];
            double previousValue = 0.0;
            double previousFilteredValue = 0.0;

            for (int i = 0; i < signal.Length; i++)
            {
                double currentValue = signal[i];
                double filteredValue = filtrationCoeff * (previousFilteredValue + currentValue - previousValue);
                filteredSignal[i] = filteredValue;
                previousValue = currentValue;
                previousFilteredValue = filteredValue;
            }
            return filteredSignal;
        }
        private void hpf_btn_Click(object sender, EventArgs e)
        {
            int sampleRate = Convert.ToInt32(N_tb.Text);
            double[] filteredSignal = new double[signal.Length];
            filteredSignal = HPF(signal, sampleRate);

            DrawSignals(a_spectrum, amplitudes_series, filteredSignal);
            SaveWave(filteredSignal, sampleRate, "filtered.wav");
        }

        private void bpf_btn_Click(object sender, EventArgs e)
        {
            int sampleRate = Convert.ToInt32(N_tb.Text);

            double[] filteredSignal = new double[signal.Length];

            filteredSignal = LPF(HPF(signal, sampleRate), sampleRate);

            DrawSignals(a_spectrum, amplitudes_series, filteredSignal);
            SaveWave(filteredSignal, sampleRate, "filtered.wav");
        }

        public static void SaveWave(double[] data, int sampleRate, string filename)
        {
            Stream file = File.Create(filename);
            BinaryWriter writer = new BinaryWriter(file);
            short frameSize = (short)(16 / 8); // Количество байт в блоке (16 бит делим на 8).
            writer.Write(0x46464952); // Заголовок "RIFF".
            writer.Write(36 + data.Length * frameSize); // Размер файла от данной точки.
            writer.Write(0x45564157); // Заголовок "WAVE".
            writer.Write(0x20746D66); // Заголовок "frm ".
            writer.Write(16); // Размер блока формата.
            writer.Write((short)1); // Формат 1 значит PCM.
            writer.Write((short)1); // Количество дорожек.
            writer.Write(sampleRate); // Частота дискретизации.
            writer.Write(sampleRate * frameSize); // Байтрейт (Как битрейт только в байтах).
            writer.Write(frameSize); // Количество байт в блоке.
            writer.Write((short)16); // разрядность.
            writer.Write(0x61746164); // Заголовок "DATA".
            writer.Write(data.Length * frameSize); // Размер данных в байтах.
            for (int index = 0; index < data.Length; index++)
            { // Начинаем записывать данные из нашего массива.
                foreach (byte element in BitConverter.GetBytes(data[index]))
                { // Разбиваем каждый элемент нашего массива на байты.
                    file.WriteByte(element); // И записываем их в поток.
                }
            }
            file.Close();
        }

        public static double Sine(double amplitude, double frequency, double phase, int index)
        {
            return amplitude * Math.Sin(2 * Math.PI * frequency * index) + phase;
        }

        private static double Square(double amplitude, double frequency, int index)
        {
            //if (amplitude * Math.Sign(Math.Sin(2 * Math.PI * frequency * index)) < 0.3) return amplitude ;
            //else return -amplitude;
            if (((2 * Math.PI * frequency * index) % (2 * Math.PI)) / (2 * Math.PI) <= 0.1) return amplitude;
            else return -amplitude;

        }

        private static double Triangle(double amplitude, double frequency, double phase, int index)
        {
            return (2.0 * Math.Abs(2.0 * (index * frequency - Math.Floor(index * frequency + 0.5))) - 1.0) * amplitude + phase;
        }

        private static double Saw(double amplitude, double frequency, double phase, int index)
        {
            return (2.0 * (index * frequency - Math.Floor(index * frequency)) - 1.0) * amplitude + phase;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {
                SoundPlayer Simple = new SoundPlayer(@"D:\labs\DSP\DSP_2\DSP_2\bin\Debug\test.wav");
                Simple.Play();
            }
            if (e.KeyCode == Keys.W)
            {
                SoundPlayer Simple = new SoundPlayer(@"D:\labs\DSP\DSP_2\DSP_2\bin\Debug\test1.wav");
                Simple.Play();
            }
            if (e.KeyCode == Keys.F)
            {
                SoundPlayer Simple = new SoundPlayer(@"D:\labs\DSP\DSP_2\DSP_2\bin\Debug\filtered.wav");
                Simple.Play();
            }
        }

        private void signal_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (signal_cb.SelectedIndex == 5)
            {
                label6.Visible = true;
                label7.Visible = true;
                a2_tb.Visible = true;
                f2_tb.Visible = true;
            }
            else
            {
                label6.Visible = false;
                label7.Visible = false;
                a2_tb.Visible = false;
                f2_tb.Visible = false;
            }
        }

        private void fft_cb_CheckedChanged(object sender, EventArgs e)
        {
            //generate_btn.PerformClick();
        }

        private void a_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(e.KeyChar == 44))
            {
                e.Handled = true;
            }
        }

        private void N_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void f_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(e.KeyChar == 44))
            {
                e.Handled = true;
            }
        }
    }
}
