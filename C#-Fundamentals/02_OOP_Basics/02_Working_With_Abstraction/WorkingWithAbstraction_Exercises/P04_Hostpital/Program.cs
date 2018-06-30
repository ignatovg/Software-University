using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] tokens = command.Split();
                var department = tokens[0];
                var fullName = tokens[1] + tokens[2];
                var patient = tokens[3];

                if (!doctors.ContainsKey(fullName))
                {
                    doctors[fullName] = new List<string>();
                }

                if (!departments.ContainsKey(department))
                {
                    departments[department] = new List<List<string>>();
                    for (int rooms = 0; rooms < 20; rooms++)
                    {
                        departments[department].Add(new List<string>());
                    }
                }

                bool isEmpty = departments[department].SelectMany(x => x).Count() < 60;
                if (isEmpty)
                {
                    int room = 0;
                    doctors[fullName].Add(patient);
                    for (int roomCount = 0; roomCount < departments[department].Count; roomCount++)
                    {
                        if (departments[department][roomCount].Count < 3)
                        {
                            room = roomCount;
                            break;
                        }
                    }
                    departments[department][room].Add(patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int room))
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]][room - 1].OrderBy(x => x)));
                }
                else
                {
                    Console.WriteLine(string.Join("\n", doctors[args[0] + args[1]].OrderBy(x => x)));
                }
                command = Console.ReadLine();
            }
        }
    }
}
