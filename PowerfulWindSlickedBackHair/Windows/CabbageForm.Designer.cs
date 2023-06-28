namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x0200000C RID: 12
	public partial class CabbageForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000036 RID: 54 RVA: 0x000055B4 File Offset: 0x000037B4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000055EC File Offset: 0x000037EC
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // CabbageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PowerfulWindSlickedBackHair.Properties.Resources.CabbageFull;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(306, 207);
            this.DoubleBuffered = true;
            this.Name = "CabbageForm";
            this.ShowIcon = false;
            this.Text = "不明绿色圆球";
            this.Click += new System.EventHandler(this.CabbageForm_Click);
            this.ResumeLayout(false);

		}

		// Token: 0x04000031 RID: 49
		private global::System.ComponentModel.IContainer components = null;
	}
}
