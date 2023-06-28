namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x0200000E RID: 14
	public partial class ErrorF : global::System.Windows.Forms.Form
	{
		// Token: 0x06000041 RID: 65 RVA: 0x00005940 File Offset: 0x00003B40
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00005978 File Offset: 0x00003B78
		private void InitializeComponent()
		{
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::PowerfulWindSlickedBackHair.Properties.Resources.Error;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(-17, -36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(526, 218);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ErrorF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PowerfulWindSlickedBackHair.Properties.Resources.Error;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(488, 180);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Name = "ErrorF";
            this.ShowIcon = false;
            this.Text = "Error";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

		// Token: 0x04000035 RID: 53
		private global::System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
