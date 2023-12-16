namespace DSP_3
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
            this.original_pb = new System.Windows.Forms.PictureBox();
            this.created_pb = new System.Windows.Forms.PictureBox();
            this.types_cb = new System.Windows.Forms.ComboBox();
            this.generate_btn = new System.Windows.Forms.Button();
            this.kernel_tb = new System.Windows.Forms.TextBox();
            this.kernel_label = new System.Windows.Forms.Label();
            this.open_img_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.original_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.created_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // original_pb
            // 
            this.original_pb.Location = new System.Drawing.Point(17, 131);
            this.original_pb.Margin = new System.Windows.Forms.Padding(4);
            this.original_pb.Name = "original_pb";
            this.original_pb.Size = new System.Drawing.Size(496, 375);
            this.original_pb.TabIndex = 0;
            this.original_pb.TabStop = false;
            // 
            // created_pb
            // 
            this.created_pb.Location = new System.Drawing.Point(531, 131);
            this.created_pb.Margin = new System.Windows.Forms.Padding(4);
            this.created_pb.Name = "created_pb";
            this.created_pb.Size = new System.Drawing.Size(496, 375);
            this.created_pb.TabIndex = 1;
            this.created_pb.TabStop = false;
            // 
            // types_cb
            // 
            this.types_cb.FormattingEnabled = true;
            this.types_cb.Items.AddRange(new object[] {
            "Box blur",
            "Gaussian blur",
            "Median filter",
            "Sobel operator"});
            this.types_cb.Location = new System.Drawing.Point(135, 17);
            this.types_cb.Margin = new System.Windows.Forms.Padding(4);
            this.types_cb.Name = "types_cb";
            this.types_cb.Size = new System.Drawing.Size(269, 29);
            this.types_cb.TabIndex = 2;
            this.types_cb.SelectedIndexChanged += new System.EventHandler(this.types_cb_SelectedIndexChanged);
            // 
            // generate_btn
            // 
            this.generate_btn.Location = new System.Drawing.Point(135, 56);
            this.generate_btn.Margin = new System.Windows.Forms.Padding(4);
            this.generate_btn.Name = "generate_btn";
            this.generate_btn.Size = new System.Drawing.Size(118, 30);
            this.generate_btn.TabIndex = 3;
            this.generate_btn.Text = "Generate";
            this.generate_btn.UseVisualStyleBackColor = true;
            this.generate_btn.Click += new System.EventHandler(this.generate_btn_Click);
            // 
            // kernel_tb
            // 
            this.kernel_tb.Location = new System.Drawing.Point(531, 21);
            this.kernel_tb.Name = "kernel_tb";
            this.kernel_tb.Size = new System.Drawing.Size(100, 28);
            this.kernel_tb.TabIndex = 4;
            this.kernel_tb.Text = "5";
            // 
            // kernel_label
            // 
            this.kernel_label.AutoSize = true;
            this.kernel_label.Location = new System.Drawing.Point(427, 24);
            this.kernel_label.Name = "kernel_label";
            this.kernel_label.Size = new System.Drawing.Size(98, 21);
            this.kernel_label.TabIndex = 5;
            this.kernel_label.Text = "Kernel size:";
            // 
            // open_img_btn
            // 
            this.open_img_btn.Location = new System.Drawing.Point(17, 29);
            this.open_img_btn.Name = "open_img_btn";
            this.open_img_btn.Size = new System.Drawing.Size(92, 55);
            this.open_img_btn.TabIndex = 8;
            this.open_img_btn.Text = "Open image";
            this.open_img_btn.UseVisualStyleBackColor = true;
            this.open_img_btn.Click += new System.EventHandler(this.open_img_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 536);
            this.Controls.Add(this.open_img_btn);
            this.Controls.Add(this.kernel_label);
            this.Controls.Add(this.kernel_tb);
            this.Controls.Add(this.generate_btn);
            this.Controls.Add(this.types_cb);
            this.Controls.Add(this.created_pb);
            this.Controls.Add(this.original_pb);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "DSP_3";
            ((System.ComponentModel.ISupportInitialize)(this.original_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.created_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox original_pb;
        private System.Windows.Forms.PictureBox created_pb;
        private System.Windows.Forms.ComboBox types_cb;
        private System.Windows.Forms.Button generate_btn;
        private System.Windows.Forms.TextBox kernel_tb;
        private System.Windows.Forms.Label kernel_label;
        private System.Windows.Forms.Button open_img_btn;
    }
}

