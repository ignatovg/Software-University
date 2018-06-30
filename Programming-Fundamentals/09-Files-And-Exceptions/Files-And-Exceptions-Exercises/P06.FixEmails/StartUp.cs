using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.FixEmails
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var emails=new Dictionary<string,string>();
            for (int i = 0; i < input.Length; i+=2)
            {
                string name = input[i];
                if (name == "stop" || input[i+1]=="stop")
                {
                    break;
                }
                string email = input[i + 1].ToLower();

                if (!email.Contains(name) && !email.EndsWith("us") && !email.EndsWith("us"))
                {
                    emails.Add(name, email);
                }
                else
                {
                    if (!email.EndsWith("us") && !email.EndsWith("uk"))
                    { 
                        emails[name] = email;
                    }
                }
            }

            foreach (var email in emails)
            {
                File.AppendAllText("output.txt", $"{email.Key} -> {email.Value}{Environment.NewLine}");           
            }
        }
    }
}
