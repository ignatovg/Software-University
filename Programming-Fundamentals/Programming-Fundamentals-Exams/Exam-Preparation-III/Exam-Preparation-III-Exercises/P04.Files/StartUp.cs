using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P04.Files
{
    class StartUp
    {
        static void Main(string[] args)
        {

            var n = int.Parse(Console.ReadLine());
            List<string> allFiles = new List<string>();

            for (int i = 0; i < n; i++)
            {
                allFiles.Add(Console.ReadLine());
            }

            string filter = Console.ReadLine();
            var filterTokens = Regex.Split(filter, " in ");
            var filterExt = "." + filterTokens[0];
            var filterRoot = filterTokens[1] + "\\";

            Dictionary<string, int> fileSize = new Dictionary<string, int>();

            foreach (var file in allFiles)
            {
                var filePlusSize = file.Split(';');
                var size = int.Parse(filePlusSize[1]);
                var path = filePlusSize[0];

                if (path.StartsWith(filterRoot) && path.EndsWith(filterExt))
                {
                    var tokens = path.Split('\\');
                    var fileName = tokens[tokens.Length - 1];
                    fileSize[fileName] = size;
                }
            }

            var sortedOutputItems = fileSize
                .ToArray()
                .OrderByDescending(fs => fs.Value)
                .ThenBy(fs => fs.Key);

            foreach (var fs in sortedOutputItems)
            {
                Console.WriteLine(fs.Key + " - " + fs.Value+" KB");
            }

            if (!sortedOutputItems.Any())
            {
                Console.WriteLine("No");
            }
        }
    }
}
