using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.AdvertisementMessage
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] phrases = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            string[] events =
            {
                "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"
            };

            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            Random rnd = new Random();

            int n= int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int phraseIndex = rnd.Next(0, phrases.Length);
                int eventIndex = rnd.Next(0, events.Length);
                int authorIndex = rnd.Next(0, authors.Length);
                int townIndex = rnd.Next(0, cities.Length);
                

                Console.WriteLine($"{phrases[phraseIndex]} {events[eventIndex]} {authors[authorIndex]} - {cities[townIndex]}");
            }
         
        }
    }
}
