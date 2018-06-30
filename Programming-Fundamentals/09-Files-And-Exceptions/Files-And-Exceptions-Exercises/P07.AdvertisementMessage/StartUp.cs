using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07.AdvertisementMessage
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int input = int.Parse(File.ReadAllText("input.txt"));
            string[] phrases = {"Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product."};

            string[] events =
            {"Now I feel good.", "I have succeeded with this product.", "Makes miracles.I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"
            };

            string[] authors = {"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};

            string[] cities = {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"};

            Random rnd=new Random();
            File.WriteAllText("output.txt",string.Empty);
            for (int i = 0; i < input; i++)
            {
               var phraseIndex =rnd.Next(0, phrases.Length);
               var eventIndex =rnd.Next(0, events.Length);
               var authorIndex= rnd.Next(0, authors.Length);
               var townIndex =rnd.Next(0, cities.Length);

                File.AppendAllText("output.txt", $"{phrases[phraseIndex]} {events[eventIndex]} {authors[authorIndex]} {cities[townIndex]}{Environment.NewLine}");
            }

}
    }
}
