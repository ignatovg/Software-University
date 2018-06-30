using System;
using System.Collections.Generic;

namespace P05_BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ICitizen> strangers = new List<ICitizen>();
           
            string readnInput = string.Empty;
            while ((readnInput = Console.ReadLine()) != "End")
            {
                string[] tokens = readnInput.Split();
               

                if (tokens[0] == "Citizen")
                {
                    Human stranger = new Human();
                    stranger.SetCitizenData(tokens[1], int.Parse(tokens[2]), tokens[3],tokens[4]);
                    strangers.Add(stranger);

                }
                else if (tokens[0] == "Robot")
                {
                    Human stranger = new Human();
                    stranger.SetRobotData(tokens[1],tokens[2],"forever");
                    strangers.Add(stranger);

                }else if (tokens[0] == "Pet")
                {
                    Human stranger = new Human();
                    stranger.SetPetData(tokens[1],tokens[2]);
                    strangers.Add(stranger);
                }
            }
            string sprecialNums = Console.ReadLine();

            foreach (var stranger in strangers)
            {
             //   var stranger = (Stranger) citizen;
                if (stranger.Birthdate.EndsWith(sprecialNums))
                {
                    Console.WriteLine(stranger.Birthdate);
                }
            }
        }
    }
}
