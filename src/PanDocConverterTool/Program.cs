using PanDocConverter;
using System.Diagnostics;

namespace PanDocConverterTool
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: PanDocConverterTool.exe directory");
                return 1;
            }

            var dinfo = new DirectoryInfo(args[0]);
            if (!dinfo.Exists)
            {
                Console.WriteLine("Directory {0} does not exist", args[0]);
                return 1;
            }

            var files = Directory.GetFiles(dinfo.FullName, "*.md", SearchOption.AllDirectories);
            var tempFile = Path.GetTempFileName() + ".docx";
            using var doc = new WordManipulator(tempFile, true);
            foreach (var file in files)
            {
                //Need to convert with pandoc
                var fi = new FileInfo(file);
                var outputFile = Path.ChangeExtension(fi.FullName, ".docx");
                var pi = new ProcessStartInfo("pandoc", $"-s -o {outputFile} {fi.Name}");
                pi.WorkingDirectory = Path.GetDirectoryName(fi.FullName);
                pi.UseShellExecute = false;
                Process.Start(pi).WaitForExit();
                doc.AppendOtherWordFile(outputFile, true);
            }

            doc.Dispose();
            var startdoc = new ProcessStartInfo(tempFile);
            startdoc.UseShellExecute = true;
            System.Diagnostics.Process.Start(startdoc);
            
            return 0;
        }
    }
}