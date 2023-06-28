namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x02000016 RID: 22
	public partial class PigeonPeekF : global::System.Windows.Forms.Form
	{
		// Token: 0x0600007D RID: 125 RVA: 0x000076E8 File Offset: 0x000058E8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00007720 File Offset: 0x00005920
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // PigeonPeekF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PowerfulWindSlickedBackHair.Properties.Resources.PigeonPeek;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(274, 242);
            this.Name = "PigeonPeekF";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.ResumeLayout(false);

		}

		// Token: 0x04000063 RID: 99
		private global::System.ComponentModel.IContainer components = null;
	}
}
