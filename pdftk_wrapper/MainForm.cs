using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace pdftk_wrapper
{
    public partial class MainForm : Form
    {
        enum FileType { doc, pdf };

        static string workingDirName = "рабочая";
        string workingPath = Path.Combine(Application.StartupPath, workingDirName);

        static string doneDirName = "готовые";
        string donePath = Path.Combine(Application.StartupPath, doneDirName);

        FileType currentFileType = FileType.doc;
        delegate void UpdateFilesDelegate(string path, string filter);
        UpdateFilesDelegate updDelegate;

        void updateListViewFiles(string path, string filter)
        {
            ImageList imageList = new ImageList();
            lvExplorer.SmallImageList = imageList;
            lvExplorer.Items.Clear();
            foreach (string item in Directory.GetFiles(path, filter))
            {
                if (item.Contains("~$"))
                    continue;
                imageList.Images.Add(Icon.ExtractAssociatedIcon(item));
                lvExplorer.Items.Add(new FileInfo(item).Name, imageList.Images.Count - 1);
            }
            lvExplorer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        void updateFiles()
        {
            lvExplorer.Invoke(updDelegate, workingPath, currentFileType == FileType.doc ? "*.doc?" : "*.pdf");
        }

        public MainForm()
        {
            InitializeComponent();
            updDelegate = new UpdateFilesDelegate(updateListViewFiles);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory(donePath);
            fswMainDir.Path = Directory.CreateDirectory(workingPath).FullName;
            updateFiles();

            tslMessage.Text = $"Найдено файлов: {lvExplorer.Items.Count}";
        }

        private void fswMainDir_Created_Changed_Deleted(object sender, EventArgs e)
        {
            updateFiles();
        }

        private void fswMainDir_Deleted(object sender, FileSystemEventArgs e)
        {
            Directory.CreateDirectory(workingPath);
            updateFiles();
        }

        private void lvExplorer_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            foreach (ListViewItem item in lvExplorer.Items)
                item.Selected = !item.Selected;
        }

        private void btnDoc2Pdf_Click(object sender, EventArgs e)
        {
            int cnt = lvExplorer.SelectedItems.Count;
            if (cnt == 0)
                return;
            int progressPos = 0;
            tslMessage.Text = "Конвертация файлов...";
            tspbProgress.Maximum = cnt;
            tspbProgress.Value = progressPos;
            tslDetails.Text = $"0/{cnt}";
            tspbProgress.Visible = tslDetails.Visible = true;

            WordCalls.OpenWord();
            foreach (ListViewItem item in lvExplorer.SelectedItems)
            {
                // TODO make async
                tspbProgress.PerformStep();
                tslDetails.Text = $"{++progressPos}/{cnt}";
                Application.DoEvents();

                string file = Path.Combine(workingPath, item.Text);
                string newFile = Path.Combine(donePath, Path.GetFileNameWithoutExtension(file) + ".pdf");
                WordCalls.ConvertDocToPdf(file, newFile);
            }

            WordCalls.CloseWord();

            tslMessage.Text = "Готово";
            tspbProgress.Visible = tslDetails.Visible = false;
        }

        private void lvExplorer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cnt = lvExplorer.SelectedItems.Count;
            tslMessage.Text = $"Выделено файлов: {cnt}";
            btnDoc2Pdf.Enabled = btnRemovePages.Enabled = btnAddFiles.Enabled = Convert.ToBoolean(cnt);
        }

        private void tcFileTypes_Selected(object sender, TabControlEventArgs e)
        {
            currentFileType = e.TabPage == tpDoc ? FileType.doc : FileType.pdf;
            foreach (ListViewItem i in lvExplorer.SelectedItems)
                i.Selected = false;
            updateFiles();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int cnt = lvExplorer.SelectedItems.Count;
            if (cnt == 0)
                return;
            int progressPos = 0;
            tslMessage.Text = "Обработка файлов...";
            tspbProgress.Maximum = cnt;
            tspbProgress.Value = progressPos;
            tslDetails.Text = $"0/{cnt}";
            tspbProgress.Visible = tslDetails.Visible = true;


            List<PageRange> toRemove = PageRange.ParseAll(txbRemoveRange.Text);
            foreach (ListViewItem item in lvExplorer.SelectedItems)
            {
                // TODO make async
                tspbProgress.PerformStep();
                tslDetails.Text = $"{++progressPos}/{cnt}";
                Application.DoEvents();

                string file = Path.Combine(workingDirName, item.Text);
                uint pageNumber = pdftkCalls.GetPageNumber(file, Application.StartupPath);                
                List<PageRange> catList = PageRange.GetCatListFromToRemoveList(toRemove, pageNumber);
                string newFile = Path.Combine(doneDirName, item.Text);
                pdftkCalls.RemovePages(PageRange.ListToString(catList), file, newFile, Application.StartupPath);
            }
            tslMessage.Text = "Готово";
            tspbProgress.Visible = tslDetails.Visible = false;
        }

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvExplorer.SelectedItems)
                lsbFilesToCat.Items.Add(item.Text);
            tslMessage.Text = $"Для склейки добавлено: {lvExplorer.SelectedItems.Count}, всего файлов: {lsbFilesToCat.Items.Count}";
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            lsbFilesToCat.MoveSelectedItemUp();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            lsbFilesToCat.MoveSelectedItemDown();
        }

        private void btnRemoveFiles_Click(object sender, EventArgs e)
        {
            tslMessage.Text = $"{lsbFilesToCat.SelectedItem} удалён, всего файлов для склейки: {lsbFilesToCat.Items.Count - 1}";
            lsbFilesToCat.Items.Remove(lsbFilesToCat.SelectedItem);
        }

        private void btnClearFiles_Click(object sender, EventArgs e)
        {
            lsbFilesToCat.Items.Clear();
        }

        private void lsbFilesToCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUp.Enabled = btnDown.Enabled = btnRemoveFiles.Enabled = btnCat.Enabled = lsbFilesToCat.SelectedIndex >= 0;
        }

        private void btnCat_Click(object sender, EventArgs e)
        {
            int cnt = lsbFilesToCat.Items.Count;
            if (cnt == 0)
                return;
            string newFile = Path.GetFileNameWithoutExtension(lsbFilesToCat.SelectedItem.ToString()) + "_склейка.pdf";
            tslMessage.Text = $"Склеивание {cnt} файлов в {newFile}...";
            
            List<string> files = new List<string>();
            foreach (var item in lsbFilesToCat.Items)
                files.Add(Path.Combine(workingPath, item.ToString()));
            
            pdftkCalls.CatFiles(files, Path.Combine(donePath, newFile), Application.StartupPath);

            lsbFilesToCat.Items.Clear();
            tslMessage.Text = "Готово";
        }

        private void tssbOpenWorking_ButtonClick(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", workingPath);
        }

        private void tssbOpenDone_ButtonClick(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", donePath);
        }
    }
}
