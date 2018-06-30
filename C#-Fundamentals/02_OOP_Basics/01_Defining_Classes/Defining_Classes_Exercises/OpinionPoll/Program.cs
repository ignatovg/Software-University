using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OpinionPoll
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputLine = Console.ReadLine().Split(' ').ToArray();
                string name = inputLine[0];
                int age = int.Parse(inputLine[1]);

                Person person = new Person{Name = name, Age = age};
                persons.Add(person);
            }

            foreach (Person person in persons.Where(a=>a.Age>30).OrderBy(a=>a.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
