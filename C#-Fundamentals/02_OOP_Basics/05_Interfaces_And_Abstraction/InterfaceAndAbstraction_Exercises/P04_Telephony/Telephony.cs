using System;
using System.Linq;

public class Telephony:ICallable,IBrowser
{
    public string Model { get; } = "Smartphone";
    
    public void Call(string number)
    {
        if (!number.All(Char.IsDigit))
        {
            throw new ArgumentException("Invalid number!");
        }
        Console.WriteLine($"Calling... {number}");
    }

    public void Browser(string url)
    {
        if (url.Any(Char.IsDigit))
        {
            throw new ArgumentException("Invalid URL!");
        }
        Console.WriteLine($"Browsing: {url}!");
    }
}

