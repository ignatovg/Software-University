using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_ShopingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Person> persons = new List<Person>();
                List<Product> products = new List<Product>();

                persons = PersePersons(persons);
                products = ParseProducts(products);

                string command = string.Empty;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] tokens = command.Split();
                    string name = tokens[0];
                    string productName = tokens[1];

                    var personObj = persons.First(p => p.Name == name);
                    var productObj = products.First(p => p.Name == productName);

                    if (personObj.Money < productObj.Cost)
                    {
                        Console.WriteLine($"{personObj.Name} can't afford {productObj.Name}");
                        continue;
                    }
                    Console.WriteLine($"{name} bought {productName}");
                    personObj.Money = personObj.Money - productObj.Cost;
                    personObj.Products.Add(productObj);
                }

                foreach (Person person in persons)
                {
                    Console.WriteLine($"{person.ToString()}");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private static List<Product> ParseProducts(List<Product> products)
        {
            var productsInput = Console.ReadLine().Split(';',StringSplitOptions.RemoveEmptyEntries);

            //adding product in productsList
            foreach (string p in productsInput)
            {
                Product product = new Product();
                products.Add(product.ParseProduct(p));
            }
            return products;
        }

        private static List<Person> PersePersons(List<Person> persons)
        {
            var personsInput = Console.ReadLine().Split(';',StringSplitOptions.RemoveEmptyEntries);
            //adding person in personsList
            foreach (string p in personsInput)
            {
                Person person = new Person();
                persons.Add(person.ParsePerson(p));
            }

            return persons;
        }
    }
}
