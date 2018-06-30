using System;
using System.Linq;

namespace BasicsExam_16July2017
{
    class Program
    {
        static void Main(string[] args)
        {
            var draftManeger = new DraftManager();

            string input;
            while ((input = Console.ReadLine()) != "Shutdown")
            {
                var arguments = input.Split().ToList();
                var command = arguments[0];
                arguments = arguments.Skip(1).ToList();
                switch (command)
                {
                    case "RegisterHarvester":
                        Console.WriteLine(draftManeger.RegisterHarvester(arguments));
                        break;
                    case "RegisterProvider":
                        Console.WriteLine(draftManeger.RegisterProvider(arguments));
                        break;
                    case "Day":
                        Console.WriteLine(draftManeger.Day());
                        break;
                    case "Mode":
                        Console.WriteLine(draftManeger.Mode(arguments));
                        break;
                    case "Check":
                        Console.WriteLine(draftManeger.Check(arguments));
                        break;
                }
                Console.WriteLine(draftManeger.ShutDown());
            }
        }
    }
}
