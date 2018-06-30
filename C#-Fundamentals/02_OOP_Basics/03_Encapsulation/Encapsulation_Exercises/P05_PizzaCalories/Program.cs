using System;
using System.Linq;

namespace P05_PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] nameOfPizza = Console.ReadLine().Split();
                Pizza pizza = new Pizza(nameOfPizza[1]);

                string command = string.Empty;
                while ((command=Console.ReadLine())!= "END")
                {
                    string[] tokens = command.Split();
                    string ingredient = tokens[0].ToLower();
                    if (ingredient == "dough")
                    {
                        string flourType = tokens[1].ToLower();
                        string technique = tokens[2].ToLower();
                        double weight = double.Parse(tokens[3]);
                        Dough dough = new Dough(flourType,technique,weight);

                       
                        double totalCalories = dough.CalculateCalories();
                        //Console.WriteLine($"{totalCalories:f2}");

                        pizza.Dough = dough;
                        pizza.AddCalories(totalCalories);
                    }
                    else if (ingredient == "topping")
                    {
                        string toppingType = tokens[1];
                        double weight = double.Parse(tokens[2]);

                        Topping topping = new Topping(toppingType,weight);

                        double totalCalories = topping.CalcualteCalories();
                       // Console.WriteLine($"{totalCalories:f2}");

                        pizza.AddTopping(topping);
                        pizza.AddCalories(totalCalories);
                      
                    }
                }
                Console.WriteLine(pizza.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
