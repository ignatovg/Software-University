using System;

namespace Bojo_TheHeiganDance
{
    class Program
    {
        private static int playerRow= 7;
        private static int playerColumn= 7;
        private const int min = 0;
        private const int max = 14;
        static void Main(string[] args)
        {
            const int cloudDamage = 3_500;
            const int eruptionDamage = 6_000;

            double heiganHealth = 3_000_000.0;
            int playerHealth = 18_500;
            bool hasCloud = false;
            string couseOfDeath = "";

            double playerDamage = double.Parse(Console.ReadLine());

            while (true)
            {
                heiganHealth -= playerDamage;


                if (hasCloud)
                {
                    playerHealth -= cloudDamage;
                    hasCloud = false;
                    couseOfDeath = "Plague Cloud";
                }

                string[] spellTokens = Console.ReadLine().Split();
                string spellName = spellTokens[0];
                int rowHit = int.Parse(spellTokens[1]);
                int colHit = int.Parse(spellTokens[2]);

                int[][] damageArea = GetDamageArea(rowHit, colHit);

                if (IsPlayerInDamageZone(damageArea))
                {
                    int newRow = playerRow - 1;
                    bool isRowAboveAvaible = newRow >= min;
                    if (hasCloud)
                    {
                        
                    }
                }
            }
        }

        private static bool IsPlayerInDamageZone(int[][] damageArea)
        {
            bool isInRowsHit = false;
            for (int i = 0; i < 3; i++)
            {
                if (damageArea[0][i] == playerRow)
                {
                    isInRowsHit = true;
                    break;
                }
            }
            bool isInColsHit = false;
            for (int i = 0; i < 3; i++)
            {
                if (damageArea[1][i] == playerColumn)
                {
                    isInColsHit= true;
                    break;
                }
            }
            return isInRowsHit && isInColsHit;
        }

        private static int[][] GetDamageArea(int rowHit, int colHit)
        {
            int[][] damageArea = new int[2][];
            damageArea[0] = new int[3];

            for (int i = 1; i >= -1; i--)
            {
                damageArea[0][i] = rowHit - i;
            }
            damageArea[1] = new int[3];

            for (int i = 1; i >= -1; i--)
            {
                damageArea[0][i] = colHit - i;
            }

            return damageArea;
        }
    }
}
