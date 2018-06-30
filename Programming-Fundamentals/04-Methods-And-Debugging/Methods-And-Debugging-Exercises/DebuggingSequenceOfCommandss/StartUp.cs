using System;
using System.Linq;

public class StartUp
{
    private const char ArgumentsDelimiter = ' ';
    public static void Main()
    {
        int sizeOfArray = int.Parse(Console.ReadLine());

        long[] array = Console.ReadLine()
            .Split(ArgumentsDelimiter)
            .Select(long.Parse)
            .ToArray();

        string command = Console.ReadLine();

        while (!command.Equals("stop"))
        {
            // string line = Console.ReadLine().Trim();
            int[] args = new int[2];
            string[] tokkens = command.Split(' ');
            string commandAsString = tokkens[0];

            if (commandAsString== "multiply" 
                || commandAsString=="add" 
                || commandAsString== "subtract")
            {
                string[] stringParams = command.Split(ArgumentsDelimiter);
                args[0] = int.Parse(stringParams[1]);
                args[1] = int.Parse(stringParams[2]);

                array = PerformAction(array, commandAsString, args).Clone() as long[];
            }
            else
            {
                array = PerformAction(array, commandAsString, args).Clone() as long[];
            }
            PrintArray(array);
            

            command = Console.ReadLine();
        }
    }

    static long[] PerformAction(long[] arr, string action, int[] args)
    {
        long[] array = arr.Clone() as long[];
        int pos = args[0] - 1;
        int value = args[1];

        switch (action)
        {
            case "multiply":
                array[pos] *= value;
                return array;
                break;
            case "add":
                array[pos] += value;
                return array;
                break;
            case "subtract":
                array[pos] -= value;
                return array;
                break;
            case "lshift":
                ArrayShiftLeft(array);
                return array;
                break;
            case "rshift":
                ArrayShiftRight(array);
                return array;
                break;
        }
        return array;
    }

    private static void ArrayShiftRight(long[] array)
    {
        long lastElement = array[array.Length - 1];
        for (int i = array.Length - 1; i >= 1; i--)
        {
            array[i] = array[i - 1];
        }
        array[0] = lastElement;

    }

    private static void ArrayShiftLeft(long[] array)
    {
        long firstElemnt = array[0];
        for (int i = 0; i < array.Length - 1; i++)
        {
            array[i] = array[i + 1];
        }
        array[array.Length - 1] = firstElemnt;
    }

    private static void PrintArray(long[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}
