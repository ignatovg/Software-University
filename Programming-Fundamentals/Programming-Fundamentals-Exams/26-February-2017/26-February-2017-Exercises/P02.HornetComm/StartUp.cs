using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P02.HornetComm
{
    class StartUp
    {
        static void Main(string[] args)
        {
            // 90/100 in Judge

            List<KeyValuePair<string,string>> messages=new List<KeyValuePair<string, string>>();

            List<KeyValuePair<string, string>> broadcasts = new List<KeyValuePair<string, string>>();

            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == "Hornet is Green")
                {
                    break;
                }
                string[] tokens = inputLine.Split(new string[] {" <-> "},
                    StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (tokens.Length != 2)
                {
                    continue;
                }
                string firstQuery = tokens[0];
                string secondQuery = tokens[1];
                var isMatch = Regex.IsMatch(secondQuery, @"^([0-9A-Za-z]+)$");

                if (Regex.IsMatch(firstQuery, @"^(\d+)$"))
                {
                    if (isMatch)
                    {
                        string recipientsCode = Reverse(firstQuery);
                        string messege = secondQuery;

                      messages.Add(new KeyValuePair<string, string>(recipientsCode,messege));
                    }
                }
                else if (Regex.IsMatch(firstQuery, @"^\D+$"))
                {
                    if (isMatch)
                    {
                        string messege = firstQuery;
                        string frequency = ModificateString(secondQuery);

                       broadcasts.Add(new KeyValuePair<string, string>(frequency,messege));
                    }
                }
                
            }
            Console.WriteLine("Broadcasts:");
            foreach (var broadcast in broadcasts)
            {
                Console.WriteLine($"{broadcast.Key} -> {broadcast.Value}");
            }
            if (broadcasts.Count == 0)
            {
                Console.WriteLine("None");
            }

            Console.WriteLine("Messages:");
            foreach (var message in messages)
            {
                Console.WriteLine($"{message.Key} -> {message.Value}");
            }
            if (messages.Count == 0)
            {
                Console.WriteLine("None");
            }
        }

        private static string ModificateString(string secondQuery)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < secondQuery.Length; i++)
            {
                
                if (char.IsUpper(secondQuery[i]))
                {
                    result.Append(char.ToLower(secondQuery[i]));
                }
                else
                {
                   result.Append(char.ToUpper(secondQuery[i]));
                }
            }
          return result.ToString();
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
