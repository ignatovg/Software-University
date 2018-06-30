using System;

namespace P10_Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var liters = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var fullname = names[0] + " " + names[1];
            var tupleOfName = new Tuple<string, string>(fullname, names[2]);
            Console.WriteLine(tupleOfName);

            var tupleOfLiters = new Tuple<string,double>(liters[0],double.Parse(liters[1]));
            Console.WriteLine(tupleOfLiters);

            var tupleOfNums = new Tuple<int, double>(int.Parse(numbers[0]), double.Parse(numbers[1]));
            Console.WriteLine(tupleOfNums);
        }
    }
}
