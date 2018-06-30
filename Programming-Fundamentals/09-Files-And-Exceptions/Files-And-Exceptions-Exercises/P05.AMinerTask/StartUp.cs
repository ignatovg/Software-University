using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.AMinerTask
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var dict=new Dictionary<string,int>();

            for (int i = 0; i < input.Length; i+=2)
            {
                string name = input[i];
                if (name == "stop")
                {
                    break;
                }
                int quantity = int.Parse(input[i + 1]);

                if (!dict.ContainsKey(name))
                {
                    dict.Add(name,quantity);
                }
                else
                {
                    dict[name] += quantity;
                }
            }

            foreach (var pair in dict)
            {
                File.AppendAllText("output.txt",$"{pair.Key} -> {pair.Value}{Environment.NewLine}");
             
            }
        }
    }
}
