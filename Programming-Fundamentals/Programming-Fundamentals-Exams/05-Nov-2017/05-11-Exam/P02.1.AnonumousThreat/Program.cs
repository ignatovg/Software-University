using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02._1.AnonumousThreat
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
                    string currentString = inputTokens[index];

                    if (inputTokens[index].Length < partitions)
                    {
                        for (int i = index; i < inputTokens.Count; i++)
                        {
                             currentString = inputTokens[i];
                            partitions /= currentString.Length;
                            inputTokens = DevideTokkens(inputTokens, index, partitions, currentString);
                        }
                    }
                    else
                    {
                        inputTokens = DevideTokkens(inputTokens, index, partitions, currentString);
                    }
                }

            }
            Console.WriteLine(string.Join(" ", inputTokens));
        }

        private static List<string> DevideTokkens(List<string> inputTokens, int index, int partitions,string currentString)
        {
            List<string> result=new List<string>();

           
            int partitionsToTake = currentString.Length / partitions;
            result.AddRange(inputTokens.Take(index));

            if (inputTokens[index].Length % partitions == 0)
            {
                for (int i = 0; i < partitions; i++)
                {
                    result.Add(string.Join("", currentString.Skip(partitionsToTake * i).Take(partitionsToTake)));
                }
                result.AddRange(inputTokens.Skip(index + 1));
            }
            else
            {
                for (int i = 0; i < partitions-1; i++)
                {
                    result.Add(string.Join("", currentString.Skip(partitionsToTake * i).Take(partitionsToTake)));
                }
                result.Add(string.Join("", currentString.Skip(partitions * partitionsToTake-1)));

                result.AddRange(inputTokens.Skip(index + 1));
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
