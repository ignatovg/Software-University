using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingDictionary
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var dict=new Dictionary<double,int>
            {
                {1.11, 2 },
                {2.22, 2 },
                {4.33, 3 },
                {23.11, 3 },
                {52.11, 5 },
            };

            var sorted=dict.OrderBy(x=>x.Value).ThenBy(x=>x.Key);

            Console.WriteLine(string.Join(", ",
                sorted.Select(x=> "key= "+x.Key + " value= "+x.Value)));
        }
    }
}
