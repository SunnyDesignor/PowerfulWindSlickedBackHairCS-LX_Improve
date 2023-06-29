using System.ComponentModel;
using System.Windows.Forms;

namespace PowerfulWindSlickedBackHair
{
	// Token: 0x02000002 RID: 2
	public partial class MainForm : System.Windows.Forms.Form
	{

        private IContainer components = null;

        private StatusStrip statusStrip1;

        private ToolStripStatusLabel toolStripStatusLabel1;

        private ToolStripStatusLabel frameLabel;

        private ListView threadsList;

        private ColumnHeader columnT;

        private ColumnHeader columnS;

        private NotifyIcon notifyIcon1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.frameLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.threadsList = new System.Windows.Forms.ListView();
            this.columnT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.frameLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 144);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(312, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 20);
            // 
            // frameLabel
            // 
            this.frameLabel.Name = "frameLabel";
            this.frameLabel.Size = new System.Drawing.Size(13, 20);
            this.frameLabel.Text = " ";
            // 
            // threadsList
            // 
            this.threadsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnT,
            this.columnS});
            this.threadsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.threadsList.HideSelection = false;
            this.threadsList.Location = new System.Drawing.Point(0, 0);
            this.threadsList.Name = "threadsList";
            this.threadsList.Size = new System.Drawing.Size(312, 144);
            this.threadsList.TabIndex = 2;
            this.threadsList.UseCompatibleStateImageBehavior = false;
            this.threadsList.View = System.Windows.Forms.View.Details;
            this.threadsList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.threadsList_MouseDown);
            this.threadsList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.threadsList_MouseUp);
            // 
            // columnT
            // 
            this.columnT.Text = "T";
            this.columnT.Width = 150;
            // 
            // columnS
            // 
            this.columnS.Text = "S";
            this.columnS.Width = 150;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 170);
            this.Controls.Add(this.threadsList);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Opacity = 0.8D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Console";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }

}
