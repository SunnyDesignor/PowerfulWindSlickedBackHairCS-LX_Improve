namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x0200000D RID: 13
	public partial class DogWalkF : global::System.Windows.Forms.Form
	{
		// Token: 0x0600003C RID: 60 RVA: 0x000057E4 File Offset: 0x000039E4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x0000581C File Offset: 0x00003A1C
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // DogWalkF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PowerfulWindSlickedBackHair.Properties.Resources.DogWalk1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(152, 126);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DogWalkF";
            this.ShowIcon = false;
            this.Text = "勾";
            this.ResumeLayout(false);

		}

		// Token: 0x04000034 RID: 52
		private global::System.ComponentModel.IContainer components = null;
	}
}
