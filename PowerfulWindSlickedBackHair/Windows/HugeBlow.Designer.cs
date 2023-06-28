namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x02000014 RID: 20
	public partial class HugeBlow : global::System.Windows.Forms.Form
	{
		// Token: 0x0600006C RID: 108 RVA: 0x00006B30 File Offset: 0x00004D30
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00006B68 File Offset: 0x00004D68
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // HugeBlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PowerfulWindSlickedBackHair.Properties.Resources.HugeBlow1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1286, 724);
            this.DoubleBuffered = true;
            this.Name = "HugeBlow";
            this.ShowIcon = false;
            this.Text = "汽笛";
            this.Load += new System.EventHandler(this.HugeBlow_Load);
            this.ResumeLayout(false);

		}

		// Token: 0x0400004A RID: 74
		private global::System.ComponentModel.IContainer components = null;
	}
}
