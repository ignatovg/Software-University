using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04._1.Files
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            List<string> allfiles=new List<string>();

            for (int i = 0; i < n; i++)
            {
                allfiles.Add(Console.ReadLine());
            }
            string[] fileExt = Console.ReadLine().Split(new string[]{" in "},
                StringSplitOptions.RemoveEmptyEntries);
            string root = fileExt[1]+"\\";
            string ext = "."+fileExt[0];

            Dictionary<string,int> data=new Dictionary<string, int>();


            foreach (var file in allfiles)
            {
                string[] pathAndSize = file.Split(';');

                string path = pathAndSize[0];
                

                if (path.StartsWith(root) && path.EndsWith(ext))
                {
                    var namePlusExt = path.Split('\\').Last();

                    int size = int.Parse(pathAndSize[1]);
                    data[namePlusExt] = size;
                }
            }

            foreach (var pair in data.OrderByDescending(a=>a.Value).ThenBy(a=>a.Key))
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} KB");
            }

            if (data.Count == 0)
            {
                Console.WriteLine("No");
            }
        }
    }
}
