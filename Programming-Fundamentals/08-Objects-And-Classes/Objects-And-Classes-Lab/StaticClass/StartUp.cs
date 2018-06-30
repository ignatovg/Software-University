using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClass
{
    class StartUp
    {
        static void Main(string[] args)
        {
            
            Person.Age = 20;
            Console.WriteLine(Person.Age);

            Personn person=new Personn();
            person.Age = 50;
        }
    }

    public static class Person
    {
        public static int Age = 9;
    }

    public class Personn
    {
        public int Age { get; set; }
    }
}
