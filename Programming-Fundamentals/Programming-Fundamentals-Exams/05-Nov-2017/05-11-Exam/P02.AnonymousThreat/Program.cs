using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputTokens = Console.ReadLine().Split(' ').ToList();
            while (true)
            {
                string[] commandArgs = Console.ReadLine().Split(' ');
                if (commandArgs[0] == "3:1")
                {
                    break;
                }

                if (commandArgs[0] == "merge")
                {
                    int startIndex = int.Parse(commandArgs[1]);
                    int endIndex = int.Parse(commandArgs[2]);

                    if (startIndex < 0 || endIndex > inputTokens.Count)
                    {
                        continue;
                    }

                        inputTokens = MergeTokkens(inputTokens, startIndex, endIndex);



                }
                else if (commandArgs[0] == "divide")
                {
                    int index = int.Parse(commandArgs[1]);
                    int partitions = int.Parse(commandArgs[2]);

                    
                    inputTokens = DevideTokkens(inputTokens, index, partitions);
                }

            }
            Console.WriteLine(string.Join(" ", inputTokens));
        }

        private static List<string> DevideTokkens(List<string> inputTokens, int index, int partitions)
        {
            List<string> result = new List<string>();

            string aimedStr = inputTokens[index];
            int length = aimedStr.Length;

            result.AddRange(inputTokens.Take(index));
            
            if (length % partitions == 0)
            {
                int partitionsToTake = length / partitions;

                for (int i = 0; i < partitions; i++)
                {
                    result.Add(string.Join("", aimedStr.Skip(i * partitionsToTake).Take(partitionsToTake)));
                }

                result.AddRange(inputTokens.Skip(index + 1));
                return result;
            }
            else
            {
                int partitionsTake = length / partitions;

                if (aimedStr.Length < partitions)
                {
                    for (int i = index; i < inputTokens.Count; i++)
                    {
                        StringBuilder str=new StringBuilder();
                        string currentString = inputTokens[i];

                        for (int k = 0; k < currentString.Length; k++)
                        {
                            result.Add(string.Join("", currentString.Skip(i* partitionsTake).Take(partitionsTake)));
                        }

                    }
                }
            }
            return result;
        }

        private static List<string> MergeTokkens(List<string> inputTokens, int startIndex, int endIndex)
        {
            List<string> results = new List<string>();
            StringBuilder wholeStr = new StringBuilder();



                for (int i = startIndex; i < endIndex; i++)
                {
                    wholeStr.Append(inputTokens[i]);
                }

                results.AddRange(inputTokens.Take(startIndex));
                results.Add(wholeStr.ToString());
                results.AddRange(inputTokens.Skip(endIndex));

                return results;
          
        }
    }
}
