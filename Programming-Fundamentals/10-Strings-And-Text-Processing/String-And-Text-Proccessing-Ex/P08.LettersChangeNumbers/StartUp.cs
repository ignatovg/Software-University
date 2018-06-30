using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P08.LettersChangeNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
           
                string[] line = Console.ReadLine().Split(new char[] {' '},
                    StringSplitOptions.RemoveEmptyEntries).ToArray();

            decimal totalSum = 0;

                for (int i = 0; i < line.Length; i++)
                {

                    var firstStr = line[i];
                    var numberArray = firstStr.Skip(1).Take(firstStr.Length - 2).ToArray();
                    decimal number = decimal.Parse(string.Join("", numberArray));
                    decimal result = 0;

                    if (char.IsUpper(firstStr[0]))
                    {

                        int possition = firstStr[0] - 'A' + 1;
                        result = number / possition;
                    }
                    else
                    {
                        int possition = firstStr[0] - 'a' + 1;
                        result = number * possition;
                    }

                    if (char.IsUpper(firstStr[firstStr.Length - 1]))
                    {
                        int possition = firstStr[firstStr.Length - 1] - 'A' + 1;
                        result -= possition;
                    }
                    else
                    {
                        int possition = firstStr[firstStr.Length - 1] - 'a' + 1;
                        result += possition;
                    }
                    totalSum += result;
                }
                Console.WriteLine($"{totalSum:f2}");
            
        }
    }
}
