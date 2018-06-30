using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace P08.LogsAggregator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var data =new Dictionary<string,Dictionary<string,int>>();

            int n =int.Parse(Console.ReadLine());
           

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var tokens = input.Split(' ');

                string ip = tokens[0];
                string name = tokens[1];
                int duration = int.Parse(tokens[2]);

                if (!data.ContainsKey(name))
                {
                    data.Add(name,new Dictionary<string, int>());
                    data[name].Add(ip,duration);
                }
                else
                {
                    if (!data[name].ContainsKey(ip))
                    {
                        data[name].Add(ip,duration);
                    }
                    else
                    {
                        data[name][ip] += duration;
                    }
                }
                
            }

            foreach (var kvp in data.OrderBy(a=>a.Key))
            {
                Console.Write($"{kvp.Key}: ");
                string ips = "";
                int sum = kvp.Value.Values.Sum();

                foreach (var innerKvp in kvp.Value.OrderBy(a=>a.Key))
                {
                  
                    ips += $"{innerKvp.Key}, ";
                }

                Console.WriteLine($"{sum} [{ips.Remove(ips.Length-2)}]");
            }
        }
    }
}
