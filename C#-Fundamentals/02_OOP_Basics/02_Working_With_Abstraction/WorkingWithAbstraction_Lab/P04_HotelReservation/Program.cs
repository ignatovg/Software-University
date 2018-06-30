using System;

namespace P04_HotelReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputLine = Console.ReadLine().Split();
            PriceCalculator priceCalculator = new PriceCalculator();

            priceCalculator.InputParce(inputLine);
            decimal pricePerDay = decimal.Parse(inputLine[0]);
            int numberOfDays = int.Parse(inputLine[1]);
            Enums.Season season = (Enums.Season) Enum.Parse(typeof(Enums.Season), inputLine[2]);
            Enums.DiscountType discount = Enums.DiscountType.None;
            if(Enum.TryParse(inputLine[3],out discount))
            {
                discount = (Enums.DiscountType) Enum.Parse(typeof(Enums.DiscountType), inputLine[3]);
            }

           decimal finalPrice = priceCalculator.CalculatePrice(pricePerDay, numberOfDays, season, discount);
            Console.WriteLine($"{finalPrice:f2}");

        }
    }
}
