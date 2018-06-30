using System;
using System.Linq;

namespace Date
{
    class Program
    {
        static void Main(string[] args)
        {
            //1992 05 31
            //2016 06 17
            int[] firstInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            DateTime firstDate = new DateTime(firstInput[0],firstInput[1],firstInput[2]);
            DateTime secondDate = new DateTime(secondInput[0], secondInput[1], secondInput[2]);

            DateModifier date = new DateModifier{StartDate = firstDate,EndDate = secondDate};

            Console.WriteLine(date.CalculateDate()); 
          
        }
    }
}
