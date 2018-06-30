using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P09.LegendaryFarming
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, int> junks = new Dictionary<string, int>();

            int shadowmourne = 250;
            int valanyr = 250;
            int dragonwrath = 250;
            bool isObtained = false;
            List<string> tokens = input.ToLower().Split(' ').ToList();
            while (true)
            {
                if (isObtained)
                {
                    break;
                }

                if (tokens.Count == 0)
                {
                    input = Console.ReadLine();
                    tokens = input.ToLower().Split(' ').ToList();
                }

                string material = tokens[1];
                int quantity = int.Parse(tokens[0]);

                if (material == "shards")
                {
                    shadowmourne -= quantity;
                    quantity %= 250;
                   
                    if (shadowmourne <= 0)
                    {
                        isObtained = true;
                        Console.WriteLine("Shadowmourne obtained!");
                    }
                }
                else if (material == "fragments")
                {
                    valanyr -= quantity;
                    quantity %= 250;
                    if (valanyr <= 0)
                    {
                        Console.WriteLine("Valanyr obtained!");
                        isObtained = true;
                    }
                }
                else if (material == "motes")
                {
                    dragonwrath -= quantity;
                    quantity %= 250;
                    if (dragonwrath <= 0)
                    {
                        Console.WriteLine("Dragonwrath obtained!");
                        isObtained = true;
                    }
                }

                if (!junks.ContainsKey(material))
                {
                    junks.Add(material, quantity);
                }
                else
                {
                    junks[material] += quantity;
                }

                tokens.RemoveRange(0, 2);

            }
            foreach (var junk in junks.OrderByDescending(x=>x.Value))
            {
                Console.WriteLine($"{junk.Key}: {junk.Value}");
            }
        }
    }
}

