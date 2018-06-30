using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07.MultiplyBigNumber
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());

            var sb = new StringBuilder();

            int reminder = 0;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                if (multiplier == 0)
                {
                    Console.WriteLine("0");
                    return;
                }
                else if (multiplier == 1)
                {
                    sb.Append(number);
                    break;
                }

                int product = reminder +
                              int.Parse(number[i].ToString()) * multiplier;

                int digit = product % 10;
                sb.Insert(0, digit);

                reminder = product / 10;

                if (i == 0 && reminder != 0)
                {
                    sb.Insert(0, reminder);
                }
            }

            string result = sb.ToString().TrimStart('0');
            Console.WriteLine(result);
        }

        
    }
}
