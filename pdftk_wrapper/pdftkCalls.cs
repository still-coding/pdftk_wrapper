using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace pdftk_wrapper
{
    static class pdftkCalls
    {
        public static uint GetPageNumber(string filePath, string workingDir)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.WorkingDirectory = workingDir;
            p.StartInfo.Arguments = $"/c chcp 65001 && .\\pdftk.exe \"{filePath}\" dump_data";
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            // TODO refactor this ugly shit
            int pos = output.IndexOf("NumberOfPages");
            string line = output.Substring(pos, output.Length - pos);
            line = line.Substring(line.IndexOf(" ") + 1, line.IndexOf(Environment.NewLine) - line.IndexOf(" ") - 1);
            uint pageCount = uint.Parse(line);
            return pageCount;
        }

        public static void RemovePages(string range, string file, string newFile, string workingDir)
        {            
            // pdftk in.pdf cat 1-12 14-end output out.pdf
            // TODO hide console maybe?
            string command = $"/c chcp 65001 && cd \"{workingDir}\" && .\\pdftk.exe \"{file}\" cat {range} output \"{newFile}\"";
            Process p = Process.Start("cmd.exe", command);
            p.WaitForExit();
        }


        public static void CatFiles(List<string> files, string newFile, string workingDir)
        {
            // pdftk file1.pdf file2.pdf cat output mergedfile.pdf
            string command = $"/c chcp 65001 && cd \"{workingDir}\" && .\\pdftk.exe \"{string.Join("\" \"", files)}\" cat output \"{newFile}\"";
            Process p = Process.Start("cmd.exe", command);
            p.WaitForExit();
        }
    }
}
