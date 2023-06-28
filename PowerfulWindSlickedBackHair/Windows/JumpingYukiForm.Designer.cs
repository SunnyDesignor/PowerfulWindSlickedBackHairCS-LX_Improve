namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x02000015 RID: 21
	public partial class JumpingYukiForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000075 RID: 117 RVA: 0x00007368 File Offset: 0x00005568
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000073A0 File Offset: 0x000055A0
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JumpingYukiForm));
            this.SuspendLayout();
            // 
            // JumpingYukiForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PowerfulWindSlickedBackHair.Properties.Resources.JumpDown;
            this.DoubleBuffered = true;
            this.Name = "JumpingYukiForm";
            this.ShowIcon = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.JumpingYukiForm_Load);
            this.ResumeLayout(false);

		}

		// Token: 0x0400005B RID: 91
		private global::System.ComponentModel.IContainer components = null;
	}
}
