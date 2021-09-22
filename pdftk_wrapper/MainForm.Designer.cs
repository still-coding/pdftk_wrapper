
namespace pdftk_wrapper
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fswMainDir = new System.IO.FileSystemWatcher();
            this.lvExplorer = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.tslMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tslDetails = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.fswMainDir)).BeginInit();
            this.ssMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // fswMainDir
            // 
            this.fswMainDir.EnableRaisingEvents = true;
            this.fswMainDir.SynchronizingObject = this;
            this.fswMainDir.Changed += new System.IO.FileSystemEventHandler(this.fswMainDir_Changed);
            this.fswMainDir.Deleted += new System.IO.FileSystemEventHandler(this.fswMainDir_Deleted);
            // 
            // lvExplorer
            // 
            this.lvExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvExplorer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvExplorer.HideSelection = false;
            this.lvExplorer.Location = new System.Drawing.Point(12, 12);
            this.lvExplorer.Name = "lvExplorer";
            this.lvExplorer.Size = new System.Drawing.Size(639, 404);
            this.lvExplorer.TabIndex = 0;
            this.lvExplorer.UseCompatibleStateImageBehavior = false;
            this.lvExplorer.View = System.Windows.Forms.View.Details;
            this.lvExplorer.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvExplorer_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Файлы";
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslMessage,
            this.tspbProgress,
            this.tslDetails});
            this.ssMain.Location = new System.Drawing.Point(0, 428);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(911, 22);
            this.ssMain.TabIndex = 1;
            this.ssMain.Text = "statusStrip1";
            // 
            // tslMessage
            // 
            this.tslMessage.Name = "tslMessage";
            this.tslMessage.Size = new System.Drawing.Size(118, 17);
            this.tslMessage.Text = "toolStripStatusLabel1";
            // 
            // tspbProgress
            // 
            this.tspbProgress.Name = "tspbProgress";
            this.tspbProgress.Size = new System.Drawing.Size(100, 16);
            // 
            // tslDetails
            // 
            this.tslDetails.Name = "tslDetails";
            this.tslDetails.Size = new System.Drawing.Size(118, 17);
            this.tslDetails.Text = "toolStripStatusLabel2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 450);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.lvExplorer);
            this.Name = "MainForm";
            this.Text = "Pdftk wrapper";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fswMainDir)).EndInit();
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.FileSystemWatcher fswMainDir;
        private System.Windows.Forms.ListView lvExplorer;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripStatusLabel tslMessage;
        private System.Windows.Forms.ToolStripProgressBar tspbProgress;
        private System.Windows.Forms.ToolStripStatusLabel tslDetails;
    }
}

