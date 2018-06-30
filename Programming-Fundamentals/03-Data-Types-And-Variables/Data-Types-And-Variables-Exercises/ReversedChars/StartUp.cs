using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversedChars
{
    class StartUp
    {
        static void Main(string[] args)
        {
            char letter1=char.Parse(Console.ReadLine());
            char letter2=char.Parse(Console.ReadLine());
            char letter3=char.Parse(Console.ReadLine());
            string reversedLetters = ("" + letter3 + letter2 + letter1);
            Console.WriteLine(reversedLetters);
        }
    }
}
