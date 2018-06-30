using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.CompilerServices;

namespace P04_Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> hospitalList = new List<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Output")
            {
                hospitalList.Add(input);
            }


            List<string> commands = new List<string>();
            string commandArgs = string.Empty;

            while ((commandArgs = Console.ReadLine()) != "End")
            {
                commands.Add(commandArgs);
            }


             foreach (var command in commands)
            {
                string[] tokens = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                var rooms = -7;



                if (tokens.Length == 1)
                {
                    //department

                    var departmentList = hospitalList.Where(s => s.StartsWith(command)).ToArray();

                    for (int i = 0; i < departmentList.Length; i++)
                    {
                        Console.WriteLine(departmentList[i].Split(' ')[3]);
                    }
                }
                else if (int.TryParse(tokens[1], out rooms))
                {
                    //department room
                    var departmentList = hospitalList.Where(s => s.StartsWith(command[0])).ToArray();

                    var healedPacients = new List<string>();

                    for (int i = 0; i < departmentList.Length; i++)
                    {
                        healedPacients.Add(departmentList[i].Split(' ')[3]);
                    }
                    var currentRoom = healedPacients.Skip((rooms - 1) * 3).OrderBy(a => a).ToList();
                    Console.WriteLine(string.Join("\n", currentRoom));
                }
                else if (rooms == 0)
                {
                    //doctor 

                    var doctorsList = hospitalList.Where(s => s.Contains(command)).ToArray();
                    var healedPacients = new List<string>();

                    for (int i = 0; i < doctorsList.Length; i++)
                    {
                        healedPacients.Add(doctorsList[i].Split(' ')[3]);
                    }

                    healedPacients.OrderBy(a => a).ToList().ForEach(a => Console.WriteLine(a));
                }
            }

        }

    }
}
