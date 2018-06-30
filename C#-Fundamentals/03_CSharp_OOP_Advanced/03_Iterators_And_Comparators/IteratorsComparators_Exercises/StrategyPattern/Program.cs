using System;
using System.Collections.Generic;
using System.Linq;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> namePeople = new SortedSet<Person>(new PersonNameComparer());
            SortedSet<Person> agePeople = new SortedSet<Person>(new PersonAgeComparer());

            int nLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < nLines; i++)
            {
                string[] commandArgs = Console.ReadLine().Split();
                string name = commandArgs[0];
                int age = int.Parse(commandArgs[1]);

                Person person = new Person(name, age);
                namePeople.Add(person);
                agePeople.Add(person);
            }

            Console.WriteLine(string.Join(Environment.NewLine, namePeople));
            Console.WriteLine(string.Join(Environment.NewLine, agePeople));

        }
    }
}
