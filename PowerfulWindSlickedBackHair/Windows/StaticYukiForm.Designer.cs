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
			base.SuspendLayout();
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			base.ClientSize = new global::System.Drawing.Size(240, 578);
			this.DoubleBuffered = true;
			base.Name = "StaticYukiForm";
			base.ShowIcon = false;
			this.Text = "Error";
			base.ResumeLayout(false);
		}

		// Token: 0x04000071 RID: 113
		private global::System.ComponentModel.IContainer components = null;
	}
}
