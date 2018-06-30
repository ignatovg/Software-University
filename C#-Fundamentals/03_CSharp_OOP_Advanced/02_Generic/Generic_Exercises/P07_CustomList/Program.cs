using System;
using System.Collections.Generic;

namespace P07_CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "";
            var customList = new CustomList<string>(new List<string>());

            while ((input=Console.ReadLine())!="END")
            {
                string[] tokens = input.Split();

                switch (tokens[0])
                {
                    case "Add":
                        var addElement = tokens[1];
                        customList.Add(addElement);
                        break;

                    case "Remove":
                        var index = int.Parse(tokens[1]);
                        customList.Remove(index);
                        break;

                    case "Contains":
                        var containsElement = tokens[1];
                        Console.WriteLine( customList.Contains(containsElement));
                        break;

                    case "Swap":
                        customList.Swap(int.Parse(tokens[1]),int.Parse(tokens[2]));
                        break;

                    case "Greater":
                        Console.WriteLine(  customList.CountGreaterThan(tokens[1]));
                        break;

                    case "Max":
                        Console.WriteLine(customList.Max());
                        break;

                    case "Min":
                        Console.WriteLine(customList.Min());
                        break;

                    case "Sort":
                        break;

                    case "Print":
                        customList.Print();
                        break;
                }
            }
        }
    }
}
