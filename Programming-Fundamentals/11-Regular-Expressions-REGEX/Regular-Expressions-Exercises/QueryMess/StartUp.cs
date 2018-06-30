using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryMess
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            
 Dictionary<string,List<string>> dict =new Dictionary<string, List<string>>();


            while (line!="END")
            {
                string[] tokens = line.Split('&');

                for ( int i = 0; i < tokens.Length; i++)
                {
                    tokens[i] = tokens[i].Replace("+"," ");
                    tokens[i] = tokens[i].Replace("%20"," ");

                    string key = tokens[i].Split('=').First().Trim();
                    string value = tokens[i].Split('=').Last().Trim();


                    if (!dict.ContainsKey(key))
                    {
                        dict.Add(key,new List<string>());
                        dict[key].Add(value);
                    }
                    else
                    {
                        dict[key].Add(value);
                    }
                }
                
                line = Console.ReadLine();
            }

            foreach (var pair in dict)
            {
                Console.Write($"{pair.Key}=[{string.Join(", ",pair.Value)}]");
            }
            Console.WriteLine();
        }
    }
}
