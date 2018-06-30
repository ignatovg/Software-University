using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighbourWars
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //– Gosho attacks with “Thunderous fist” on every even turn  
            //and Pesho attacks with “Roundhouse kick” on every odd turn

            int peshosDamage = int.Parse(Console.ReadLine());
            int goshosDamage = int.Parse(Console.ReadLine());

            int peshosHealth = 100;
            int goshosHealth = 100;
            int thirdRound = 3;
            for (int i = 1; true; i++)
            {
                if (i % 2 != 0)
                {
                    goshosHealth -= peshosDamage;

                    if (goshosHealth <= 0)
                    {
                        Console.WriteLine($"Pesho won in {i}th round.");
                        return;
                    }
                    Console.WriteLine($"Pesho used Roundhouse kick and reduced Gosho to {goshosHealth} health.");
                }
                else
                {
                    peshosHealth -= goshosDamage;

                    if (peshosHealth <= 0)
                    {
                        Console.WriteLine($"Gosho won in {i}th round.");
                        return;
                    }
                    Console.WriteLine($"Gosho used Thunderous fist and reduced Pesho to {peshosHealth} health.");
                }
                if (i == thirdRound)
                {
                    goshosHealth += 10;
                    peshosHealth += 10;
                    thirdRound += 3;
                }

            }
        }
    }
}
