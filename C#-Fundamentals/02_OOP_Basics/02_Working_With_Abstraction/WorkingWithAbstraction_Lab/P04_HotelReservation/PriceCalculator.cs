using System;

class PriceCalculator
{
    private double PricePerDay { get; set; }
    private int NumberOfDays { get; set; }
    private string Season { get; set; }
    private string DiscountType { get; set; }


    public void InputParce(string[] inputLine)
    {
       
    }

    public decimal CalculatePrice(decimal pricePerDay, int numberOfDays, Enums.Season season, Enums.DiscountType discount)
    {
        int multiplier = (int) season;
        decimal discountMultiplier = (decimal) discount / 100;
        decimal priceBeforeDiscount = numberOfDays * pricePerDay * multiplier;
        decimal discountedAmount = priceBeforeDiscount * discountMultiplier;
        decimal finalPrice = priceBeforeDiscount - discountedAmount;

        return finalPrice;
    }
}
