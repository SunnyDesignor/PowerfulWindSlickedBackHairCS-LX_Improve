namespace PowerfulWindSlickedBackHair.Windows
{
	// Token: 0x02000008 RID: 8
	public partial class BackgroundForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000020 RID: 32 RVA: 0x00004BD0 File Offset: 0x00002DD0
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00004C08 File Offset: 0x00002E08
		private void InitializeComponent()
		{
            this.text = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // text
            // 
            this.text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text.ForeColor = System.Drawing.Color.White;
            this.text.Location = new System.Drawing.Point(0, 0);
            this.text.Margin = new System.Windows.Forms.Padding(0);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(1120, 576);
            this.text.Style = Sunny.UI.UIStyle.Custom;
            this.text.TabIndex = 0;
            this.text.Text = "外出た瞬間";
            this.text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BackgroundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(1120, 576);
            this.Controls.Add(this.text);
            this.Name = "BackgroundForm";
            this.ShowIcon = false;
            this.Text = "背景呐";
            this.ResumeLayout(false);

		}

		// Token: 0x0400001C RID: 28
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400001D RID: 29
		private global::Sunny.UI.UILabel text;
	}
}
