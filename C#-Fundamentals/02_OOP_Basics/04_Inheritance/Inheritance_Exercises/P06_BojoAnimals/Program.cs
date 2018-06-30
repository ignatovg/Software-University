using System;
using System.Collections.Generic;

namespace P06_BojoAnimals
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string animalType;
            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    ReadAndCreateAnimal(animals, animalType);
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static void ReadAndCreateAnimal(List<Animal> animals, string animalType)
        {
            string[] tokens = Console.ReadLine().Split();
            string name = tokens[0];
            int age = int.Parse(tokens[1]);
            string gender = null;
            if (tokens.Length == 3)
            {
                gender = tokens[2];
            }

            switch (animalType)
            {
                case "Cat":
                    var cat = new Cat(name, age, gender);
                    animals.Add(cat);
                    break;

                case "Dog":
                    var dog = new Dog(name, age, gender);
                    animals.Add(dog);
                    break;

                case "Frog":
                    var frog = new Frog(name, age, gender);
                    animals.Add(frog);
                    break;

                case "Kitten":
                    var kittens = new Kitten(name, age);
                    animals.Add(kittens);
                    break;

                case "Tomcat":
                    var tomcat = new Tomcat(name, age);
                    animals.Add(tomcat);
                    break;
                default:
                    throw new ArgumentException("Invalid input!");
            }

        }
    }
}
