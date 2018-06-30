using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeIngredients
{
    class CakeIngredients
    {
        static void Main(string[] args)
        {
            string ingredient = Console.ReadLine();
            int countOfIngredients = 0;

            while (ingredient != "Bake!")
            {
                Console.WriteLine($"Adding ingredient {ingredient}.");
                countOfIngredients++;

                ingredient = Console.ReadLine();
            }
            Console.WriteLine($"Preparing cake with {countOfIngredients} ingredients.");
        }
    }
}
