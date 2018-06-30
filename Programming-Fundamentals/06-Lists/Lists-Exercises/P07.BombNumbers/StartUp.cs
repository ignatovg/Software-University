using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07.BombNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var bombArgs = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            while (numbers.Contains(bombArgs[0]))
            {
                BombElements(numbers, bombArgs[0], bombArgs[1]);
            }

            Console.WriteLine(numbers.Sum());
        }

        private static void BombElements(List<int> numbers, int bombedNum, int length)
        {
            int indexOfBomb = numbers.IndexOf(bombedNum);
            int cnt = 2 * length + 1;
            int start = indexOfBomb - length;
            if (start < 0)
            {
                cnt -= Math.Abs(start);
                start = 0;
            }
            while (cnt != 0)
            {

                if (start == numbers.Count)
                {
                    break;
                }

                numbers.RemoveAt(start);
                cnt--;
            }

        }
    }
}
