using System;
using System.Linq;

namespace MySolution
{
    class StartUp
    {
        static void Main(string[] args)
        {
            DraftManager draftManager = new DraftManager();

            string input;
            while ((input = Console.ReadLine()) != "Shutdown")
            {
                var tokens = input.Split().ToList();
                var arguments = tokens.Skip(1).ToList();

                switch (tokens[0])
                {
                    case "RegisterHarvester":
                        Console.WriteLine(draftManager.RegisterHarvester(arguments));
                        break;

                    case "RegisterProvider":
                        Console.WriteLine(draftManager.RegisterProvider(arguments));
                        break;

                    case "Day":
                        Console.WriteLine(draftManager.Day());
                        break;

                    case "Mode":
                        Console.WriteLine(draftManager.Mode(arguments));
                        break;

                    case "Check":
                        Console.WriteLine(draftManager.Check(arguments));
                        break;
                }
            }
            Console.WriteLine(draftManager.ShutDown());
        }
    }
}
