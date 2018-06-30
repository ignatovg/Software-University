using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.ChangeList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            
            string[] commands = Console.ReadLine().Split(' ');
            while (true)
            {

                if (commands[0]=="Odd")
                {
                    Console.WriteLine(string.Join(" ", numbers.Where(a => a % 2 != 0).ToList()));
                    break;
                }
                else if(commands[0] == "Even")
                {
                    Console.WriteLine(string.Join(" ", numbers.Where(a => a % 2 == 0).ToList()));
                    break;
                }

                if (commands[0] == "Delete")
                {
                    int element = int.Parse(commands[1]);
                    numbers.RemoveAll(a => a == element);
                }
                else if (commands[0] == "Insert")
                {
                    int element = int.Parse(commands[1]);
                    int possition = int.Parse(commands[2]);
                    numbers.Insert(possition,element);
                }

                commands = Console.ReadLine().Split(' ');
            }

          
        }
    }
}
