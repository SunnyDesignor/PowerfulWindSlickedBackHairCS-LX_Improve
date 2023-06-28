namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x0200001B RID: 27
	public partial class YukiClapF : global::System.Windows.Forms.Form
	{
		// Token: 0x0600009F RID: 159 RVA: 0x000082B0 File Offset: 0x000064B0
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x000082E8 File Offset: 0x000064E8
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // YukiClapF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PowerfulWindSlickedBackHair.Properties.Resources.YukiClap;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(291, 302);
            this.DoubleBuffered = true;
            this.Name = "YukiClapF";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.ResumeLayout(false);

		}

		// Token: 0x04000089 RID: 137
		private global::System.ComponentModel.IContainer components = null;
	}
}
