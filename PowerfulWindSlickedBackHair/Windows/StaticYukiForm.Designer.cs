namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x02000018 RID: 24
	public partial class StaticYukiForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000089 RID: 137 RVA: 0x00007ADC File Offset: 0x00005CDC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00007B14 File Offset: 0x00005D14
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // StaticYukiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(240, 578);
            this.DoubleBuffered = true;
            this.Name = "StaticYukiForm";
            this.Opacity = 0.75D;
            this.ShowIcon = false;
            this.Text = "Error";
            this.ResumeLayout(false);

		}

		// Token: 0x04000071 RID: 113
		private global::System.ComponentModel.IContainer components = null;
	}
}
