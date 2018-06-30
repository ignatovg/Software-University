using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    class Program
    {
        private static List<Team> teams;
        static void Main(string[] args)
        {

            try
            {
                teams = new List<Team>();
                string commnad = string.Empty;
                while ((commnad = Console.ReadLine()) != "END")
                {
                    string[] tokens = commnad.Split(';');
                    string commandName = tokens[0];

                    switch (commandName)
                    {
                        case "Team":
                            try
                            {
                                if (tokens.Length == 1)
                                {
                                    Team team = new Team("");
                                    teams.Add(team);
                                }
                                else
                                {
                                    Team team = new Team(tokens[1]);
                                    teams.Add(team);
                                }

                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            break;
                        case "Add":
                            try
                            {
                                AddPlayer(teams, tokens);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            break;
                        case "Remove":
                            try
                            {
                                RemovePlayer(teams, tokens);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case "Rating":
                            try
                            {
                                ShowRating(teams, tokens);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                    }
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ShowRating(List<Team> teams, string[] tokens)
        {
            string teamName = tokens[1];
            var currentTeam = teams.Find(n => n.Name == teamName);
            Console.WriteLine(currentTeam.ToString());
        }

        private static void RemovePlayer(List<Team> teams, string[] tokens)
        {
            string teamName = tokens[1];
            string playerName = tokens[2];

            var currentTeam = teams.Find(n => n.Name == teamName);
            currentTeam.RemovePlayer(playerName);

        }

        private static void AddPlayer(List<Team> teams, string[] tokens)
        {
            string teamName = tokens[1];
            string playerName = tokens[2];
            //<Endurance>;<Sprint>;<Dribble>;<Passing>;<Shooting>
            int endurance = int.Parse(tokens[3]);
            int sprint = int.Parse(tokens[4]);
            int dribble = int.Parse(tokens[5]);
            int passing = int.Parse(tokens[6]);
            int shooting = int.Parse(tokens[7]);

            //todo refactor this 
            if (!teams.Any(n => n.Name == teamName))
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }
            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
            var currentTeam = teams.Find(a => a.Name == teamName);
            currentTeam.AddPlayer(player);
        }
    }
}
