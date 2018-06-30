using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseADrink
{
    class ChooseADrink
    {
        static void Main(string[] args)
        {
            string profession = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            if (profession == "Athlete")
            {

                quantity *= 0.70;
            }
            else if (profession == "Businessman" || profession == "Businesswoman")
            {

                quantity *= 1;
            }
            else if (profession == "SoftUni Student")
            {

                quantity *= 1.70;
            }
            else
            {

                quantity *= 1.20;
            }
            Console.WriteLine($"The {profession} has to pay {quantity:f2}.");
        }
    }
}
