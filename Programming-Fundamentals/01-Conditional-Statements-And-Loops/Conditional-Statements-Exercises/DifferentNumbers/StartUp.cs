using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentNumbers
{
    class DifferentNumbers
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (b - a < 4)
            {
                Console.WriteLine("No");
            }
            else
            {
                for (int first = a; first <= b; first++)
                {
                    for (int second = a; second <= b; second++)
                    {
                        for (int third = a; third <= b; third++)
                        {
                            for (int fourth = a; fourth <= b; fourth++)
                            {
                                for (int fifith = a; fifith <= b; fifith++)
                                {

                                    if (first < second && second < third && third < fourth && fourth < fifith)
                                    {
                                        Console.WriteLine($"{first} {second} {third} {fourth} {fifith}");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
