namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x0200000A RID: 10
	public partial class BirdWaveF : global::System.Windows.Forms.Form
	{
		// Token: 0x0600002C RID: 44 RVA: 0x000052E0 File Offset: 0x000034E0
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00005318 File Offset: 0x00003518
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // BirdWaveF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PowerfulWindSlickedBackHair.Properties.Resources.BlackBirdWave1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(172, 159);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BirdWaveF";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);

		}

		// Token: 0x0400002C RID: 44
		private global::System.ComponentModel.IContainer components = null;
	}
}
