using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P07__DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            var filesDictionary = new Dictionary<string,List<FileInfo>>();

            var files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                string extensions = fileInfo.Extension;

                if (!filesDictionary.ContainsKey(extensions))
                {
                    filesDictionary[extensions] = new List<FileInfo>();
                }
                filesDictionary[extensions].Add(fileInfo);
            }

            filesDictionary = filesDictionary
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullFileName = desktop + "/report.txt";

            using (var writer = new StreamWriter(fullFileName))
            {
                foreach (var pair in filesDictionary)
                {
                    string extension = pair.Key;
                    var fileInfos = pair.Value
                        .OrderByDescending(fi => fi.Length);

                    writer.WriteLine(extension);

                    foreach (var fileInfo in fileInfos)
                    {
                        double fileSize = (double) fileInfo.Length / 1024;

                        writer.WriteLine($"--{fileInfo.Name} - {fileSize:f3}kb");
                    }
                }
            }
        }
    }
}
