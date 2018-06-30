using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.Any
{
    class Data
    {
        public string DataSet { get; set; }
        public List<string> DataKey { get; set; }
        public List<int> DataSize { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Data> anonymousDatas = new List<Data>();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(new string[] { " -> ", " | " },
                    StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "thetinggoesskrra")
                {
                    break;
                }
                string dataSet = tokens[2];

                if (tokens.Length == 0)
                {
                    Data cuttentData = new Data();
                    cuttentData.DataSet = dataSet;

                    anonymousDatas.Add(cuttentData);
                }
                if (anonymousDatas.Any(d => d.DataSet == dataSet))
                {
                    anonymousDatas.Where(a=>a.DataSet==dataSet
                }
                string dataKey = tokens[0];
                int dataSize = int.Parse(tokens[1]);


            }
        }
    }
}
