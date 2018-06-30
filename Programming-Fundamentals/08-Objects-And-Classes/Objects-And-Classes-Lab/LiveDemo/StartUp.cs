using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveDemo
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(rnd.Next(100,200));
            }

            

        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }


        public void SayHello()
        {
            Console.WriteLine("Hello!");
        }
    }
}
