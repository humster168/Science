using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Science.MainProgram
{
    public class MainViewModel
    {
        Process myProcess = new Process();
        public MainViewModel()
        {
            var path = ConfigSettings.BlocksFolderPath;
            var folders = Directory.GetDirectories(path);
            var files = new List<string>();
            foreach (var folder in folders)
            {
                var filesInfolder = Directory.GetFiles(folder);
                var exeFiles = filesInfolder.Where(i => i.EndsWith(".exe") && !i.EndsWith(".vshost.exe"));
                //todo if many exe files?
                var enumerable = exeFiles as string[] ?? exeFiles.ToArray();
                if (enumerable.Any())
                {
                    files.AddRange(enumerable);
                }
            }
            StartProcess(files);
        }

        private void StartProcess(List<string> files)
        {
            try
            {
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = files[0];
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.Start();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }
    }
}