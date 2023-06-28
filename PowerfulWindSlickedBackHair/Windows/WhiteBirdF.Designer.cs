namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x0200001A RID: 26
	public partial class WhiteBirdF : global::System.Windows.Forms.Form
	{
		// Token: 0x06000097 RID: 151 RVA: 0x00007FF4 File Offset: 0x000061F4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000802C File Offset: 0x0000622C
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // WhiteBirdF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.BackgroundImage = global::PowerfulWindSlickedBackHair.Properties.Resources.WhiteBird1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(267, 406);
            this.DoubleBuffered = true;
            this.Name = "WhiteBirdF";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.WhiteBirdF_Load);
            this.ResumeLayout(false);

		}

		// Token: 0x04000081 RID: 129
		private global::System.ComponentModel.IContainer components = null;
	}
}
