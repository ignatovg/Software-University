using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.HandsOfCards
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var persons=new Dictionary<string,List<string>>();
            while (input!="JOKER")
            {
                var tokens = input.Split(':');
                string name = tokens[0];
                var cards = tokens[1]
                    .Trim()
                    .Split(new string[]{", "}, StringSplitOptions.RemoveEmptyEntries);

                if (!persons.ContainsKey(name))
                {
                    persons.Add(name, new List<string>());
                }

                for (int i = 0; i < cards.Length; i++)
                    {
                        if (!persons[name].Contains(cards[i]))
                        {
                            persons[name].Add(cards[i]);
                        }
                    }
                
                input = Console.ReadLine();
            }

            foreach (var person in persons)
            {
                var name = person.Key;
                var cards = person.Value;
                Console.Write(name + ": ");
                int sum = 0;

                string[] powersArr ={"0", "1", "2", "3" , "4", "5", "6", "7", "8", "9", "10" ,"J" ,"Q" ,"K" ,"A" }; 
                for (int i = 0; i < cards.Count; i++)
                {
                    string type = cards[i].Last().ToString();
                    string power = cards[i].Remove(cards[i].Length - 1);
                   

                    int indexOf = Array.IndexOf(powersArr, power);

                    if (type == "S")
                    {
                        sum += 4 * indexOf;
                    }
                    else if (type == "H")
                    {
                        sum += 3 * indexOf;
                    }
                    else if (type=="D")
                    {
                        sum += 2*indexOf;
                    }
                    else if(type=="C")
                    {
                        sum += 1*indexOf;
                    }
                }
                Console.WriteLine(sum);
            }
        }
    }
}
