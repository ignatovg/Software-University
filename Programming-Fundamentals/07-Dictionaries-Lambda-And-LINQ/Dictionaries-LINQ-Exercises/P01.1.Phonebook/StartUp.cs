using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01._1.Phonebook
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string,string> phonebook=new Dictionary<string, string>();

            string input = Console.ReadLine();

            while (input!="END")
            {
                string[] phoneParameters = input.Split(new char[] {' '},
                    StringSplitOptions.RemoveEmptyEntries);
                string command = phoneParameters[0];

                if (command == "A")
                {
                    string key = phoneParameters[1];
                    string value = phoneParameters[2];

                 
                    phonebook[key] = value;
                }
                else if (command == "S")
                {
                    string key = phoneParameters[1];

                    if (phonebook.ContainsKey(key))
                    {
                        Console.WriteLine($"{key} -> {phonebook[key]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {key} does not exist.");
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
