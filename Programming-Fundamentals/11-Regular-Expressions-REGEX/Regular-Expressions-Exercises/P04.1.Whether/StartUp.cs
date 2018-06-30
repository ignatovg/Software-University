using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P04._1.Whether
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string,double> citiesWithTemperature=new Dictionary<string, double>();
            Dictionary<string,string> citiesWithWhether=new Dictionary<string, string>();

            string pattern = @"([A-Z]{2})(\d+\.\d+)([A-Za-z]+)\|";

            string inputLine = Console.ReadLine();

            while (inputLine!="end")
            {
                if (Regex.IsMatch(inputLine, pattern))
                {
                    Match match = Regex.Match(inputLine, pattern);

                    string city = match.Groups[1].Value;
                    double averageTemperature = double.Parse(match.Groups[2].Value);
                    string whether = match.Groups[3].Value;

                    citiesWithTemperature[city] = averageTemperature;
                    citiesWithWhether[city] = whether;

                }

                
                inputLine = Console.ReadLine();
            }

            Dictionary<string, double> sortedCitiesByTemperature =
                citiesWithTemperature.OrderBy(c => c.Value)
                    .ToDictionary(x => x.Key, x => x.Value);

            foreach (var sottedCity in sortedCitiesByTemperature)
            {
                Console.WriteLine($"{sottedCity.Key} => {sottedCity.Value} => {citiesWithWhether[sottedCity.Key]}");
            }
        }
    }
}
