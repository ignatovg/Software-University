using System;
using System.Collections.Generic;
using System.Linq;

namespace P11_PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine().Split(' ').ToList();
            var command = string.Empty;

            var filters = new Dictionary<string, Func<List<string>, List<string>>>();
            while ((command = Console.ReadLine()) != "Print")
            {
                ParceCommand(command, filters);
            }
            var filtered = GetFiltered(people, filters);

            people = people.Where(ppl => !filtered.Contains(ppl)).ToList();

            string result = string.Join(" ", people);
            Console.WriteLine(result);
        }

        private static List<string> GetFiltered(List<string> people, Dictionary<string, Func<List<string>, List<string>>> filters)
        {
            List<string> filtered = new List<string>();

            foreach (var pair in filters)
            {
                var filter = pair.Value;
                filtered.AddRange(filter(people));
            }
            return filtered;
        }

        private static void ParceCommand(string commandInput, Dictionary<string, Func<List<string>, List<string>>> filters)
        {
            string[] tokens = commandInput.Split(';');
            string command = tokens[0];
            string filterType = tokens[1];
            string parameter = tokens[2];
            string dictKey = $"{filterType} {parameter}";

            if (command == "Add filter")
            {
                filters[dictKey] = CreateFunction(filterType, parameter);
            }
            else if (command == "Remove filter")
            {
                filters.Remove(dictKey);
            }
        }

        private static Func<List<string>, List<string>> CreateFunction(string filterType, string parameter)
        {
            switch (filterType)
            {
                case "Starts with":
                    return names => names.Where(n => n.StartsWith(parameter)).ToList();

                case "Ends with":
                    return names => names.Where(n => n.EndsWith(parameter)).ToList();

                case "Length":
                    int len = int.Parse(parameter);
                    return names => names.Where(n => n.Length == len).ToList();
                case "Contains":
                    return names => names.Where(n => n.Contains(parameter)).ToList();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
