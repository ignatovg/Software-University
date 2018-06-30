using System;
using System.Linq;
using Dungeons_Exam;

namespace DungeonsAndCodeWizards
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            DungeonMaster dungeonMaster = new DungeonMaster();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split();
                var commangArgs = tokens.Skip(1).ToArray();

                switch (tokens[0])
                {
                    case "JoinParty":
                        dungeonMaster.JoinParty(commangArgs);
                        break;
                    case "AddItemToPool":
                        dungeonMaster.AddItemToPool(commangArgs);
                        break;
                    case "PickUpItem":
                        break;
                    case "UseItem":
                        break;
                    case "UseItemOn":
                        break;
                    case "GiveCharacterItem":
                        break;
                    case "GetStats":
                        break;
                    case "Attack":
                        break;
                    case "Heal":
                        break;
                    case "EndTurn":
                        break;
                    case "IsGameOver":
                        break;  

                }
            }
        }
    }
}
