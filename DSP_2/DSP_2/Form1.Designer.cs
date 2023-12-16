namespace DSP_2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.a_tb = new System.Windows.Forms.TextBox();
            this.f_tb = new System.Windows.Forms.TextBox();
            this.N_tb = new System.Windows.Forms.TextBox();
            this.fft_cb = new System.Windows.Forms.CheckBox();
            this.signal_cb = new System.Windows.Forms.ComboBox();
            this.generate_btn = new System.Windows.Forms.Button();
            this.lpf_btn = new System.Windows.Forms.Button();
            this.hpf_btn = new System.Windows.Forms.Button();
            this.bpf_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lpf_tb = new System.Windows.Forms.TextBox();
            this.hpf_tb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.a2_tb = new System.Windows.Forms.TextBox();
            this.f2_tb = new System.Windows.Forms.TextBox();
            this.original_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.a_spectrum = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ph_spectrum = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label5 = new System.Windows.Forms.Label();
            this.phase_tb = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.original_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_spectrum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ph_spectrum)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "A:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "f:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "N:";
            // 
            // a_tb
            // 
            this.a_tb.Location = new System.Drawing.Point(42, 6);
            this.a_tb.Margin = new System.Windows.Forms.Padding(2);
            this.a_tb.Name = "a_tb";
            this.a_tb.Size = new System.Drawing.Size(91, 26);
            this.a_tb.TabIndex = 3;
            this.a_tb.Text = "0,5";
            this.a_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.a_tb_KeyPress);
            // 
            // f_tb
            // 
            this.f_tb.Location = new System.Drawing.Point(42, 71);
            this.f_tb.Margin = new System.Windows.Forms.Padding(2);
            this.f_tb.Name = "f_tb";
            this.f_tb.Size = new System.Drawing.Size(91, 26);
            this.f_tb.TabIndex = 4;
            this.f_tb.Text = "20";
            this.f_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.f_tb_KeyPress);
            // 
            // N_tb
            // 
            this.N_tb.Location = new System.Drawing.Point(42, 38);
            this.N_tb.Margin = new System.Windows.Forms.Padding(2);
            this.N_tb.Name = "N_tb";
            this.N_tb.Size = new System.Drawing.Size(91, 26);
            this.N_tb.TabIndex = 5;
            this.N_tb.Text = "512";
            this.N_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.N_tb_KeyPress);
            // 
            // fft_cb
            // 
            this.fft_cb.AutoSize = true;
            this.fft_cb.Checked = true;
            this.fft_cb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fft_cb.Location = new System.Drawing.Point(11, 154);
            this.fft_cb.Margin = new System.Windows.Forms.Padding(2);
            this.fft_cb.Name = "fft_cb";
            this.fft_cb.Size = new System.Drawing.Size(50, 24);
            this.fft_cb.TabIndex = 6;
            this.fft_cb.Text = "FFT";
            this.fft_cb.UseVisualStyleBackColor = true;
            this.fft_cb.CheckedChanged += new System.EventHandler(this.fft_cb_CheckedChanged);
            // 
            // signal_cb
            // 
            this.signal_cb.FormattingEnabled = true;
            this.signal_cb.Items.AddRange(new object[] {
            "Sine",
            "Square",
            "Triangle",
            "Saw",
            "Noise",
            "Polyharmonic"});
            this.signal_cb.Location = new System.Drawing.Point(160, 5);
            this.signal_cb.Margin = new System.Windows.Forms.Padding(2);
            this.signal_cb.Name = "signal_cb";
            this.signal_cb.Size = new System.Drawing.Size(130, 28);
            this.signal_cb.TabIndex = 7;
            this.signal_cb.SelectedIndexChanged += new System.EventHandler(this.signal_cb_SelectedIndexChanged);
            // 
            // generate_btn
            // 
            this.generate_btn.Location = new System.Drawing.Point(15, 185);
            this.generate_btn.Margin = new System.Windows.Forms.Padding(2);
            this.generate_btn.Name = "generate_btn";
            this.generate_btn.Size = new System.Drawing.Size(128, 33);
            this.generate_btn.TabIndex = 8;
            this.generate_btn.Text = "Generate";
            this.generate_btn.UseVisualStyleBackColor = true;
            this.generate_btn.Click += new System.EventHandler(this.generate_btn_Click);
            // 
            // lpf_btn
            // 
            this.lpf_btn.Location = new System.Drawing.Point(15, 272);
            this.lpf_btn.Margin = new System.Windows.Forms.Padding(2);
            this.lpf_btn.Name = "lpf_btn";
            this.lpf_btn.Size = new System.Drawing.Size(128, 33);
            this.lpf_btn.TabIndex = 9;
            this.lpf_btn.Text = "Low-Pass filter";
            this.lpf_btn.UseVisualStyleBackColor = true;
            this.lpf_btn.Click += new System.EventHandler(this.lpf_btn_Click);
            // 
            // hpf_btn
            // 
            this.hpf_btn.Location = new System.Drawing.Point(15, 316);
            this.hpf_btn.Margin = new System.Windows.Forms.Padding(2);
            this.hpf_btn.Name = "hpf_btn";
            this.hpf_btn.Size = new System.Drawing.Size(128, 33);
            this.hpf_btn.TabIndex = 10;
            this.hpf_btn.Text = "High-Pass filter";
            this.hpf_btn.UseVisualStyleBackColor = true;
            this.hpf_btn.Click += new System.EventHandler(this.hpf_btn_Click);
            // 
            // bpf_btn
            // 
            this.bpf_btn.Location = new System.Drawing.Point(15, 363);
            this.bpf_btn.Margin = new System.Windows.Forms.Padding(2);
            this.bpf_btn.Name = "bpf_btn";
            this.bpf_btn.Size = new System.Drawing.Size(145, 33);
            this.bpf_btn.TabIndex = 11;
            this.bpf_btn.Text = "Brand-Pass filter";
            this.bpf_btn.UseVisualStyleBackColor = true;
            this.bpf_btn.Click += new System.EventHandler(this.bpf_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 244);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Cutoff frequency:";
            // 
            // lpf_tb
            // 
            this.lpf_tb.Location = new System.Drawing.Point(160, 276);
            this.lpf_tb.Margin = new System.Windows.Forms.Padding(2);
            this.lpf_tb.Name = "lpf_tb";
            this.lpf_tb.Size = new System.Drawing.Size(91, 26);
            this.lpf_tb.TabIndex = 13;
            this.lpf_tb.Text = "5";
            // 
            // hpf_tb
            // 
            this.hpf_tb.Location = new System.Drawing.Point(160, 319);
            this.hpf_tb.Margin = new System.Windows.Forms.Padding(2);
            this.hpf_tb.Name = "hpf_tb";
            this.hpf_tb.Size = new System.Drawing.Size(91, 26);
            this.hpf_tb.TabIndex = 14;
            this.hpf_tb.Text = "10";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(168, 45);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "A:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(176, 78);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "f:";
            // 
            // a2_tb
            // 
            this.a2_tb.Location = new System.Drawing.Point(199, 41);
            this.a2_tb.Margin = new System.Windows.Forms.Padding(2);
            this.a2_tb.Name = "a2_tb";
            this.a2_tb.Size = new System.Drawing.Size(91, 26);
            this.a2_tb.TabIndex = 18;
            this.a2_tb.Text = "0,5";
            // 
            // f2_tb
            // 
            this.f2_tb.Location = new System.Drawing.Point(199, 74);
            this.f2_tb.Margin = new System.Windows.Forms.Padding(2);
            this.f2_tb.Name = "f2_tb";
            this.f2_tb.Size = new System.Drawing.Size(91, 26);
            this.f2_tb.TabIndex = 19;
            this.f2_tb.Text = "40";
            // 
            // original_chart
            // 
            this.original_chart.Location = new System.Drawing.Point(298, 5);
            this.original_chart.Margin = new System.Windows.Forms.Padding(2);
            this.original_chart.Name = "original_chart";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series5.LegendText = "Original";
            series5.MarkerBorderColor = System.Drawing.Color.White;
            series5.Name = "Sg";
            series5.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.LegendText = "Reconstructed";
            series6.Name = "Gs";
            series6.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.original_chart.Series.Add(series5);
            this.original_chart.Series.Add(series6);
            this.original_chart.Size = new System.Drawing.Size(877, 247);
            this.original_chart.TabIndex = 20;
            // 
            // a_spectrum
            // 
            this.a_spectrum.Location = new System.Drawing.Point(298, 256);
            this.a_spectrum.Margin = new System.Windows.Forms.Padding(2);
            this.a_spectrum.Name = "a_spectrum";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series7.Name = "Amplitudes";
            series7.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.a_spectrum.Series.Add(series7);
            this.a_spectrum.Size = new System.Drawing.Size(437, 247);
            this.a_spectrum.TabIndex = 22;
            this.a_spectrum.Text = "chart1";
            // 
            // ph_spectrum
            // 
            this.ph_spectrum.Location = new System.Drawing.Point(738, 256);
            this.ph_spectrum.Margin = new System.Windows.Forms.Padding(2);
            this.ph_spectrum.Name = "ph_spectrum";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series8.Name = "Phases";
            series8.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.ph_spectrum.Series.Add(series8);
            this.ph_spectrum.Size = new System.Drawing.Size(437, 247);
            this.ph_spectrum.TabIndex = 23;
            this.ph_spectrum.Text = "chart2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "ph:";
            // 
            // phase_tb
            // 
            this.phase_tb.Location = new System.Drawing.Point(42, 102);
            this.phase_tb.Name = "phase_tb";
            this.phase_tb.Size = new System.Drawing.Size(91, 26);
            this.phase_tb.TabIndex = 25;
            this.phase_tb.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 514);
            this.Controls.Add(this.phase_tb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ph_spectrum);
            this.Controls.Add(this.a_spectrum);
            this.Controls.Add(this.original_chart);
            this.Controls.Add(this.f2_tb);
            this.Controls.Add(this.a2_tb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.hpf_tb);
            this.Controls.Add(this.lpf_tb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bpf_btn);
            this.Controls.Add(this.hpf_btn);
            this.Controls.Add(this.lpf_btn);
            this.Controls.Add(this.generate_btn);
            this.Controls.Add(this.signal_cb);
            this.Controls.Add(this.fft_cb);
            this.Controls.Add(this.N_tb);
            this.Controls.Add(this.f_tb);
            this.Controls.Add(this.a_tb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "DSP_2";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.original_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_spectrum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ph_spectrum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox a_tb;
        private System.Windows.Forms.TextBox f_tb;
        private System.Windows.Forms.TextBox N_tb;
        private System.Windows.Forms.CheckBox fft_cb;
        private System.Windows.Forms.ComboBox signal_cb;
        private System.Windows.Forms.Button generate_btn;
        private System.Windows.Forms.Button lpf_btn;
        private System.Windows.Forms.Button hpf_btn;
        private System.Windows.Forms.Button bpf_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox lpf_tb;
        private System.Windows.Forms.TextBox hpf_tb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox a2_tb;
        private System.Windows.Forms.TextBox f2_tb;
        private System.Windows.Forms.DataVisualization.Charting.Chart original_chart;
        private System.Windows.Forms.DataVisualization.Charting.Chart a_spectrum;
        private System.Windows.Forms.DataVisualization.Charting.Chart ph_spectrum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox phase_tb;
    }
}

