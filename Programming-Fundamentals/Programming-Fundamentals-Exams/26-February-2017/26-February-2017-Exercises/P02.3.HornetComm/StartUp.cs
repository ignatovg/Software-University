using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02._3.HornetComm
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var beehives = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var hornets = Console.ReadLine().Split(' ').Select(int.Parse).ToList();


            while (true)
            {
                int hornetsSum = hornets.Sum();
                int firstBeehive = beehives.First();

                if (hornetsSum == firstBeehive)
                {
                    
                }
                else if (hornetsSum > firstBeehive)
                {
                    beehives.RemoveAt(0);
                }
                else if(hornetsSum <= firstBeehive)
                {
                    int rem = firstBeehive - hornetsSum;
                    beehives[0] = rem;
                    hornets.Clear();
                }
                
             

                if (beehives.Count == 0)
                {
                    Console.WriteLine(string.Join(" ",hornets));
                    break;
                }
                else if (hornets.Count == 0)
                {
                    Console.WriteLine(string.Join(" ",beehives));
                    break;
                }
            }
        }
    }
}
