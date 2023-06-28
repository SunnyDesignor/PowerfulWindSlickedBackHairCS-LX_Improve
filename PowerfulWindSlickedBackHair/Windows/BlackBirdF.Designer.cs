namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x02000009 RID: 9
	public partial class BlackBirdF : global::System.Windows.Forms.Form
	{
		// Token: 0x06000026 RID: 38 RVA: 0x00004FE4 File Offset: 0x000031E4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000501C File Offset: 0x0000321C
		private void InitializeComponent()
		{
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Yellow;
            this.pictureBox1.BackgroundImage = global::PowerfulWindSlickedBackHair.Properties.Resources.BlackBird2;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(262, 204);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // BlackBirdF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(262, 204);
            this.Controls.Add(this.pictureBox1);
            this.Name = "BlackBirdF";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}

		// Token: 0x04000025 RID: 37
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000026 RID: 38
		private global::System.Windows.Forms.PictureBox pictureBox1;
	}
}
