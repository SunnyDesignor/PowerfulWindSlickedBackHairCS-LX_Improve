namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x02000011 RID: 17
	public partial class FloatYukiWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x0600005F RID: 95 RVA: 0x000064EC File Offset: 0x000046EC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00006524 File Offset: 0x00004724
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(185, 178);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "FloatYukiWindow";
			this.Text = "FloatYukiWindow";
			base.Load += new global::System.EventHandler(this.FloatYukiWindow_Load);
			base.Paint += new global::System.Windows.Forms.PaintEventHandler(this.FloatYukiWindow_Paint);
			base.ResumeLayout(false);
		}

		// Token: 0x04000040 RID: 64
		private global::System.ComponentModel.IContainer components = null;
	}
}
