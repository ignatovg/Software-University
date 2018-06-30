using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.WordCount
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllText("text.txt").ToLower();

            var textInArr = text.Split(new char[] {'-', '?', '!', '.', ',', ':','\r','\n',' '},
                StringSplitOptions.RemoveEmptyEntries).ToArray();

            var dit=new Dictionary<string,int>();

            for (int i = 0; i < textInArr.Length; i++)
            {
                string word = textInArr[i];
                if(!dit.ContainsKey(word))
                {
                    dit.Add(word,0);
                }
                dit[word]++;;
            }
            var specialWords = File.ReadAllText("words.txt").Split(' ');
            File.WriteAllText("output.txt",string.Empty);
            foreach (var pair in dit.OrderByDescending(a => a.Value))
            {
                if (specialWords.Contains(pair.Key))
                {
                    File.AppendAllText("output.txt", $"{pair.Key} - {pair.Value}\r\n");
                   
                }
            }
        }
    }
}
