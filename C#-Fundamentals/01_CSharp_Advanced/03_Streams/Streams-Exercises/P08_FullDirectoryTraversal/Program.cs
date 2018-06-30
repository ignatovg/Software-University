using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P08_FullDirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            //get and store file info abaut all files int the current dictionary
            string[] filePaths = Directory.GetFiles(Console.ReadLine(), "*.*", SearchOption.AllDirectories);

            List<FileInfo> files = filePaths.Select(path => new FileInfo(path)).ToList();

            //sort file info
            var sorted = files.OrderBy(file => file.Length).GroupBy(file => file.Extension).OrderByDescending(group => group.Count()).ThenBy(group => group.Key);

            //locate desktop
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //create report file
            using (StreamWriter writer = new StreamWriter(desktop + "/report.txt"))
            {
                foreach (var group in sorted)
                {
                    writer.WriteLine(group.Key);
                    foreach (var y in group)
                    {
                        var size = y.Length / 1024.0;
                        writer.WriteLine($"--{y.Name} - {size:f3}");
                    }
                }
            }
        }
    }
}
