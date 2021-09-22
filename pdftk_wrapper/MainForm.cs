using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;

namespace pdftk_wrapper
{
    public partial class MainForm : Form
    {
        enum FileType { doc, pdf };

        struct PageRange
        {
            public PageRange(uint start, uint end)
            {
                Start = start > 1 ? start : 1;
                End = end > start? end : start;
            }

            public PageRange(uint start)
            {
                Start = start > 1 ? start : 1;
                End = start;
            }

            public uint Start { get; }
            public uint End { get; }

            public bool Overlaps(PageRange other)
            {
                // this     other
                //  []       ()
                // this.end overlaps with other.start
                //   [ (] )
                if (this.End >= other.Start && this.Start < other.End)
                    return true;

                // this inside other
                // ([])
                if (this.Start >= other.Start && this.End <= other.End)
                    return true;

                // this.start overlaps with other.end
                // ( [) ]
                if (this.Start <= other.End && this.End > other.End)
                    return true;

                // other inside this
                // [ () ]
                if (this.Start <= other.Start && this.End >= other.End)
                    return true;

                return false;
            }

            public List<PageRange> SortOrFindOverlapping(List<PageRange> prList)
            {
                List<PageRange> res = new List<PageRange>();

                for (int i = 0; i < prList.Count; i++)
                {
                    for (int j = 0; j < prList.Count; j++)
                    {
                        if (i == j)
                            continue;
                        if (prList[i].Overlaps(prList[j]))
                            return res;
                    }
                }

                prList.Sort((x, y) => x.Start.CompareTo(y.Start));
                return prList;
            }

        }

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

        private void fswMainDir_Changed_Deleted(object sender, EventArgs e)
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
            tspbProgress.Value = 0;
            tslDetails.Text = $"0/{cnt}";
            tspbProgress.Visible = tslDetails.Visible = true;
            Word.Application wordApp = new Word.Application();

            foreach (ListViewItem item in lvExplorer.SelectedItems)
            {
                string file = Path.Combine(workingPath, item.Text);
                Word.Document doc = wordApp.Documents.Open(file);
                doc.ExportAsFixedFormat(Path.Combine(donePath, Path.GetFileNameWithoutExtension(file) + ".pdf"), Word.WdExportFormat.wdExportFormatPDF);

                GC.Collect();
                GC.WaitForPendingFinalizers();
                doc.Close(false);
                Marshal.ReleaseComObject(doc);

                // TODO make async
                tspbProgress.PerformStep();
                tslDetails.Text = $"{++progressPos}/{cnt}";
                Application.DoEvents();
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            wordApp.Quit();
            Marshal.ReleaseComObject(wordApp);
            tslMessage.Text = "Готово";
            tspbProgress.Visible = tslDetails.Visible = false;
        }

        private void lvExplorer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cnt = lvExplorer.SelectedItems.Count;
            tslMessage.Text = $"Выделено файлов: {cnt}";
            btnDoc2Pdf.Enabled = Convert.ToBoolean(cnt);
        }

