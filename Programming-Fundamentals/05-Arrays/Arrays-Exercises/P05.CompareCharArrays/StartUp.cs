using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.CompareCharArrays
{
    class StartUp
    {
        static void Main(string[] args)
        {
            char[] firstArr = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();
            
            char[] secondArr= Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();
            int maxLength=Math.Max(firstArr.Length,secondArr.Length);

            for (int i = 0; i <maxLength ; i++)
            {
                
                if (firstArr[i] < secondArr[i] || firstArr.Length<secondArr.Length)
                {
                   Console.WriteLine(string.Join("",firstArr));
                    Console.WriteLine(string.Join("", secondArr));
                    break;
                }
                else
                {
                    Console.WriteLine(string.Join("", secondArr));
                    Console.WriteLine(string.Join("", firstArr));
                    break;
                }
            }
        }
    }
}
