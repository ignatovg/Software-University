using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beverage_Labes
{
    class BeverageLabes
    {
        static void Main(string[] args)
        {
            string beverageName = Console.ReadLine();
            int volumeInMl = int.Parse(Console.ReadLine());
            int energyInKcal = int.Parse(Console.ReadLine());
            int sugar = int.Parse(Console.ReadLine());

            double calculatedEnergy = ((volumeInMl) * energyInKcal) / 100.0;
            double calculatedSugar = (volumeInMl * sugar) / 100.0;
            Console.WriteLine($"{volumeInMl}ml {beverageName}:");
            Console.WriteLine($"{calculatedEnergy}kcal, {calculatedSugar}g sugars");

        }
    }
}
