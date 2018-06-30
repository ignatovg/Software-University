using System;
using System.Collections.Generic;
using System.Linq;

namespace P10_PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine()
                .Split(' ').ToList();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Party!")
            {
                people = FilterGuests(command, people);
            }
            var result = string.Join(", ", people);
            var isGoing = result.Length==0? "Nobody is going to the party!":" are going to the party!";

            Console.WriteLine($"{result}{isGoing}");
        }

        private static List<string> FilterGuests(string commandArgs, List<string> people)
        {
            string[] tokens = commandArgs.Split(' ');
            string comamnd = tokens[0];
            string criteria = tokens[1];
            List<string> guests = new List<string>();
            guests.AddRange(people);

            Func<string, string, bool> startWithFilter = (str, word) => str.Contains(word);
            Func<string, string, bool> endsWithFilter = (str, word) => str.EndsWith(word);
            Func<string, int, bool> lenghtFilter = (str, len) => str.Length == len;

            if (comamnd == "Double")
            {
                if (criteria == "StartsWith")
                {
                    string word = tokens[2];

                    return GetValue(people, startWithFilter, word);
                }
                else if (criteria == "EndsWith")
                {
                    string word = tokens[2];

                    return GetValue(people, endsWithFilter, word);
                }
                else if (criteria == "Length")
                {
                    int lenStr = int.Parse(tokens[2]);

                    foreach (var person in people)
                    {
                        if (lenghtFilter(person, lenStr))
                        {
                            int index = people.IndexOf(person);
                            guests.Insert(index, person);
                        }
                    }
                    return guests;
                }
            }
            else if (comamnd == "Remove")
            {
                if (criteria == "StartsWith")
                {
                    string word = tokens[2];
                    guests.RemoveAll(str => startWithFilter(str, word));
                    return guests;
                }
                else if (criteria == "EndsWith")
                {
                    string word = tokens[2];
                    guests.RemoveAll(str => endsWithFilter(str, word));
                    return guests;
                }
                else if (criteria == "Length")
                {
                    int lenStr = int.Parse(tokens[2]);
                    guests.RemoveAll(str => lenghtFilter(str, lenStr));
                    return guests;
                }
            }

            throw new NotImplementedException();
        }

        private static List<string> GetValue(List<string> people, Func<string, string, bool> filter, string word)
        {
            List<string> guests = new List<string>();
            guests.AddRange(people);

            foreach (var person in people)
            {
                if (filter(person, word))
                {
                    int index = people.IndexOf(person);
                    guests.Insert(index, person);
                }
            }
            return guests;
        }
    }
}
