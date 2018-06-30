using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P04.Weather
{
    class Whether
    {
        public string City { get; set; }
        public double AverageTemperatrure { get; set; }
        public string WhetherType { get; set; }
    }
    class StartUp
    {
        static void Main(string[] args)
        {
            string inputStr = Console.ReadLine();

            string pattern = @"([A-Z]{2})(\d+\.\d+)([A-Za-z]+)\|";
            Regex regex=new Regex(pattern);

            List<Whether> whethersList=new List<Whether>();

            while (inputStr!="end")
            {
                Match match=regex.Match(inputStr);
                bool isAddedCity = false;

                if (match.Success)
                {
                    
                    Whether whether=new Whether();
                    whether.City = match.Groups[1].Value;
                    whether.AverageTemperatrure = double.Parse(match.Groups[2].Value);
                    whether.WhetherType = match.Groups[3].Value;
                    


                    whethersList.Add(whether);
                    
                }

                inputStr = Console.ReadLine();
            }

        }
    }
}
