using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;

namespace P04.AnonymousCashe
{


    class Program
    {
        static void Main(string[] args)
        {
            //dataKey} -> {dataSize} | {dataSet}
            Dictionary<string,Dictionary<string,int>> data =new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, Dictionary<string, int>> cashe = new Dictionary<string, Dictionary<string, int>>();
         

            string dataSet = string.Empty;
            while (true)
            {
                string[] tokens = Console.ReadLine().Split(new string[]{" -> "," | "},
                    StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "thetinggoesskrra")
                {
                    break;
                }
                
                if (tokens.Length == 1)
                {
                    dataSet = tokens[0];
                    if (!data.ContainsKey(dataSet))
                    {
                        data.Add(dataSet,new Dictionary<string, int>());
                        continue;
                    }
                }
                string dataKey = tokens[0];
                int dataSize = int.Parse(tokens[1]);
                 dataSet = tokens[2];

                if (data.ContainsKey(dataSet))
                {
                    data[dataSet].Add(dataKey,dataSize);
                }
                else
                {
                    if (!cashe.ContainsKey(dataSet))
                    {
                        cashe.Add(dataSet,new Dictionary<string, int>());
                       
                    }
                    cashe[dataSet].Add(dataKey, dataSize);
                }
            }

            foreach (var pair in cashe)
            {
                string dataSetPair = pair.Key;
                var keyAndSizePair = pair.Value;

                foreach (var innerPiar in keyAndSizePair)
                {
                    if (!data.ContainsKey(dataSetPair))
                    {
                        data.Add(dataSetPair, new Dictionary<string, int>());
                        
                    }
                    data[dataSetPair].Add(innerPiar.Key,innerPiar.Value);
                }

            }







            foreach (var pair in data.OrderByDescending(a=>a.Value.Values.Sum()))
            {
                Console.WriteLine($"Data Set: {pair.Key}, Total Size: {pair.Value.Values.Sum()}");
                foreach (var s in pair.Value)
                {
                    Console.WriteLine($"$.{s.Key}");
                }
                break;
            }
        }
    }
}
