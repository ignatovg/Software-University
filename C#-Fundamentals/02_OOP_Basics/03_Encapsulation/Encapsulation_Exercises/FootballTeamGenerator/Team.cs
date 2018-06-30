using System;
using System.Collections.Generic;
using System.Linq;

class Team
{
    private string name;
    public List<Player> Players { get; private set; }
    public int Rating { get;private set; }

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            name = value;
        }
    }

    public Team(string name)
    {
        this.Name = name;
        Players = new List<Player>();
        Rating = 0;
    }
    public void AddPlayer(Player player)
    {
        Players.Add(player);
    }
    public  void RemovePlayer(string playerName)
    {
        if (Players.Any(n => n.Name == playerName))
        {
            //possible bug
            Players.RemoveAll(a => a.Name == playerName);
        }
        else
        {
            throw new ArgumentException($"Player {playerName} is not in {name} team.");
        }
    }

    public double ShowStats()
    {
        double totalStats = 0;
        foreach (Player player in Players)
        {
            totalStats += player.CalcSkillLevel();
        }
        return totalStats;
    }

    public override string ToString()
    {
        return $"{name} - {ShowStats()}";
    }
}
