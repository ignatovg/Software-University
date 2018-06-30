using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.MergeFiles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var fileOne = File.ReadAllLines("FileOne.txt");
            var fileTwo = File.ReadAllLines("FileTwo.txt");

           File.WriteAllText("output.txt",string.Empty);
            int right = 0;
            int left = 0;
            for (int i = 0; i < 2*fileOne.Length; i++)
            {
                if (i % 2 == 0)
                {
                    File.AppendAllText("ouput.txt",fileOne[left]+"\r\n");
                    left++;
                }
                else
                {
                    File.AppendAllText("ouput.txt", fileTwo[right]+"\r\n");
                    right++;
                }
            }
        }
    }
}
