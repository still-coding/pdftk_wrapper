
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.fswMainDir = new System.IO.FileSystemWatcher();
            this.lvExplorer = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.tslMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tslDetails = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssbOpenDone = new System.Windows.Forms.ToolStripSplitButton();
            this.tssbOpenWorking = new System.Windows.Forms.ToolStripSplitButton();
            this.tcFileTypes = new System.Windows.Forms.TabControl();
            this.tpDoc = new System.Windows.Forms.TabPage();
            this.btnDoc2Pdf = new System.Windows.Forms.Button();
            this.tpPdf = new System.Windows.Forms.TabPage();
            this.gbxCat = new System.Windows.Forms.GroupBox();
            this.btnCat = new System.Windows.Forms.Button();
            this.btnClearFiles = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnRemoveFiles = new System.Windows.Forms.Button();
            this.btnAddFiles = new System.Windows.Forms.Button();
            this.lsbFilesToCat = new System.Windows.Forms.ListBox();
            this.gbxRemove = new System.Windows.Forms.GroupBox();
            this.btnRemovePages = new System.Windows.Forms.Button();
            this.txbRemoveRange = new System.Windows.Forms.TextBox();
            this.lblRemoveRange = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.fswMainDir)).BeginInit();
            this.ssMain.SuspendLayout();
            this.tcFileTypes.SuspendLayout();
            this.tpDoc.SuspendLayout();
            this.tpPdf.SuspendLayout();
            this.gbxCat.SuspendLayout();
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
            this.tslDetails,
            this.tssbOpenDone,
            this.tssbOpenWorking});
            this.ssMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
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
            // tssbOpenDone
            // 
            this.tssbOpenDone.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tssbOpenDone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssbOpenDone.DropDownButtonWidth = 0;
            this.tssbOpenDone.Image = ((System.Drawing.Image)(resources.GetObject("tssbOpenDone.Image")));
            this.tssbOpenDone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbOpenDone.Name = "tssbOpenDone";
            this.tssbOpenDone.Size = new System.Drawing.Size(113, 20);
            this.tssbOpenDone.Text = "Каталог \"готовые\"";
            this.tssbOpenDone.ButtonClick += new System.EventHandler(this.tssbOpenDone_ButtonClick);
            // 
            // tssbOpenWorking
            // 
            this.tssbOpenWorking.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tssbOpenWorking.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssbOpenWorking.DropDownButtonWidth = 0;
            this.tssbOpenWorking.Image = ((System.Drawing.Image)(resources.GetObject("tssbOpenWorking.Image")));
            this.tssbOpenWorking.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbOpenWorking.Name = "tssbOpenWorking";
            this.tssbOpenWorking.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tssbOpenWorking.Size = new System.Drawing.Size(105, 20);
            this.tssbOpenWorking.Text = "Рабочий каталог";
            this.tssbOpenWorking.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.tssbOpenWorking.ButtonClick += new System.EventHandler(this.tssbOpenWorking_ButtonClick);
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
            this.tpPdf.Controls.Add(this.gbxCat);
            this.tpPdf.Controls.Add(this.gbxRemove);
            this.tpPdf.Location = new System.Drawing.Point(4, 24);
            this.tpPdf.Name = "tpPdf";
            this.tpPdf.Padding = new System.Windows.Forms.Padding(3);
            this.tpPdf.Size = new System.Drawing.Size(313, 379);
            this.tpPdf.TabIndex = 1;
            this.tpPdf.Text = "PDF";
            this.tpPdf.UseVisualStyleBackColor = true;
            // 
            // gbxCat
            // 
            this.gbxCat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxCat.Controls.Add(this.btnCat);
            this.gbxCat.Controls.Add(this.btnClearFiles);
            this.gbxCat.Controls.Add(this.btnDown);
            this.gbxCat.Controls.Add(this.btnUp);
            this.gbxCat.Controls.Add(this.btnRemoveFiles);
            this.gbxCat.Controls.Add(this.btnAddFiles);
            this.gbxCat.Controls.Add(this.lsbFilesToCat);
            this.gbxCat.Location = new System.Drawing.Point(6, 107);
            this.gbxCat.Name = "gbxCat";
            this.gbxCat.Size = new System.Drawing.Size(298, 266);
            this.gbxCat.TabIndex = 4;
            this.gbxCat.TabStop = false;
            this.gbxCat.Text = "Склеивание файлов";
            // 
            // btnCat
            // 
            this.btnCat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCat.Enabled = false;
            this.btnCat.Location = new System.Drawing.Point(208, 109);
            this.btnCat.Name = "btnCat";
            this.btnCat.Size = new System.Drawing.Size(75, 23);
            this.btnCat.TabIndex = 6;
            this.btnCat.Text = "Склеить";
            this.btnCat.UseVisualStyleBackColor = true;
            this.btnCat.Click += new System.EventHandler(this.btnCat_Click);
            // 
            // btnClearFiles
            // 
            this.btnClearFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFiles.Location = new System.Drawing.Point(208, 228);
            this.btnClearFiles.Name = "btnClearFiles";
            this.btnClearFiles.Size = new System.Drawing.Size(75, 23);
            this.btnClearFiles.TabIndex = 5;
            this.btnClearFiles.Text = "Очистить";
            this.btnClearFiles.UseVisualStyleBackColor = true;
            this.btnClearFiles.Click += new System.EventHandler(this.btnClearFiles_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Enabled = false;
            this.btnDown.Location = new System.Drawing.Point(208, 80);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 23);
            this.btnDown.TabIndex = 4;
            this.btnDown.Text = "Вниз";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Enabled = false;
            this.btnUp.Location = new System.Drawing.Point(208, 51);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 23);
            this.btnUp.TabIndex = 3;
            this.btnUp.Text = "Вверх";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnRemoveFiles
            // 
            this.btnRemoveFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveFiles.Enabled = false;
            this.btnRemoveFiles.Location = new System.Drawing.Point(208, 199);
            this.btnRemoveFiles.Name = "btnRemoveFiles";
            this.btnRemoveFiles.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveFiles.TabIndex = 2;
            this.btnRemoveFiles.Text = "Удалить";
            this.btnRemoveFiles.UseVisualStyleBackColor = true;
            this.btnRemoveFiles.Click += new System.EventHandler(this.btnRemoveFiles_Click);
            // 
            // btnAddFiles
            // 
            this.btnAddFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFiles.Enabled = false;
            this.btnAddFiles.Location = new System.Drawing.Point(208, 22);
            this.btnAddFiles.Name = "btnAddFiles";
            this.btnAddFiles.Size = new System.Drawing.Size(75, 23);
            this.btnAddFiles.TabIndex = 1;
            this.btnAddFiles.Text = "Добавить";
            this.btnAddFiles.UseVisualStyleBackColor = true;
            this.btnAddFiles.Click += new System.EventHandler(this.btnAddFiles_Click);
            // 
            // lsbFilesToCat
            // 
            this.lsbFilesToCat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbFilesToCat.FormattingEnabled = true;
            this.lsbFilesToCat.HorizontalScrollbar = true;
            this.lsbFilesToCat.ItemHeight = 15;
            this.lsbFilesToCat.Location = new System.Drawing.Point(6, 22);
            this.lsbFilesToCat.Name = "lsbFilesToCat";
            this.lsbFilesToCat.Size = new System.Drawing.Size(184, 229);
            this.lsbFilesToCat.TabIndex = 0;
            this.lsbFilesToCat.SelectedIndexChanged += new System.EventHandler(this.lsbFilesToCat_SelectedIndexChanged);
            // 
            // gbxRemove
            // 
            this.gbxRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxRemove.Controls.Add(this.btnRemovePages);
            this.gbxRemove.Controls.Add(this.txbRemoveRange);
            this.gbxRemove.Controls.Add(this.lblRemoveRange);
            this.gbxRemove.Location = new System.Drawing.Point(3, 6);
            this.gbxRemove.Name = "gbxRemove";
            this.gbxRemove.Size = new System.Drawing.Size(301, 95);
            this.gbxRemove.TabIndex = 3;
            this.gbxRemove.TabStop = false;
            this.gbxRemove.Text = "Удаление страниц";
            // 
            // btnRemovePages
            // 
            this.btnRemovePages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemovePages.Enabled = false;
            this.btnRemovePages.Location = new System.Drawing.Point(210, 56);
            this.btnRemovePages.Name = "btnRemovePages";
            this.btnRemovePages.Size = new System.Drawing.Size(75, 23);
            this.btnRemovePages.TabIndex = 0;
            this.btnRemovePages.Text = "Удалить";
            this.btnRemovePages.UseVisualStyleBackColor = true;
            this.btnRemovePages.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // txbRemoveRange
            // 
            this.txbRemoveRange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbRemoveRange.Location = new System.Drawing.Point(185, 22);
            this.txbRemoveRange.Name = "txbRemoveRange";
            this.txbRemoveRange.Size = new System.Drawing.Size(100, 23);
            this.txbRemoveRange.TabIndex = 2;
            // 
            // lblRemoveRange
            // 
            this.lblRemoveRange.AutoSize = true;
            this.lblRemoveRange.Location = new System.Drawing.Point(9, 25);
            this.lblRemoveRange.Name = "lblRemoveRange";
            this.lblRemoveRange.Size = new System.Drawing.Size(174, 15);
            this.lblRemoveRange.TabIndex = 1;
            this.lblRemoveRange.Text = "Диапазоны с - по (или числа):";
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
            this.gbxCat.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnRemovePages;
        private System.Windows.Forms.TextBox txbRemoveRange;
        private System.Windows.Forms.Label lblRemoveRange;
        private System.Windows.Forms.GroupBox gbxCat;
        private System.Windows.Forms.Button btnRemoveFiles;
        private System.Windows.Forms.Button btnAddFiles;
        private System.Windows.Forms.ListBox lsbFilesToCat;
        private System.Windows.Forms.Button btnClearFiles;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnCat;
        private System.Windows.Forms.ToolStripSplitButton tssbOpenWorking;
        private System.Windows.Forms.ToolStripSplitButton tssbOpenDone;
    }
}

