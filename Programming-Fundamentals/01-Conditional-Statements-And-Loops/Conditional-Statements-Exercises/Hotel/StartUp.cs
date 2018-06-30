using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class hotel
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine().ToLower();
            int nightCount = int.Parse(Console.ReadLine());
           

            double studio = 0;
            double doubler = 0;
            double suite = 0;

            if (month == "may" || month == "october")
            {
                if (nightCount > 7)
                {
                    studio = 50 * 0.95;
                    doubler = 65;
                    suite = 75;
                }
                else
                {
                    studio = 50;
                    doubler = 65;
                    suite = 75;
                }
            }
            else if (month == "june" || month == "september")
            {
                if (nightCount > 14)
                {
                    studio = 60;
                    doubler = 72 * 0.90;
                    suite = 82;
                }
                else
                {
                    studio = 60;
                    doubler = 72;
                    suite = 82;
                }
            }
            else if (month == "july" || month == "august" || month == "december")
            {
                if (nightCount > 14)
                {
                    studio = 68;
                    doubler = 77;
                    suite = 89 * 0.85;
                }
                else
                {
                    studio = 68;
                    doubler = 77;
                    suite = 89;
                }

            }

            if ((month == "september" || month == "october") && nightCount > 7)
            {
                Console.WriteLine("Studio: {0:f2} lv.", studio * (nightCount - 1));
                Console.WriteLine("Double: {0:f2} lv.", doubler * nightCount);
                Console.WriteLine("Suite: {0:f2} lv.", suite * nightCount);
            }
            else
            {
                Console.WriteLine("Studio: {0:f2} lv.", studio * nightCount);
                Console.WriteLine("Double: {0:f2} lv.", doubler * nightCount);
                Console.WriteLine("Suite: {0:f2} lv.", suite * nightCount);
            }




        }
    }
}
