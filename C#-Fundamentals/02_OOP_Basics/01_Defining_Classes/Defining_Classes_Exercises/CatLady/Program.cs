using System;
using System.Collections.Generic;
using System.Linq;

namespace CatLady
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cat> cats = new List<Cat>();

            string readLine = string.Empty;

            while ((readLine=Console.ReadLine())!= "End")
            {
                string[] tokens = readLine.Split();
                string breed = tokens[0];
                string catName = tokens[1];
                double quantity = double.Parse(tokens[2]);

                if (breed == "Siamese")
                {
                    Siamese siamese = new Siamese{Name = catName, EarSize = quantity};
                    cats.Add(siamese);
                }
                else if (breed == "Cymric")
                {
                    Cymric cymric = new Cymric{Name = catName, FurLenght = quantity};
                    cats.Add(cymric);
                }
                else if (breed == "StreetExtraordinaire")
                {
                    StreetExtraordinaire streetExtraordinaire = new StreetExtraordinaire { Name = catName, DecibelsOfMeows = quantity };
                    cats.Add(streetExtraordinaire);
                }
            }
            string searchByName = Console.ReadLine();

            var cat = cats.First(a => a.Name == searchByName);
            Console.WriteLine(cat);
        }
    }
}
