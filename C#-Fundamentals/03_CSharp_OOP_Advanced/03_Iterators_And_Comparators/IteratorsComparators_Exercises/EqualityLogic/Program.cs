using System;
using System.Collections.Generic;
using System.Security;

namespace EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> personSorted = new SortedSet<Person>();
            HashSet<Person> personHash = new HashSet<Person>();

           int nLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < nLines; i++)
            {
                string[] commandArgs = Console.ReadLine().Split();
                string name = commandArgs[0];
                int age = int.Parse(commandArgs[1]);

                Person person = new Person(name, age);
                personSorted.Add(person);
                personHash.Add(person);
            }
            Console.WriteLine(personSorted.Count);
            Console.WriteLine(personHash.Count);
        }
    }
}
