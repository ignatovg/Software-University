using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.SoftUniCoffeeOrders
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());

            decimal total = 0m;

            for (int i = 0; i < n; i++)
            {
                decimal pricePerCapsule=decimal.Parse(Console.ReadLine());
                DateTime date=DateTime.ParseExact(Console.ReadLine(),"d/M/yyyy",
                    CultureInfo.InvariantCulture);
                decimal capsulesCount=decimal.Parse(Console.ReadLine());
                
                int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
                decimal price = (daysInMonth * capsulesCount) * pricePerCapsule;

                Console.WriteLine($"The price for the coffee is: ${price:f2}");

                total += price;
            }
            Console.WriteLine($"Total: ${total:f2}");
        }
    }
}
