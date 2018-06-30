using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainersDict = new Dictionary<string, Trainer>();
            //“<TrainerName> <PokemonName> <PokemonElement> <PokemonHealth>
            string command;
            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] tokens = command.Split();
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                if (!trainersDict.ContainsKey(trainerName))
                {
                    trainersDict[trainerName] = new Trainer();
                }
                Pokemon currentPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                trainersDict[trainerName].Pokemon.Add(currentPokemon);
            }

            while ((command = Console.ReadLine()) != "End")
            {
                foreach (string tainerName in trainersDict.Keys)
                {
                    if (trainersDict[tainerName].Pokemon.Any(a => a.Element == command))
                    {
                        trainersDict[tainerName].ReceiveBadge();
                    }
                    else
                    {
                        trainersDict[tainerName].LosePokemonsHealth();

                        trainersDict[tainerName].Pokemon.RemoveAll(a => a.Health <= 0);
                    }
                }
            }

            foreach (KeyValuePair<string, Trainer> pair in trainersDict.OrderByDescending(a=>a.Value.Badges))
            {
                string name = pair.Key;
                Trainer trainer = pair.Value;

                Console.WriteLine($"{name} {trainer.Badges} {trainer.Pokemon.Count}");
            }
        }
    }
}
