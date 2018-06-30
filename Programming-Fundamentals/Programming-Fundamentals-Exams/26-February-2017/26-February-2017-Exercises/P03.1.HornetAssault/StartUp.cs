using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03._1.HornetAssault
{
    class StartUp
    {
        static void Main(string[] args)
        {
            long[] beehive = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            List<long> hornets = Console.ReadLine().Split(' ').Select(long.Parse).ToList();

            for (int i = 0; i < beehive.Length; i++)
            {
                if (hornets.Count == 0)
                {
                    break;
                }

                long behiveCount = beehive[i];

                long hornetPower = SumHornetsPower(hornets);

                beehive[i] -= hornetPower;

                if (behiveCount >= hornetPower)
                {
                    hornets.RemoveAt(0);
                }
            }

            //PrintWinnigSide(beehive, hornets);

            if (beehive.Any(bh => bh > 0))
            {
                Console.WriteLine(string.Join(" ",beehive.Where(bh=>bh>0)));
            }
            else
            {
                Console.WriteLine(string.Join(" ",hornets));
            }
        }

        private static void PrintWinnigSide(long[] beehives, List<long> hornets)
        {
            List<long> aliveBeehives=new List<long>();

            foreach (var beehive in beehives)
            {
                if (beehive > 0)
                {
                    aliveBeehives.Add(beehive);
                }
            }

            if (aliveBeehives.Count > 0)
            {
                Console.WriteLine(string.Join(" ", aliveBeehives));
            }
            else
            {
                Console.WriteLine(string.Join(" ", hornets));
            }
        }

        private static long SumHornetsPower(List<long> hornets)
        {
            long sum = 0;

            foreach (var hornet in hornets)
            {
                sum += hornet;
            }
            return sum;
        }
    }
}