        private void tcFileTypes_Selected(object sender, TabControlEventArgs e)
        {
            currentFileType = e.TabPage == tpDoc ? FileType.doc : FileType.pdf;
            lvExplorer.Invoke(updDelegate, workingPath, currentFileType == FileType.doc ? "*.doc?" : "*.pdf");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // TODO refactor this ugly shit
            char dash = '-';
            char comma = ',';

            char[] arr = txbRemoveRange.Text.Where(c => (char.IsDigit(c) || c == dash || c == comma)).ToArray();
            string range = new string(arr);
            string str = range.Substring(0, range.IndexOf(dash) + 1);
            range = str + range.Substring(str.Length).Replace(dash.ToString(), "");
            string[] ranges = range.Split(comma);

            bool wasError = false;
            int maxpage = 0;
            foreach (string r in ranges)
            {
                string[] pages = r.Split(dash);
                
                if (pages.Length == 2)
                {
                    if (int.Parse(pages[0]) >= int.Parse(pages[1]))
                    {
                        MessageBox.Show($"Неправильный диапазон: {r}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        wasError = true;
                    }
                }

                foreach (string p in pages)
                {
                    int page = int.Parse(p);
                    if (page < 1)
                    {
                        MessageBox.Show($"Неправильный номер страницы: 0", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        wasError = true;
                    }
                    maxpage = page > maxpage ? page : maxpage;
                }            
            }

            if (wasError)
                return;

            range = string.Join(' ', ranges);



            //var process = new Process();
            //var psi = new ProcessStartInfo();
            //psi.FileName = "cmd.exe";
            //psi.RedirectStandardInput = true;
            //psi.RedirectStandardOutput = true;
            //psi.RedirectStandardError = true;
            //psi.UseShellExecute = false;
            //psi.WorkingDirectory = Application.StartupPath;
            //process.StartInfo = psi;
            //process.Start();
            //process.OutputDataReceived += (sender, e) => { Console.WriteLine(e.Data); };
            //process.ErrorDataReceived += (sender, e) => { Console.WriteLine(e.Data); };
            //process.BeginOutputReadLine();
            //process.BeginErrorReadLine();
            //using (StreamWriter sw = process.StandardInput)
            //{
            //    //if (sw.BaseStream.CanWrite)
            //    //{
            //        sw.WriteLine("chcp 65001");

            //        foreach (ListViewItem item in lvExplorer.SelectedItems)
            //        {
            //            string file = Path.Combine(workingDirName, item.Text);
            //            string newFile = Path.Combine(doneDirName, item.Text);

            //            sw.WriteLine($".\\pdftk.exe \"{file}\" cat {range} {maxpage + 1}-end output \"{newFile}\"");
            //            //sw.WriteLine("exit");

            //        }
            //    //}
            //}
            //process.WaitForExit();






            //Process proc = new Process();
            //ProcessStartInfo info = new ProcessStartInfo();
            //info.FileName = "cmd.exe";
            //info.RedirectStandardInput = true;
            //info.UseShellExecute = false;
            //proc.StartInfo = info;
            //proc.Start();

            //using (StreamWriter sw = proc.StandardInput)
            //{
            //    if (sw.BaseStream.CanWrite)
            //    {
            //        sw.WriteLine("chcp 65001");
            //        sw.WriteLine($"cd \"{}\"");

            //        foreach (ListViewItem item in lvExplorer.SelectedItems)
            //        {
            //            string file = Path.Combine(workingDirName, item.Text);
            //            string newFile = Path.Combine(doneDirName, item.Text);

            //            sw.WriteLine($".\\pdftk.exe \"{file}\" cat {range} {maxpage + 1}-end output \"{newFile}\"");
            //            //sw.WriteLine("exit");

            //        }
            //    }
            //}
            foreach (ListViewItem item in lvExplorer.SelectedItems)
            {
            string file = Path.Combine(workingDirName, item.Text);

            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.WorkingDirectory = Application.StartupPath;
            p.StartInfo.Arguments = $"/c chcp 65001 && .\\pdftk.exe \"{file}\" dump_data";
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            
                int pos = output.IndexOf("NumberOfPages");
            string line = output.Substring(pos, output.Length - pos);
                line = line.Substring(line.IndexOf(" ") + 1, line.IndexOf(Environment.NewLine) - line.IndexOf(" ") - 1);
                MessageBox.Show("+" + line + "+");
                int pageCount = int.Parse(line);

                HashSet<int> pages = new HashSet<int>();
                for (int i = 1; i <= pageCount; i++)
                    pages.Add(i);


            
                //string file = Path.Combine(workingDirName, item.Text);
                string newFile = Path.Combine(doneDirName, item.Text);

                // pdftk in.pdf cat 1-12 14-end output out.pdf

                string command = $"/c chcp 65001 && cd \"{Application.StartupPath}\" && .\\pdftk.exe \"{file}\" cat {range} {maxpage + 1}-end output \"{newFile}\"";

                textBox1.Text = command;

                Process.Start("cmd", command);

            }
        }
    }
}
