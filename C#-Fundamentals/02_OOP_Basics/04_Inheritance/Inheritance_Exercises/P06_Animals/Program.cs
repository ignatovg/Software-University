using System;
using System.Collections.Generic;

namespace P06_Animals
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string animalType = string.Empty;
            
            while ((animalType= Console.ReadLine())!= "Beast!")
            {
                try
                {
                    string[] animalArgs = Console.ReadLine().Split();
                    string animalName = animalArgs[0];

                    int animalAge;
                    if(!int.TryParse(animalArgs[1],out animalAge))
                    {
                        throw new ArgumentException("Invalid input!");
                    }
                    string animalGander = animalArgs[2];

                    switch (animalType)
                    {
                        case "Dog":
                            Dog dog = new Dog(animalName, animalAge, animalGander);

                            PrintAnimalProperties(dog);
                            Console.WriteLine(dog.ProduceSound());
                            break;
                        case "Cat":
                            Cat cat = new Cat(animalName, animalAge, animalGander);

                            PrintAnimalProperties(cat);
                            Console.WriteLine(cat.ProduceSound());
                            break;
                        case "Frog":
                            Frog frog = new Frog(animalName, animalAge, animalGander);

                            PrintAnimalProperties(frog);
                            Console.WriteLine(frog.ProduceSound());
                            break;
                        case "Kittens":
                            Kittens kittens = new Kittens(animalName, animalAge, animalGander);

                            PrintAnimalProperties(kittens);
                            Console.WriteLine(kittens.ProduceSound());
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(animalName, animalAge, animalGander);

                            PrintAnimalProperties(tomcat);
                            Console.WriteLine(tomcat.ProduceSound());
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        private static void PrintAnimalProperties(object animal)
        {
            Console.WriteLine(animal.GetType());
            Console.WriteLine(animal);
        }
    }
}
