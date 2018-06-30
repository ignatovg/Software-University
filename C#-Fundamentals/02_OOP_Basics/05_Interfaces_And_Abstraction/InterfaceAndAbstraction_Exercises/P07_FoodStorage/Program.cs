using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace P07_FoodStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();

            int NLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < NLines; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                if (tokens.Length == 4)
                {
                    //read Citizen
                    Citizen citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]);
                    buyers.Add(citizen);
                }
                else if (tokens.Length == 3)
                {
                    //read Rabel
                    Rabel rabel = new Rabel(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    buyers.Add(rabel);
                }
            }
            string readNames = string.Empty;
            while ((readNames = Console.ReadLine()) != "End")
            {
                if (readNames.Split().Length != 1)
                {
                    continue;
                }

                foreach (IBuyer buyer in buyers)
                {
                    if (buyer.Name == readNames)
                    {
                        buyer.BuyFood();
                        break;
                    }
                }
            }

            int totalFood = buyers.Select(s => s.Food).Sum();
            Console.WriteLine(totalFood);
           
        }
    }
}
