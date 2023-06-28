namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x02000017 RID: 23
	public partial class RollingDogF : global::System.Windows.Forms.Form
	{
		// Token: 0x06000084 RID: 132 RVA: 0x0000794C File Offset: 0x00005B4C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00007984 File Offset: 0x00005B84
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // RollingDogF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(216)))), ((int)(((byte)(81)))));
            this.BackgroundImage = global::PowerfulWindSlickedBackHair.Properties.Resources.RollingDog;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(228, 188);
            this.DoubleBuffered = true;
            this.Name = "RollingDogF";
            this.ShowIcon = false;
            this.Text = "勾";
            this.ResumeLayout(false);

		}

		// Token: 0x0400006E RID: 110
		private global::System.ComponentModel.IContainer components = null;
	}
}
