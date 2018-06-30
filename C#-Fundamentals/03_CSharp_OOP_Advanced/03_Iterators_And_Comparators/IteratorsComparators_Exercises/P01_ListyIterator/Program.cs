using System;
using System.Linq;

namespace P01_ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ListyIterator<string> listyIterator = new ListyIterator<string>();

                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] tokens = input.Split();

                    switch (tokens[0])
                    {
                        case "Create":
                            var data = tokens.Skip(1).ToArray();
                            listyIterator.Create(data);
                            break;

                        case "Move":
                            Console.WriteLine(listyIterator.Move());
                            break;

                        case "HasNext":
                            Console.WriteLine(listyIterator.HasNext());
                            break;

                        case "Print":
                            listyIterator.Print();
                            break;

                        case "PrintAll":
                            listyIterator.PrintAll();
                            break;
                            
                    }
                }
            }
            catch (InvalidOperationException m)
            {
                Console.WriteLine(m.Message);
            }
        }
    }
}
