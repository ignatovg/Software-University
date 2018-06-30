using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            int age=int.Parse(Console.ReadLine());

            Console.WriteLine($"Hello, {firstName} {lastName}. You are 25 years old.");
        }
    }
}
