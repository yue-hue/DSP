namespace DSP_4_noFFT
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
            this.pic_btn = new System.Windows.Forms.Button();
            this.fragment_btn = new System.Windows.Forms.Button();
            this.original_pb = new System.Windows.Forms.PictureBox();
            this.fragment_pb = new System.Windows.Forms.PictureBox();
            this.generate_btn = new System.Windows.Forms.Button();
            this.types_cb = new System.Windows.Forms.ComboBox();
            this.result_pb = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ccc_lb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.original_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fragment_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.result_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_btn
            // 
            this.pic_btn.Location = new System.Drawing.Point(260, 13);
            this.pic_btn.Margin = new System.Windows.Forms.Padding(4);
            this.pic_btn.Name = "pic_btn";
            this.pic_btn.Size = new System.Drawing.Size(156, 30);
            this.pic_btn.TabIndex = 0;
            this.pic_btn.Text = "Open image";
            this.pic_btn.UseVisualStyleBackColor = true;
            this.pic_btn.Click += new System.EventHandler(this.pic_btn_Click);
            // 
            // fragment_btn
            // 
            this.fragment_btn.Location = new System.Drawing.Point(372, 419);
            this.fragment_btn.Name = "fragment_btn";
            this.fragment_btn.Size = new System.Drawing.Size(156, 30);
            this.fragment_btn.TabIndex = 1;
            this.fragment_btn.Text = "Open fragment";
            this.fragment_btn.UseVisualStyleBackColor = true;
            this.fragment_btn.Click += new System.EventHandler(this.fragment_btn_Click);
            // 
            // original_pb
            // 
            this.original_pb.Location = new System.Drawing.Point(14, 50);
            this.original_pb.Name = "original_pb";
            this.original_pb.Size = new System.Drawing.Size(415, 363);
            this.original_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.original_pb.TabIndex = 2;
            this.original_pb.TabStop = false;
            // 
            // fragment_pb
            // 
            this.fragment_pb.Location = new System.Drawing.Point(14, 419);
            this.fragment_pb.Name = "fragment_pb";
            this.fragment_pb.Size = new System.Drawing.Size(352, 301);
            this.fragment_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fragment_pb.TabIndex = 3;
            this.fragment_pb.TabStop = false;
            // 
            // generate_btn
            // 
            this.generate_btn.Location = new System.Drawing.Point(703, 419);
            this.generate_btn.Name = "generate_btn";
            this.generate_btn.Size = new System.Drawing.Size(156, 58);
            this.generate_btn.TabIndex = 4;
            this.generate_btn.Text = "Generate";
            this.generate_btn.UseVisualStyleBackColor = true;
            this.generate_btn.Click += new System.EventHandler(this.generate_btn_Click);
            // 
            // types_cb
            // 
            this.types_cb.FormattingEnabled = true;
            this.types_cb.Items.AddRange(new object[] {
            "Cross correlation",
            "Autocorrelation"});
            this.types_cb.Location = new System.Drawing.Point(14, 12);
            this.types_cb.Name = "types_cb";
            this.types_cb.Size = new System.Drawing.Size(225, 29);
            this.types_cb.TabIndex = 5;
            this.types_cb.SelectedIndexChanged += new System.EventHandler(this.types_cb_SelectedIndexChanged);
            // 
            // result_pb
            // 
            this.result_pb.Location = new System.Drawing.Point(444, 50);
            this.result_pb.Name = "result_pb";
            this.result_pb.Size = new System.Drawing.Size(415, 363);
            this.result_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.result_pb.TabIndex = 6;
            this.result_pb.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(444, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Correlation function:";
            // 
            // ccc_lb
            // 
            this.ccc_lb.AutoSize = true;
            this.ccc_lb.Location = new System.Drawing.Point(372, 456);
            this.ccc_lb.Name = "ccc_lb";
            this.ccc_lb.Size = new System.Drawing.Size(0, 21);
            this.ccc_lb.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 730);
            this.Controls.Add(this.ccc_lb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.result_pb);
            this.Controls.Add(this.types_cb);
            this.Controls.Add(this.generate_btn);
            this.Controls.Add(this.fragment_pb);
            this.Controls.Add(this.original_pb);
            this.Controls.Add(this.fragment_btn);
            this.Controls.Add(this.pic_btn);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "DSP_4";
            ((System.ComponentModel.ISupportInitialize)(this.original_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fragment_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.result_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button pic_btn;
        private System.Windows.Forms.Button fragment_btn;
        private System.Windows.Forms.PictureBox original_pb;
        private System.Windows.Forms.PictureBox fragment_pb;
        private System.Windows.Forms.Button generate_btn;
        private System.Windows.Forms.ComboBox types_cb;
        private System.Windows.Forms.PictureBox result_pb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ccc_lb;
    }
}

