using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P06._1.ValidUsernames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string splitter = @"\W+";
        string[] usernames = Regex.Replace(line, splitter, " ").Split(new char[] {' '},
                StringSplitOptions.RemoveEmptyEntries);

            string pattern = @"^[a-zA-Z][a-zA-Z0-9_]{2,24}$";

            Regex regex=new Regex(pattern);
            List<string> valid=new List<string>();

            foreach (var username in usernames)
            {
                if (regex.IsMatch(username))
                {
                    valid.Add(username);
                }
            }

            int sumMax = 0;
            string first = string.Empty;
            string second = string.Empty;

            for (int i = 1; i < valid.Count; i++)
            {
                int currentSum = valid[i - 1].Length + valid[i].Length;
                if (currentSum>sumMax)
                {
                    sumMax = currentSum;
                    first = valid[i - 1];
                    second = valid[i];
                }
            }
            Console.WriteLine(first);
            Console.WriteLine(second);
        }
    }
}
