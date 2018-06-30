using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace P01.AnonymousDownsite
{
    class Program
    {
        static void Main(string[] args)
        {
            int n= int.Parse(Console.ReadLine());
            int securityKey = int.Parse(Console.ReadLine());

            decimal sumOflosses = 0m;
            for (int i = 0; i < n; i++)
            {
                string[] dataTokens = Console.ReadLine().Split(' ');
                string siteName = dataTokens[0];
                decimal siteVisits = decimal.Parse(dataTokens[1]);
                decimal siteCommercialPricePerVisit = decimal.Parse(dataTokens[2]);

                decimal siteLoss= siteVisits* siteCommercialPricePerVisit;
                sumOflosses += siteLoss;
                Console.WriteLine(siteName);
            }
            BigInteger result = 1;
            for (int i = 0; i < n; i++)
            {
                result *= securityKey;
            }
            Console.WriteLine($"Total Loss: {sumOflosses:f20}");
            Console.WriteLine($"Security Token: {result}");
        }
    }
}
