using System;
using System.Runtime.InteropServices;

namespace ActionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> prakash = text => Console.WriteLine(text);
           Action<string,string> print = (firstName,LastName) => Console.WriteLine($"{firstName} {LastName}");

           print("Georgi", "Mihalkov");

            Func<string> readFromConsole = () =>
            {
                return Console.ReadLine();
            };

            Action<string> printToConsole = text => Console.WriteLine(text);

            var input = readFromConsole();
            printToConsole(input);
        }
    }
}
