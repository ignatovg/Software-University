using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02._3HornetComm
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> messages = new List<string>();
            List<string> broadcasts = new List<string>();

            string input;
            while ((input=Console.ReadLine()) != "Hornet is Green")
            {
                var inputArgs = input.Split(new string[] {" <-> "},
                    StringSplitOptions.RemoveEmptyEntries);
                if (inputArgs[0].ToCharArray().All(c => Char.IsDigit(c)) 
                    && inputArgs[1].ToCharArray().All(c=>Char.IsLetterOrDigit(c)))
                {
                    messages.Add($"{string.Join("", inputArgs[0].ToCharArray().Reverse())} -> {inputArgs[1]}");
                }

                if (!inputArgs[0].ToCharArray().Any(c => Char.IsDigit(c))
                    && inputArgs[1].ToCharArray().All(c => Char.IsLetterOrDigit(c)))
                {
                    StringBuilder sb=new StringBuilder();
                    foreach (var c in inputArgs[1].ToCharArray())
                    {
                        if (Char.IsLower(c))
                        {
                            sb.Append(Char.ToUpper(c));
                            continue;
                        }
                        if (Char.IsLower(c))
                        {
                            sb.Append(Char.ToLower(c));
                            continue;
                        }
                        sb.Append(c);
                    }
                    broadcasts.Add($"{sb.ToString()} -> {inputArgs[0]}");
                }
            }
            Console.WriteLine("Broadcasts:");

            if (broadcasts.Count > 0)
            {
                Console.WriteLine(string.Join("\n", broadcasts));
            }
            else
            {
                Console.WriteLine("None");
            }

            Console.WriteLine("Messages:");

            if (messages.Count > 0)
            {
                Console.WriteLine(string.Join("\n", messages));
            }
            else
            {
                Console.WriteLine("None");
            }
        }
    }
}
