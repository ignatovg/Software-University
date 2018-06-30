using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.SumBigNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();

            if (first.Length > second.Length)
            {
                second = second.PadLeft(first.Length, '0');
            }
            else
            {
                first = first.PadLeft(second.Length, '0');
            }

            StringBuilder sb = new StringBuilder();
            var sum = 0;
            var number = 0;
            var reminder = 0;

            for (int i = first.Length - 1; i >= 0; i--)
            {
                sum = (first[i] - '0') + (second[i] - '0') + reminder;
                number = sum % 10;
                sb.Append(number);

                reminder = sum / 10;

                if (i == 0 && reminder>0)
                {
                    sb.Append(reminder);
                }
            }
            
            Console.WriteLine(Reverse(sb).TrimStart('0'));
        }

        private static string Reverse(StringBuilder str)
        {
            StringBuilder reversedStr = new StringBuilder(str.Length);

            for (int i = str.Length - 1; i >= 0; i--)
            {
                reversedStr.Append(str[i]);
            }

            return reversedStr.ToString();
        }
    }
}
