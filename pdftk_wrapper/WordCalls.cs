using System;
using Word = Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;

namespace pdftk_wrapper
{
    static class WordCalls
    {
        private static Word.Application wordApp;
        public static void OpenWord()
        {
            wordApp  = new Word.Application();
        }

        public static void CloseWord()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            wordApp.Quit();
            Marshal.ReleaseComObject(wordApp);
        }

        public static void ConvertDocToPdf(string file, string newFile)
        {
            Word.Document doc = wordApp.Documents.Open(file);
            doc.ExportAsFixedFormat(newFile, Word.WdExportFormat.wdExportFormatPDF);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            doc.Close(false);
            Marshal.ReleaseComObject(doc);
        }
    }
}
