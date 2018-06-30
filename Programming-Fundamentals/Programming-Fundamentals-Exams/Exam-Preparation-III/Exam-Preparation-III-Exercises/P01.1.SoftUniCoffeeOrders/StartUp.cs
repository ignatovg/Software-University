using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01._1.SoftUniCoffeeOrders
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());

            decimal totalPrice = 0;

            for (int i = 0; i < n; i++)
            {
               decimal price = ReadOrderAndCalculatePrice();
               totalPrice += price;
            }

            Console.WriteLine($"Total: ${totalPrice:f2}");
        }

        private static decimal ReadOrderAndCalculatePrice()
        {
           decimal pricePerCapsule= decimal.Parse(Console.ReadLine());
           DateTime data= DateTime.ParseExact(Console.ReadLine(),"d/M/yyyy",
               CultureInfo.InvariantCulture);
            decimal daysInMonth = DateTime.DaysInMonth(data.Year, data.Month);

            decimal capsulesCount = decimal.Parse(Console.ReadLine());

            decimal price = (daysInMonth * capsulesCount) * pricePerCapsule;

            Console.WriteLine($"The price for the coffee is: ${price:f2}");

            return price;
        }
    }
}
