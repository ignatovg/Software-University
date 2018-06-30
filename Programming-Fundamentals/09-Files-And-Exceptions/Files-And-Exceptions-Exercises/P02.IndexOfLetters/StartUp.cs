using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.IndexOfLetters
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var word = File.ReadAllText("input.txt").ToLower().ToCharArray();

            File.WriteAllText("output.txt",string.Empty);
            for (int i = 0; i < word.Length; i++)
            {
                var index = word[i] - 'a';
                File.AppendAllText("output.txt",$"{word[i]} -> {index}{Environment.NewLine}");
            }
        }
    }
}
