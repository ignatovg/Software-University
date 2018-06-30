using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character_Stats
{
    class ChStats
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int currentHealt=int.Parse(Console.ReadLine());
            int maxHealth=int.Parse(Console.ReadLine());
            int currentEnergy=int.Parse(Console.ReadLine());
            int maxEnergy=int.Parse(Console.ReadLine());

            string lineHealth=new string('|',currentHealt);
            string dotsHealth=new string('.',maxHealth-currentHealt);
            string lineEnergy=new string('|',currentEnergy);
            string dotsEnergy=new string('.',maxEnergy-currentEnergy);

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Health: |{lineHealth}{dotsHealth}|");
            Console.WriteLine($"Energy: |{lineEnergy}{dotsEnergy}|");
        }
    }
}
