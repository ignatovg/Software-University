using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07.PopulationCounter
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var countries = new Dictionary<string,Dictionary<string,long>>();
            while (input!="report")
            {
                string[] parameters = input.Split(new char[] {'|'},
                    StringSplitOptions.RemoveEmptyEntries);
                string city = parameters[0];
                string country = parameters[1];
                long population = int.Parse(parameters[2]);

                if (!countries.ContainsKey(country))
                {
                    countries.Add(country, new Dictionary<string, long>());
                    countries[country].Add(city, population);
                }
                else
                {
                    if (!countries[country].ContainsKey(city))
                    {
                        countries[country].Add(city, population);
                    }
                }

                input = Console.ReadLine();
            }

            countries = countries.OrderByDescending(n => n.Value.Values.Sum())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var country in countries)
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value.Values.Sum()})");

                foreach (var city in country.Value.OrderByDescending(c=> c.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}
