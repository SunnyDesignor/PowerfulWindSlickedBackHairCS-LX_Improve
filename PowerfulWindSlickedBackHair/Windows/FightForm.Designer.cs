namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x0200000F RID: 15
	public partial class FightForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000047 RID: 71 RVA: 0x00005B3C File Offset: 0x00003D3C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00005B74 File Offset: 0x00003D74
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // FightForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PowerfulWindSlickedBackHair.Properties.Resources.Fight1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1189, 668);
            this.DoubleBuffered = true;
            this.Name = "FightForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

		}

		// Token: 0x04000039 RID: 57
		private global::System.ComponentModel.IContainer components = null;
	}
}
