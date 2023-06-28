namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x02000013 RID: 19
	public partial class StaticPigeonF : global::System.Windows.Forms.Form
	{
		// Token: 0x06000067 RID: 103 RVA: 0x000069AC File Offset: 0x00004BAC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000069E4 File Offset: 0x00004BE4
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // StaticPigeonF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(216)))), ((int)(((byte)(81)))));
            this.BackgroundImage = global::PowerfulWindSlickedBackHair.Properties.Resources.GreyPigeon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(399, 346);
            this.DoubleBuffered = true;
            this.Name = "StaticPigeonF";
            this.ShowIcon = false;
            this.Text = "Up主";
            this.ResumeLayout(false);

		}

		// Token: 0x04000047 RID: 71
		private global::System.ComponentModel.IContainer components = null;
	}
}
