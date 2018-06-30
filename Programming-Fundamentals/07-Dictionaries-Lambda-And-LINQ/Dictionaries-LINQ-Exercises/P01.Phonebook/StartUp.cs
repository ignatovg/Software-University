using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Phonebook
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            var phonebook=new Dictionary<string,string>();

            while (input!="END")
            {
                var tokens = input.Split(' ');

                if (tokens[0] == "A")
                {
                    string name = tokens[1];
                    string number = tokens[2];

                    if (!phonebook.ContainsKey(name))
                    {
                        phonebook.Add(name,number);
                    }
                    phonebook[name] = number;

                }
                else if (tokens[0] == "S")
                {
                    string name = tokens[1];

                    if (phonebook.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} -> {phonebook[name]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {name} does not exist.");
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
