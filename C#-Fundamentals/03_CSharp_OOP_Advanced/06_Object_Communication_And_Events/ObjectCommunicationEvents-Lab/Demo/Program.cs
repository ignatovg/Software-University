using System;

namespace Demo
{
    class Program
    {
        public delegate void DelegateToPrint(string stringToPrint);
        static void Main(string[] args)
        {
            //PrintToConsole("hello there!");
            DelegateToPrint functionToPrint = PrintToConsole;
            functionToPrint("hello there!");
        }


        private static void PrintToConsole(string stringToPrint)
        {
            Console.WriteLine(stringToPrint);
        }

        private static void DoNothing(string str)
        {
            
        }

        private static void PrintStringByFunction(DelegateToPrint delegateToPrint, string stringToPrint)
        {
            delegateToPrint(stringToPrint);
        }
    }


}
