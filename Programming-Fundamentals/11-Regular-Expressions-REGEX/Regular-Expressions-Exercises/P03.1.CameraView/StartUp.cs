using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P03._1.CameraView
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] indeces = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int m = indeces[0];
            int n = indeces[1];

            string pattern = $"\\|\\<(.{{0,{m}}})(.{{0,{n}}})";

            Regex regex=new Regex(pattern);

            string inputLine = Console.ReadLine();

            Match match = regex.Match(inputLine);

            List<string> result =new List<string>();
            while (inputLine.Length>(match.Index+2) && match.Success)
            {
                string stringMatchToAdd = match.Groups[2].Value;

                if (stringMatchToAdd.Contains("|"))
                {
                    stringMatchToAdd = stringMatchToAdd.Substring(0, stringMatchToAdd.IndexOf("|"));
                }

                if (stringMatchToAdd.Contains("<"))
                {
                    stringMatchToAdd = stringMatchToAdd.Substring(0, stringMatchToAdd.IndexOf("<"));
                }
                result.Add(stringMatchToAdd);
                inputLine = inputLine.Substring(match.Index + 2);
                match = regex.Match(inputLine);

            }
            Console.WriteLine(string.Join(", ",result));
        }
    }
}
