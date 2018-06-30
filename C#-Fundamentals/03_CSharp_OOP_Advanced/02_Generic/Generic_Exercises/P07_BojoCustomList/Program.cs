using System;

namespace P07_BojoCustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<string> customList = new CustomList<string>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens  = input.Split();
                string command = tokens[0];

                switch (command)
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
                        Console.WriteLine(customList.Contains(containsElement));
                        break;

                    case "Swap":
                        customList.Swap(int.Parse(tokens[1]), int.Parse(tokens[2]));
                        break;

                    case "Greater":
                        Console.WriteLine(customList.CountGreaterThan(tokens[1]));
                        break;

                    case "Max":
                        Console.WriteLine(customList.Max());
                        break;

                    case "Min":
                        Console.WriteLine(customList.Min());
                        break;
                        
                    case "Print":
                        //for (int i = 0; i < customList.Count; i++)
                        //{
                        //    Console.WriteLine(customList[i]);
                        //}

                        foreach (var el in customList)
                        {
                            Console.WriteLine(el);
                        }
                        break;

                    case "Sort":
                        customList.Sort();
                        break;

                }
            }


        }
    }
}
