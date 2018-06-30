using System;
using System.Collections.Generic;
using System.Linq;

namespace Google
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> personsDict = new Dictionary<string, Person>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(' ');
                string name = tokens[0];
                string personInfo = tokens[1];

                if (!personsDict.ContainsKey(name))
                {
                    personsDict[name] = new Person();
                }
                switch (personInfo)
                {
                    case "company":
                        string companyName = tokens[2];
                        string department = tokens[3];
                        double salary = double.Parse(tokens[4]);
                        Company currentCompany = new Company { CompanyName = companyName, Department = department, Salary = salary };

                        personsDict[name].Company = currentCompany;

                        break;

                    case "pokemon":
                        string pokemonNmae = tokens[2];
                        string pokemonType = tokens[3];
                        Pokemon currentPokemon = new Pokemon { PokemonName = pokemonNmae, PokemonType = pokemonType };

                        personsDict[name].Pokemons.Add(currentPokemon);
                        break;

                    case "parents":
                        string parentName = tokens[2];
                        string parentBirthday = tokens[3];
                        Parent currentParent = new Parent { ParentName = parentName, ParentBirthday = parentBirthday };

                        personsDict[name].Parents.Add(currentParent);

                        break;

                    case "children":
                        string childName = tokens[2];
                        string childBirthday = tokens[3];
                        Child currentChild = new Child { ChildName = childName, ChildBirthday = childBirthday };

                        personsDict[name].Childrens.Add(currentChild);
                        break;

                    case "car":
                        string carModel = tokens[2];
                        double carSpeed = double.Parse(tokens[3]);
                        Car currentCar = new Car { CarModel = carModel, CarSpeed = carSpeed };

                        personsDict[name].Car = currentCar;
                        break;
                }
            }
            string searchByName = Console.ReadLine();

            foreach (var pair in personsDict.Where(a => a.Key == searchByName))
            {
                string name = pair.Key;

                Console.WriteLine(name);

                Console.WriteLine("Company:");
                Console.Write(pair.Value.Company);
                Console.WriteLine("Car:");
                Console.Write(pair.Value.Car);
                Console.WriteLine("Pokemon:");
                pair.Value.Pokemons.ForEach(a => Console.Write(a.ToString()));
                Console.WriteLine("Parents:");
                pair.Value.Parents.ForEach(a => Console.Write(a.ToString()));
                Console.WriteLine("Children:");
                pair.Value.Childrens.ForEach(a => Console.Write(a.ToString()));
            }

        }
    }
}
