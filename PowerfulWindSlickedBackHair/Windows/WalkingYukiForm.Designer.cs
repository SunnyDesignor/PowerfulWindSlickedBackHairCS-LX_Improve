namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x02000019 RID: 25
	public partial class WalkingYukiForm : global::System.Windows.Forms.Form
	{
		// Token: 0x0600008F RID: 143 RVA: 0x00007D1C File Offset: 0x00005F1C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00007D54 File Offset: 0x00005F54
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // WalkingYukiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PowerfulWindSlickedBackHair.Properties.Resources.Walk1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(279, 569);
            this.Name = "WalkingYukiForm";
            this.ShowIcon = false;
            this.Text = "正在踱步...";
            this.ResumeLayout(false);

		}

		// Token: 0x0400007C RID: 124
		private global::System.ComponentModel.IContainer components = null;
	}
}
