using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheaThePhotographer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            long totalPoctures=long.Parse(Console.ReadLine());
            long filterTime=long.Parse(Console.ReadLine());
            long filterFactor = long.Parse(Console.ReadLine());
            long uploadTime=long.Parse(Console.ReadLine());

            double filteredPictures = (totalPoctures * filterFactor) / 100.0;
            filteredPictures=Math.Ceiling(filteredPictures);
            long totalTime = (totalPoctures * filterTime) + ((long) filteredPictures * uploadTime);

            TimeSpan time=TimeSpan.FromSeconds(totalTime);
            string result = time.ToString(@"d\:hh\:mm\:ss");
            Console.WriteLine(result);
        }
    }
}
