using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.AMinerTask
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string,int> miner=new Dictionary<string, int>();
            while (true)
            {
                string resource = Console.ReadLine();
                if (resource == "stop")
                {
                    break;
                }
                int quantity = int.Parse(Console.ReadLine());

                if (!miner.ContainsKey(resource))
                {
                    miner.Add(resource, quantity);
                }
                else
                {
                    miner[resource] += quantity;
                }
            }
            Console.WriteLine(string.Join("\r\n",
                miner.Select(x=>x.Key+" -> "+ x.Value)));
        }
    }
}
