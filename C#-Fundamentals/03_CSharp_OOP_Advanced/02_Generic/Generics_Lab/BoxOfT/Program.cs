using System;

namespace BoxOfT
{
    class Program
    {
        static void Main(string[] args)
        {
            var box = new Box<int>();

            box.Add(1);
            box.Add(2);
            Console.WriteLine(box.Remove());
        }
    }
}
