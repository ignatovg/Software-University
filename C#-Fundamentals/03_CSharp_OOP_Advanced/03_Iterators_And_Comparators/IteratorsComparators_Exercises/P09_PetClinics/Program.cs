using System;
using System.Collections.Generic;
using System.Linq;

namespace P09_PetClinics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pet> pets = new List<Pet>();
            List<PetClinic> petClinics = new List<PetClinic>();

            int commandCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                string[] commandInput = Console.ReadLine().Split();
                string command = commandInput[0];

                switch (command)
                {
                    case "Create":
                        string typeOFCreation = commandInput[1];
                        if (typeOFCreation == "Pet")
                        {
                            int age = int.Parse(commandInput[3]);
                            Pet pet = new Pet(commandInput[2], age, commandInput[4]);

                            pets.Add(pet);
                        }
                        else
                        {
                            int roomCount = int.Parse(commandInput[3]);
                            PetClinic clinic = new PetClinic(commandInput[2], roomCount);
                            petClinics.Add(clinic);
                        }

                        break;
                    case "Add":
                        Pet petAdd = pets.FirstOrDefault(p => p.Name == commandInput[1]);
                       
                        break;

                }

            }
        }
    }
}
