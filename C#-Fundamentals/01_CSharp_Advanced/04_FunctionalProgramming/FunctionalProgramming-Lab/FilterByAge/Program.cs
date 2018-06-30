using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
           var peopleCount = int.Parse(Console.ReadLine());
            var people = new Dictionary<string,int>(peopleCount);
            for (int counter = 0; counter < peopleCount; counter++)
            {
                var nameAndAge = Console.ReadLine()
                    .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);
                people.Add(nameAndAge[0],int.Parse(nameAndAge[1]));
            }
            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();
            var filter = CreateFilter(condition, age);
            var priter = CreatePrinter(format);
            foreach (var person in people)
            {
                if (filter(person.Value))
                {
                    priter(person);
                }
            }
           
        }

        static Func<int, bool> CreateFilter(string condition, int age)
        {
            if (condition == "younget")
                return x => x < age;
            else
                return x => x >= age;

        }

        static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return x => Console.WriteLine(x.Key);
                case "age":
                    return x => Console.WriteLine(x.Value);
                case "name age":
                    return x => Console.WriteLine($"{x.Key} - {x.Value}");
                default:
                    throw new NotImplementedException();

            }
        }
    }
}
