namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x02000010 RID: 16
	public partial class FloatWindowHelperF : global::System.Windows.Forms.Form
	{
		// Token: 0x06000050 RID: 80 RVA: 0x00005F84 File Offset: 0x00004184
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00005FBC File Offset: 0x000041BC
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(282, 64);
			base.Name = "FloatWindowHelperF";
			this.Text = "FloatWindowHelperF";
			base.WindowState = global::System.Windows.Forms.FormWindowState.Minimized;
			base.ResumeLayout(false);
		}

		// Token: 0x0400003E RID: 62
		private global::System.ComponentModel.IContainer components = null;
	}
}
