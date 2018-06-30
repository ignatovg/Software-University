using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            long capacity = long.Parse(Console.ReadLine());
            string[] safeInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();

            long gold = 0;
            long gems = 0;
            long money = 0;

            for (int i = 0; i < safeInput.Length; i += 2)
            {
                string name = safeInput[i];
                long amount = long.Parse(safeInput[i + 1]);

                string treasureName = "";

                treasureName = GetTreasureName(name, treasureName);
                
                if (treasureName == "")
                {
                    continue;
                }
                else if (capacity < bag.Values.Select(x => x.Values.Sum()).Sum() + amount)
                {
                    continue;
                }

                switch (treasureName)
                {
                    case "Gem":
                        if (!IsAddedTreasure(bag,treasureName,"Gold",amount))
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!IsAddedTreasure(bag, treasureName, "Gem", amount))
                        {
                            continue;
                        }
                        break;
                }

                if (!bag.ContainsKey(treasureName))
                {
                    bag[treasureName] = new Dictionary<string, long>();
                }

                if (!bag[treasureName].ContainsKey(name))
                {
                    bag[treasureName][name] = 0;
                }

                bag[treasureName][name] += amount;
                if (treasureName == "Gold")
                {
                    gold += amount;
                }
                else if (treasureName == "Gem")
                {
                    gems += amount;
                }
                else if (treasureName == "Cash")
                {
                    money += amount;
                }
            }

            PrintContent(bag);
        }

        private static bool IsAddedTreasure(Dictionary<string,Dictionary<string,long>> bag, string currentTreasure,string treasureName, long amount)
        {
            if (!bag.ContainsKey(currentTreasure))
            {
                if (bag.ContainsKey(treasureName))
                {
                    if (IsAmountMore(amount, bag, treasureName))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else if (bag[currentTreasure].Values.Sum() + amount > bag[treasureName].Values.Sum())
            {
                return false;
            }

            return true;
        }
        private static string GetTreasureName(string name, string treasureName)
        {
            if (name.Length == 3)
            {
                treasureName = "Cash";
            }
            else if (name.ToLower().EndsWith("gem"))
            {
                treasureName = "Gem";
            }
            else if (name.ToLower() == "gold")
            {
                treasureName = "Gold";
            }
            else
            {
                treasureName = "";
            }
            return treasureName;
        }

        private static void PrintContent(Dictionary<string, Dictionary<string, long>> bag)
        {
            foreach (var x in bag)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }

        private static bool IsAmountMore(long amount, Dictionary<string, Dictionary<string, long>> bag, string treasure)
        {
            return amount > bag[treasure].Values.Sum();
        }
    }
}