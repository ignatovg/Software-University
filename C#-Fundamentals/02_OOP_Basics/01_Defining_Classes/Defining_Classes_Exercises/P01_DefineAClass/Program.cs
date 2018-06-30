using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_DefineAClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Family family = new Family();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputPerson = Console.ReadLine().Split(' ').ToArray();
                string name = inputPerson[0];
                int age = int.Parse(inputPerson[1]);

                Person person = new Person{Name = name,Age = age};
                family.AddMember(person);
            }
            Person oldestPerson = family.GetOldestMember();
            Console.WriteLine(oldestPerson);
        }
    }
}
