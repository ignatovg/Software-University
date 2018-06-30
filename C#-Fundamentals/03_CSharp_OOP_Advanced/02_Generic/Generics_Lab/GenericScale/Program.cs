using System;

namespace GenericScale
{
    class Program
    {
        static void Main(string[] args)
        {
            var v1 = 2;
            var v2 = 2;
            var sclae = new Scale<int>(v1, v2);

            Console.WriteLine(sclae.GetHeavier());

        }
    }
}
