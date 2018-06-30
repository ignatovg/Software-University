using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_SortPersonsByNameAndAge
{
    class Program
    {
        static void Main(string[] args)
        {
            Team team = new Team("SoftUni");

            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                try
                {
                    var cmdArgs = Console.ReadLine().Split();
                    Person person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]),
                        decimal.Parse(cmdArgs[3]));
                    team.AddPlayer(person);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    //throw;
                }
            }
            
            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");

            //team.FirstTeam.First().FirstName = "adasdas";
            Console.WriteLine($"First team first player: {team.FirstTeam.First()}");
            Console.WriteLine($"Reserve team first player: {team.ReserveTeam.First()}");
        }
    }
}
