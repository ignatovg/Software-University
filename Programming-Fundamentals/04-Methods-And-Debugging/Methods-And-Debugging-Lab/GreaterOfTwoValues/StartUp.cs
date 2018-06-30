using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreaterOfTwoValues
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string intputVar = Console.ReadLine();

            if (intputVar == "int")
            {
                int num1=int.Parse(Console.ReadLine());
                int num2=int.Parse(Console.ReadLine());
                GetMax(num1, num2);
            }
            else if(intputVar=="char")
            {
                char letter1=char.Parse(Console.ReadLine());
                char letter2=char.Parse(Console.ReadLine());
                GetMax(letter1,letter2);
            }
            else if (intputVar == "string")
            {
                string str1 = Console.ReadLine();
                string str2= Console.ReadLine();
                GetMax(str1,str2);
            }
        }

        private static void GetMax(int num1, int num2)
        {
            Console.WriteLine(Math.Max(num1,num2));
        }

        private static void GetMax(char letter1, char letter2)
        {
            Console.WriteLine((char)(Math.Max(letter1,letter2)));
        }

        private static void GetMax(string str1, string str2)
        {
            if (string.Compare(str1, str2) == -1)
            {
                Console.WriteLine(str2);
            }
            else if (string.Compare(str1, str2) == 1)
            {
                Console.WriteLine(str1);
            }
            else
            {
                Console.WriteLine(str1);
            }
        }

    }
}
