using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.ReverseAnArrayOfStrings
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split(' ');
            int endIndex = array.Length - 1;

            for (int startIndex = 0; startIndex < array.Length / 2; startIndex++)
            {
                SwitchElements(array, startIndex, endIndex);
                if (endIndex == array.Length / 2)
                {
                    break;
                }
                endIndex--;
            }
            Console.WriteLine(string.Join(" ", array));
        }

        static void SwitchElements(string[] arr, int startIndex, int endIndex)
        {
            string temp = arr[startIndex];
            arr[startIndex] = arr[endIndex];
            arr[endIndex] = temp;
        }
    }
}
