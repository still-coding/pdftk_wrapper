using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pdftk_wrapper
{
    public partial class MainForm : Form
    {
        static string workingDirName = "рабочая";
        string watchPath = Path.Combine(Application.StartupPath, workingDirName);
        
        delegate void UpdateFilesDelegate(string path, string filter);
        UpdateFilesDelegate updDelegate;

        private void updateFiles(string path, string filter)
        {
            ImageList imageList = new ImageList();
            lvExplorer.SmallImageList = imageList;
            lvExplorer.Items.Clear();
            foreach (string item in Directory.GetFiles(path, filter))
            {
                if (path.StartsWith("~"))
                    continue;
                imageList.Images.Add(Icon.ExtractAssociatedIcon(item));
                lvExplorer.Items.Add(new FileInfo(item).Name, imageList.Images.Count - 1);
            }
            lvExplorer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        public MainForm()
        {
            InitializeComponent();
            updDelegate = new UpdateFilesDelegate(updateFiles);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            fswMainDir.Path = Directory.CreateDirectory(watchPath).FullName;
            lvExplorer.Invoke(updDelegate, watchPath, "*.doc?");
        }

        private void fswMainDir_Deleted(object sender, FileSystemEventArgs e)
        {
            Directory.CreateDirectory(watchPath);
            lvExplorer.Invoke(updDelegate, watchPath, "*.doc?");
        }

        private void fswMainDir_Changed(object sender, FileSystemEventArgs e)
        {
            lvExplorer.Invoke(updDelegate, watchPath, "*.doc");
        }

        private void lvExplorer_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            foreach (ListViewItem item in lvExplorer.Items)
            {
                item.Selected = !item.Selected;
            }
        }
    }
}
