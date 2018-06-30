using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01._1.MaxSequenceOfEqualElements
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int count = 1;
            int number = 0;
            int maxCount = 1;
            Stopwatch sw=new Stopwatch();
            sw.Start();
            
            for (int i = 0; i < numbers.Count-1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    count++;
                    if (count > maxCount)
                    {
                        maxCount = count;
                        number = numbers[i];
                    }
                }
                else
                {
                    count = 1;
                }
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            if (maxCount == 1)
            {
                Console.WriteLine(numbers[0]);
            }
            else
            {
                for (int i = 0; i < maxCount; i++)
                {
                    Console.Write($"{number} ");
                }
                Console.WriteLine();
            }
        
        }
    }
}
