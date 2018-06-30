using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Dynamic;

namespace P02_WildFarm
{
    class StartUp
    {
        static void Main(string[] args)
        {
          List<Animal> animals = new List<Animal>();

            string command;
            while ((command=Console.ReadLine())!= "End")
            {
                string[] animalArgs = command.Split();
                string[] foodArgs = Console.ReadLine().Split();

                string animal = animalArgs[0];
                string name = animalArgs[1];
                double weight = double.Parse(animalArgs[2]);

                string foodType = foodArgs[0];
                int foodQuantity = int.Parse(foodArgs[1]);
                
                try
                {
                    if (animal == "Hen" || animal == "Owl")
                    {
                        double wingSize = double.Parse(animalArgs[3]);
                        if (animal == "Hen")
                        {
                            Animal hen = new Hen(name, weight, foodType, foodQuantity, wingSize);
                            Console.WriteLine(hen.ToString());

                            animals.Add(hen);

                            hen.Eat();


                        }
                        else
                        {
                            Animal owl = new Owl(name, weight, foodType, foodQuantity, wingSize);
                            Console.WriteLine(owl.ToString());

                            animals.Add(owl);

                            owl.Eat();

                        }
                    }
                    else if (animal == "Tiger" || animal == "Cat")
                    {
                        string livinRedion = animalArgs[3];
                        string bread = animalArgs[4];
                        if (animal == "Tiger")
                        {
                            Tiger tiger = new Tiger(name, weight, foodType, livinRedion, foodQuantity, bread);
                            Console.WriteLine(tiger.ToString());

                            animals.Add(tiger);

                            tiger.Eat();

                        }
                        else
                        {
                            Cat cat = new Cat(name, weight, foodType, livinRedion, foodQuantity, bread);
                            Console.WriteLine(cat.ToString());

                            animals.Add(cat);

                            cat.Eat();

                        }
                    }
                    else if (animal == "Mouse" || animal == "Dog")
                    {
                        string livingRedion = animalArgs[3];
                        if (animal == "Mouse")
                        {
                            Mouse mouse = new Mouse(name, weight, foodType, livingRedion, foodQuantity);
                            Console.WriteLine(mouse.ToString());

                            animals.Add(mouse);

                            mouse.Eat();

                        }
                        else
                        {
                            Dog dog = new Dog(name, weight, foodType, livingRedion, foodQuantity);
                            Console.WriteLine(dog.ToString());

                            animals.Add(dog);

                            dog.Eat();

                        }
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            foreach (Animal animal in animals)
            {
                if (animal is Bird)
                {
                    var bird = (Bird) animal;
                    Console.WriteLine($"{bird.GetType().Name} [{bird.Name}, {bird.WingSize}, {bird.Weight}, {bird.FoodQuantity}]");
                }
                else if (animal is Feline)
                {
                    var feline = (Feline) animal;
                    Console.WriteLine($"{feline.GetType().Name} [{feline.Name}, {feline.Bread}, {feline.Weight}, {feline.LivingRegion}, {feline.FoodQuantity}]");
                }
                else
                {
                    var mimmal = (Mammal) animal;
                    Console.WriteLine($"{mimmal.GetType().Name} [{mimmal.Name}, {mimmal.Weight}, {mimmal.LivingRegion}, {mimmal.FoodQuantity}]");
                }
            }
        }
    }
}
