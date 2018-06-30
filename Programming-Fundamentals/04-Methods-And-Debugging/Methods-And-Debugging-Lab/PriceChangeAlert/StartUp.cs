using System;

class PriceChangeAlert
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double treshold = double.Parse(Console.ReadLine());
        double last = double.Parse(Console.ReadLine());

        for (int i = 0; i < n-1; i++)
        {
            double price = double.Parse(Console.ReadLine());
            double div = Proc(last, price);
            bool isSignificantDifference = imaliDif(div, treshold);
            string message = Get(price, last, div, isSignificantDifference);

            Console.WriteLine(message);
            last = price;
        }
    }

    private static string Get(double c, double last, double razlika, bool etherTrueOrFalse)
    {
        string to = "";
        if (razlika == 0)
        {
            to = $"NO CHANGE: {c}";
        }
        else if (!etherTrueOrFalse)
        {
            to = $"MINOR CHANGE: {last} to {c} ({razlika:F2}%)";
        }
        else if (etherTrueOrFalse && (razlika > 0))
        {
            to = $"PRICE UP: {last} to {c} ({razlika:F2}%)";
        }
        else if (etherTrueOrFalse && (razlika < 0))
            to = $"PRICE DOWN: {last} to {c} ({razlika:F2}%)";

        return to;
    }

    private static bool imaliDif(double granica, double isDiff)
    {
        if (Math.Abs(granica) >= isDiff)
        {
            return true;
        }

        return false;
    }

    private static double Proc(double l, double c)
    {
        double r = (c - l) / l;

        return r;
    }
}
