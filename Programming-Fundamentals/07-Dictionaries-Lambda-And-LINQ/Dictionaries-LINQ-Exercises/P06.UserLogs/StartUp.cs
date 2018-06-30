using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.UserLogs
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var persons=new Dictionary<string,Dictionary<string,int>>();
            while (input!="end")
            {
                var tokens = input
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var ip = string.Join("",tokens[0].Skip(3).ToArray());
                var user = string.Join("",tokens[2].Skip(5).ToArray());

                if (!persons.ContainsKey(user))
                {
                    persons.Add(user,new Dictionary<string, int>());
                }
                if (!persons[user].ContainsKey(ip))
                {
                    persons[user].Add(ip,0);
                }

                persons[user][ip]++;
                input = Console.ReadLine();
            }

            foreach (var person in persons.OrderBy(x=>x.Key))
            {
                var name = person.Key;
                var ips = person.Value;
                Console.WriteLine($"{name}:");
                string str = "";
                foreach (var ip in ips)
                {
                    
                    str+= ($"{ip.Key} => {ip.Value}, ");
                }
                Console.WriteLine(str.Remove(str.Length-2)+".");
            }
        }
    }
}
