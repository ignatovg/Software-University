using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.RandomizeWords
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            Random rnd=new Random();

            for (int i = 0; i < input.Length; i++)
            {
                int index = rnd.Next(0, input.Length);
                string rem = input[index];
                int newindex=rnd.Next(0,input.Length);
                input[index] = input[newindex];
                input[newindex] = rem;
            }

            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine(input[i]);
            }
        }
    }
}
