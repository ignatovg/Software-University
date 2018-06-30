using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P06.ValidUsernames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string lineOfUsers = Console.ReadLine();

            string pattern = @"\b([A-Za-z]\w{2,24})\b";

            MatchCollection matchCollection = Regex.Matches(lineOfUsers, pattern);

            int bestSum = 0;
            int bestIndex = 0;

            for (int i = 0; i < matchCollection.Count - 1; i++)
            {
                string first = matchCollection[i].ToString();
                string second = matchCollection[i + 1].ToString();

                int currentSum = first.Length + second.Length;
                var index = i;

                if (bestSum < currentSum)
                {
                    bestSum = currentSum;
                    bestIndex = index;
                }
            }

            Console.WriteLine(matchCollection[bestIndex]);
            Console.WriteLine(matchCollection[bestIndex + 1]);
        }
    }
}
