using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace P04_FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            var startAndEnd = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            
            string condition = Console.ReadLine();
            Func<int, bool> expression = a => a % 2 == 0;

            Console.WriteLine(string.Join(" ",Result(condition,startAndEnd,expression)));
          
        }

        public static List<int> Result(string condition,int[] startAndEnd, Func<int, bool> expression)
        {
            int starts = Math.Min(startAndEnd[0], startAndEnd[1]);
            int ends = Math.Max(startAndEnd[0], startAndEnd[1]);
            List<int> results = new List<int>();

            if (condition == "even")
            {
                for (int i = starts; i <= ends; i++)
                {
                    if (expression(i))
                    {
                        results.Add(i);
                    }
                }
                return results;
            }
            else if (condition == "odd")
            {
                for (int i = starts; i <= ends; i++)
                {
                    if (!expression(i))
                    {
                        results.Add(i);
                    }
                }
                return results;
            }
            return results;
        }
       
    }
}
