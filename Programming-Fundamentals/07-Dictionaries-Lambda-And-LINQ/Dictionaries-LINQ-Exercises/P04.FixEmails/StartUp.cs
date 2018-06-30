using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.FixEmails
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var emails=new Dictionary<string,string>();
            while (true)
            {
                string name = Console.ReadLine();
                if (name=="stop")
                {
                    break;
                }
                string email=Console.ReadLine().ToLower();

                if (!email.EndsWith("us") && !email.EndsWith("uk"))
                {
                    if (!emails.ContainsKey(name))
                    {
                        emails.Add(name,email);
                    }
                    else
                    {
                        emails[name] = email;
                    }
                }
                else
                {
                    if (emails.ContainsKey(name))
                    {
                        emails.Remove(name);
                    }
                }
            }
            Console.WriteLine(string.Join("\r\n",
                emails.Select(x=> x.Key+ " -> "+x.Value)));
        }
    }
}
