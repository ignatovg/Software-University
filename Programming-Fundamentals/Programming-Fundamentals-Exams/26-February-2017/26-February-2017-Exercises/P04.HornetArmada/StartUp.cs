using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.HornetArmada
{

    class StartUp
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, long>> legionSoldiers = new Dictionary<string, Dictionary<string, long>>();

            Dictionary<string, long> legionActivities = new Dictionary<string, long>();


            for (long i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(new string[] { " = ", " -> ", ":" },
                    StringSplitOptions.RemoveEmptyEntries);

                long activity = long.Parse(inputArgs[0]);
                string legion = inputArgs[1];
                string soldier = inputArgs[2];
                long count = long.Parse(inputArgs[3]);


                if (!legionActivities.ContainsKey(legion))
                {
                    legionActivities.Add(legion, activity);
                }
                else
                {
                    if (activity > legionActivities[legion])
                    {
                        legionActivities[legion] = activity;
                    }
                }

                if (!legionSoldiers.ContainsKey(legion))
                {
                    legionSoldiers.Add(legion, new Dictionary<string, long>());
                }
                if (!legionSoldiers[legion].ContainsKey(soldier))
                {
                    legionSoldiers[legion].Add(soldier, 0);
                }
                
                legionSoldiers[legion][soldier] += count;

            }

            string[] prlongArgs = Console.ReadLine().Split('\\');

            if (prlongArgs.Length > 1)
            {
                long activity = long.Parse(prlongArgs[0]);
                string soldier = prlongArgs[1];

                foreach (var legion in legionSoldiers
                    .Where(legion=> legion.Value.ContainsKey(soldier))
                    .Where(legion => legionActivities[legion.Key] < activity)
                    .OrderByDescending(legion => legion.Value[soldier]))

                {
                    Console.WriteLine($"{legion.Key} -> {legion.Value[soldier]}");

                }
            }
            else
            {
                string soldier = prlongArgs[0];

                foreach (var legion in legionActivities
                    .Where(legion => legionSoldiers[legion.Key].ContainsKey(soldier))
                    .OrderByDescending(legion => legion.Value))
                {
                    Console.WriteLine($"{legionActivities[legion.Key]} : {legion.Key}");

                }
            }
        }
    }
}
