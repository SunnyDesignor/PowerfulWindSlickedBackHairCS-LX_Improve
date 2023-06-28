namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x0200000B RID: 11
	public partial class BWYukiForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000031 RID: 49 RVA: 0x0000543C File Offset: 0x0000363C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00005474 File Offset: 0x00003674
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // BWYukiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PowerfulWindSlickedBackHair.Properties.Resources.BWYuki;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(254, 595);
            this.DoubleBuffered = true;
            this.Name = "BWYukiForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);

		}

		// Token: 0x0400002D RID: 45
		private global::System.ComponentModel.IContainer components = null;
	}
}
