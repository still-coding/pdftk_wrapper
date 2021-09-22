
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
            this.tcFileTypes = new System.Windows.Forms.TabControl();
            this.tpDoc = new System.Windows.Forms.TabPage();
            this.btnDoc2Pdf = new System.Windows.Forms.Button();
            this.tpPdf = new System.Windows.Forms.TabPage();
            this.gbxRemove = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txbRemoveRange = new System.Windows.Forms.TextBox();
            this.lblRemoveRange = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fswMainDir)).BeginInit();
            this.ssMain.SuspendLayout();
            this.tcFileTypes.SuspendLayout();
            this.tpDoc.SuspendLayout();
            this.tpPdf.SuspendLayout();
            this.gbxRemove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fswMainDir
            // 
            this.fswMainDir.EnableRaisingEvents = true;
            this.fswMainDir.SynchronizingObject = this;
            this.fswMainDir.Changed += new System.IO.FileSystemEventHandler(this.fswMainDir_Changed_Deleted);
            this.fswMainDir.Deleted += new System.IO.FileSystemEventHandler(this.fswMainDir_Deleted);
            this.fswMainDir.Renamed += new System.IO.RenamedEventHandler(this.fswMainDir_Changed_Deleted);
            // 
            // lvExplorer
            // 
            this.lvExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvExplorer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvExplorer.HideSelection = false;
            this.lvExplorer.Location = new System.Drawing.Point(4, 3);
            this.lvExplorer.Name = "lvExplorer";
            this.lvExplorer.Size = new System.Drawing.Size(553, 407);
            this.lvExplorer.TabIndex = 0;
            this.lvExplorer.UseCompatibleStateImageBehavior = false;
            this.lvExplorer.View = System.Windows.Forms.View.Details;
            this.lvExplorer.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvExplorer_ColumnClick);
            this.lvExplorer.SelectedIndexChanged += new System.EventHandler(this.lvExplorer_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Файлы (клик тут обращает выделение)";
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
            this.tspbProgress.Step = 1;
            this.tspbProgress.Visible = false;
            // 
            // tslDetails
            // 
            this.tslDetails.Name = "tslDetails";
            this.tslDetails.Size = new System.Drawing.Size(118, 17);
            this.tslDetails.Text = "toolStripStatusLabel2";
            this.tslDetails.Visible = false;
            // 
            // tcFileTypes
            // 
            this.tcFileTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcFileTypes.Controls.Add(this.tpDoc);
            this.tcFileTypes.Controls.Add(this.tpPdf);
            this.tcFileTypes.Location = new System.Drawing.Point(3, 3);
            this.tcFileTypes.Name = "tcFileTypes";
            this.tcFileTypes.SelectedIndex = 0;
            this.tcFileTypes.Size = new System.Drawing.Size(321, 407);
            this.tcFileTypes.TabIndex = 2;
            this.tcFileTypes.Selected += new System.Windows.Forms.TabControlEventHandler(this.tcFileTypes_Selected);
            // 
            // tpDoc
            // 
            this.tpDoc.Controls.Add(this.btnDoc2Pdf);
            this.tpDoc.Location = new System.Drawing.Point(4, 24);
            this.tpDoc.Name = "tpDoc";
            this.tpDoc.Padding = new System.Windows.Forms.Padding(3);
            this.tpDoc.Size = new System.Drawing.Size(313, 379);
            this.tpDoc.TabIndex = 0;
            this.tpDoc.Text = "DOC";
            this.tpDoc.UseVisualStyleBackColor = true;
            // 
            // btnDoc2Pdf
            // 
            this.btnDoc2Pdf.Enabled = false;
            this.btnDoc2Pdf.Location = new System.Drawing.Point(36, 28);
            this.btnDoc2Pdf.Name = "btnDoc2Pdf";
            this.btnDoc2Pdf.Size = new System.Drawing.Size(153, 23);
            this.btnDoc2Pdf.TabIndex = 0;
            this.btnDoc2Pdf.Text = "Конвертировать в PDF";
            this.btnDoc2Pdf.UseVisualStyleBackColor = true;
            this.btnDoc2Pdf.Click += new System.EventHandler(this.btnDoc2Pdf_Click);
            // 
            // tpPdf
            // 
            this.tpPdf.Controls.Add(this.textBox1);
            this.tpPdf.Controls.Add(this.gbxRemove);
            this.tpPdf.Location = new System.Drawing.Point(4, 24);
            this.tpPdf.Name = "tpPdf";
            this.tpPdf.Padding = new System.Windows.Forms.Padding(3);
            this.tpPdf.Size = new System.Drawing.Size(313, 379);
            this.tpPdf.TabIndex = 1;
            this.tpPdf.Text = "PDF";
            this.tpPdf.UseVisualStyleBackColor = true;
            // 
            // gbxRemove
            // 
            this.gbxRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxRemove.Controls.Add(this.btnRemove);
            this.gbxRemove.Controls.Add(this.txbRemoveRange);
            this.gbxRemove.Controls.Add(this.lblRemoveRange);
            this.gbxRemove.Location = new System.Drawing.Point(3, 6);
            this.gbxRemove.Name = "gbxRemove";
            this.gbxRemove.Size = new System.Drawing.Size(301, 100);
            this.gbxRemove.TabIndex = 3;
            this.gbxRemove.TabStop = false;
            this.gbxRemove.Text = "Удаление страниц";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(185, 58);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 0;
            this.btnRemove.Text = "Удалить";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txbRemoveRange
            // 
            this.txbRemoveRange.Location = new System.Drawing.Point(172, 22);
            this.txbRemoveRange.Name = "txbRemoveRange";
            this.txbRemoveRange.Size = new System.Drawing.Size(100, 23);
            this.txbRemoveRange.TabIndex = 2;
            // 
            // lblRemoveRange
            // 
            this.lblRemoveRange.AutoSize = true;
            this.lblRemoveRange.Location = new System.Drawing.Point(26, 25);
            this.lblRemoveRange.Name = "lblRemoveRange";
            this.lblRemoveRange.Size = new System.Drawing.Size(140, 15);
            this.lblRemoveRange.TabIndex = 1;
            this.lblRemoveRange.Text = "с - по (или одно число):";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Location = new System.Drawing.Point(8, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvExplorer);
            this.splitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tcFileTypes);
            this.splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Size = new System.Drawing.Size(891, 413);
            this.splitContainer1.SplitterDistance = 560;
            this.splitContainer1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(47, 150);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.ssMain);
            this.Name = "MainForm";
            this.Text = "Pdftk wrapper";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fswMainDir)).EndInit();
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.tcFileTypes.ResumeLayout(false);
            this.tpDoc.ResumeLayout(false);
            this.tpPdf.ResumeLayout(false);
            this.tpPdf.PerformLayout();
            this.gbxRemove.ResumeLayout(false);
            this.gbxRemove.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl tcFileTypes;
        private System.Windows.Forms.TabPage tpDoc;
        private System.Windows.Forms.Button btnDoc2Pdf;
        private System.Windows.Forms.TabPage tpPdf;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbxRemove;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txbRemoveRange;
        private System.Windows.Forms.Label lblRemoveRange;
        private System.Windows.Forms.TextBox textBox1;
    }
}

