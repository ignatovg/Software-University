using System;

namespace P04_Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();

            Telephony telephony = new Telephony();

            foreach (string number in phoneNumbers)
            {

                try
                {
                    telephony.Call(number);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            foreach (string url in urls)
            {
                try
                {
                    telephony.Browser(url);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

    }
}

