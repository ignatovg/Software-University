using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace P04.CodePhoenixRomeo
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string,List<string>> creatures = new Dictionary<string, List<string>>();

            string inputLine = string.Empty;
            while ((inputLine=Console.ReadLine()) != "Blaze it!")
            {
                string[] tokens = inputLine.Split(new string[] {" -> "},
                    StringSplitOptions.RemoveEmptyEntries);
                string creature = tokens[0];
                string squadMate = tokens[1];

                if (!creatures.ContainsKey(creature))
                {
                    creatures.Add(creature,new List<string>());
                    creatures[creature].Add(squadMate);
                }
                else
                {
                    if (creatures[creature].Any(a=>a==squadMate))
                    {
                        continue;
                    }
                    if (creature == squadMate)
                    {
                        continue;
                    }
                    creatures[creature].Add(squadMate);
                }
                
            }
            Dictionary<string,int> data=new Dictionary<string, int>();

            foreach (var creature in creatures)
            {
                string name = creature.Key;
                List<string> squardmates = creature.Value;
                int count = squardmates.Count;

                Console.WriteLine($"{name} -> {string.Join(", ",squardmates)}");

                data[creature.Key] = count;
                foreach (var creaturesKey in creatures.Keys)
                {
                    if (squardmates.Any(a => a == creaturesKey))
                    {
                        data[creature.Key] = --count;
                    }
                }
            }
            foreach (var pair in data.OrderByDescending(a=>a.Value))
            {
                Console.WriteLine($"{pair.Key} : {pair.Value}");
            }
        }
        
    }
}
