using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDiscount
{
    class RestaurantDiscount
    {
        static void Main(string[] args)
        {

            int cntOfPeople = int.Parse(Console.ReadLine());
            string packege = Console.ReadLine();
            double price = 0.0;

            if (cntOfPeople <= 50)
            {
                price += 2500;
                Console.WriteLine("We can offer you the Small Hall");
            }
            else if (cntOfPeople > 50 && cntOfPeople <= 100)
            {
                price += 5000;
                Console.WriteLine("We can offer you the Terrace");
            }
            else if (cntOfPeople > 100 && cntOfPeople <= 120)
            {
                price += 7500;
                Console.WriteLine("We can offer you the Great Hall");
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
                return;
            }

            switch (packege)
            {
                case "Normal":
                    price += 500;
                    price = price - price * 0.05;
                    break;

                case "Gold":
                    price += 750;
                    price = price - price * 0.10;
                    break;

                case "Platinum":
                    price += 1000;
                    price = price - price * 0.15;
                    break;
            }
            double perPerson = price / cntOfPeople;
            Console.WriteLine($"The price per person is {perPerson:f2}$");

        }
    }
}
