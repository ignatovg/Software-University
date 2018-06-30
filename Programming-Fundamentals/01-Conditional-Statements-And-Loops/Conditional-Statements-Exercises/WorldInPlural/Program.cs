using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordInPlural
{
    class WordInPlural
    {
        static void Main(string[] args)
        {
            string noun = Console.ReadLine();
            StringBuilder builder = new StringBuilder(noun);
            string lastOne = builder[builder.Length - 1].ToString();
            string lastTwo = noun.Substring(builder.Length - 2, 2);


            if (lastOne == "y")
            {
                builder.Remove(builder.Length - 1, 1);
                builder.Append("ies");
            }
            else if (lastOne == "o" || lastTwo == "ch" || lastOne == "s" || lastTwo == "sh"
                     || lastOne == "x" || lastOne == "z")
            {

                builder.Append("es");
            }
            else
            {
                builder.Append("s");
            }

            Console.WriteLine(builder.ToString());
        }
    }
}
