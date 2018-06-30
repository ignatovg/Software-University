using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07.SalesReport
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            Sale[] sales=new Sale[n];

            for (int i = 0; i < n; i++)
            {
                sales[i] = ReadSale();
            }

            var towns = sales.Select(s => s.Town).Distinct().OrderBy(t => t);
            
            foreach (var town in towns)
            {
                var selesByTown = sales.Where(s => s.Town == town)
                    .Select(s => s.Price * s.Quantity);
                
                Console.WriteLine($"{town} -> {selesByTown.Sum():f2}");
            }
        }

        private static Sale ReadSale()
        {
            string[] saleInfo = Console.ReadLine().Split(' ');

            Sale sale = new Sale
            {
                Town = saleInfo[0],
                Product = saleInfo[1],
                Price = double.Parse(saleInfo[2]),
                Quantity = double.Parse(saleInfo[3])
            };

            return sale;
        }
    }

    class Sale
    {
        public string Town { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
    }
}
