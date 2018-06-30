using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankReceipt
{
    class StartUp
    {
        static void Main(string[] args)
        {

            PrintReceipt();
        }

        private static void PrintReceipt()
        {

            PrintHeaderReceipt();
            PrintBodyReceipt();
            PrintFooterReceipt();
        }

        private static void PrintFooterReceipt()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("\u00A9 SoftUni");
        }

        private static void PrintBodyReceipt()
        {
            Console.WriteLine("Charged to____________________");
            Console.WriteLine("Received by___________________");
        }

        private static void PrintHeaderReceipt()
        {
            Console.WriteLine("CASH RECEIPT");
            Console.WriteLine("------------------------------");
        }
    }
}
