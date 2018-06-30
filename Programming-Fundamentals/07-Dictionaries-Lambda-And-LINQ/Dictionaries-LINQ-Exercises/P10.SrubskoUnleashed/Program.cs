using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P10.SrubskoUnleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();
            var performance=new Dictionary<string,Dictionary<string,long>>();
            while (line!="End")
            {
                var tokens = line.Split('@');
                if (tokens.Length != 2)
                {
                    line = Console.ReadLine();
                    continue;
                }

                if (!tokens[0].EndsWith(" "))
                {
                    line = Console.ReadLine();
                    continue;
                }

                var rightSide = tokens[1].Split(' ');
                if (rightSide.Length < 3)
                {
                    line = Console.ReadLine();
                    continue;
                }
                long ticketPrice;
                long ticketCount;

                if (!long.TryParse(rightSide[rightSide.Length - 1], out ticketPrice))
                {
                    line = Console.ReadLine();
                    continue;
                }

                if (!long.TryParse(rightSide[rightSide.Length - 2], out ticketCount))
                {
                    line = Console.ReadLine();
                    continue;
                }

                var singer=tokens[0].Trim();
                var value = "";
                long totalPrice = ticketPrice * ticketCount;
                for (int i = 0; i < rightSide.Length-2; i++)
                {
                    value += rightSide[i] + " ";
                }
                value.Trim();

                if (!performance.ContainsKey(value))
                {
                    performance[value]=new Dictionary<string, long>();
                }
                if (!performance[value].ContainsKey(singer))
                {
                    performance[value][singer] = 0;
                }
                performance[value][singer] += totalPrice;

                line = Console.ReadLine();
            }

            foreach (var valueAndSingers in performance)
            {
                var value = valueAndSingers.Key;
                var singes = valueAndSingers.Value;

                Console.WriteLine(value);
                foreach (var singerAndPrice in singes.OrderByDescending(s=>s.Value))
                {
                    var singer = singerAndPrice.Key;
                    var totalPrice = singerAndPrice.Value;

                    Console.WriteLine($"#  {singer} -> {totalPrice}");
                }
            }
        }
    }
}
