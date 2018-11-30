namespace projeA
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pBox_urunler = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_urunler)).BeginInit();
            this.SuspendLayout();
            // 
            // pBox_urunler
            // 
            this.pBox_urunler.Location = new System.Drawing.Point(12, 12);
            this.pBox_urunler.Name = "pBox_urunler";
            this.pBox_urunler.Size = new System.Drawing.Size(408, 417);
            this.pBox_urunler.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBox_urunler.TabIndex = 0;
            this.pBox_urunler.TabStop = false;
            this.pBox_urunler.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pBox_urunler_MouseClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(631, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 523);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pBox_urunler);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBox_urunler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pBox_urunler;
        private System.Windows.Forms.Button button1;
    }
}

