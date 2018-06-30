using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P03.CameraView
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] arrLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            string text = Console.ReadLine();

            string pattern = @"\|<\w+";
            MatchCollection matchCollection = Regex.Matches(text, pattern);

            int skipElements = arrLine[0]+2;
            int takeElements = arrLine[1];
            string stringToWrite = string.Empty;
            foreach (Match match in matchCollection)
            {
                var result =  match.ToString().Skip(skipElements).Take(takeElements).ToArray();
              stringToWrite += string.Join("", result) + ", ";
            }
            Console.WriteLine(stringToWrite.Trim(' ',','));
        }
    }
}
