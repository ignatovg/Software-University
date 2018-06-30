using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.OddOccurrences
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().ToLower().Split(' ');
            
            var dict=new Dictionary<string,int>();

            for (int i = 0; i < line.Length; i++)
            {
                string word = line[i];

                if (!dict.ContainsKey(word))
                {
                    dict.Add(word,0);
                }
                dict[word]++;
            }
           List<string> result=new List<string>();
            foreach (var item in dict)
            {
                if (item.Value % 2 != 0)
                {
                    result.Add(item.Key);
                }
            }
            Console.WriteLine(string.Join(", ",result));
        }
    }
}
