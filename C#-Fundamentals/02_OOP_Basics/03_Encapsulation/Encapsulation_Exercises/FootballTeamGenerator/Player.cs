using System;

class Player
{
    private string name;
    private  int endurance;
    private int sprint;
    private  int dribble;
    private int passing;
    private int shooting;

    public int Endurance
    {
        get { return endurance; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"Endurance should be between 0 and 100.");
            }
            this.endurance = value;
        }
    }

    public int Sprint
    {
        get { return sprint; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"Sprint should be between 0 and 100.");
            }
            sprint = value;
        }
    }

    public int Dribble
    {
        get { return dribble; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"Dribble should be between 0 and 100.");
            }
            dribble = value;
        }
    }

    public int Passing
    {
        get { return passing; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"Passing should be between 0 and 100.");
            }
            passing = value;
        }
    }

    public int Shooting
    {
        get { return shooting; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"Shooting should be between 0 and 100.");
            }
            shooting = value;
        }
    }
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

    public Player()
    {
        endurance = 0;
        sprint = 0;
        dribble = 0;
        Passing = 0;
        shooting = 0;
    }
    public Player(string name,int endurance, int sprint, int dribble, int passing, int shooting):this()
    {
        if (name == null) throw new ArgumentException("A name should not be empty.");
        Name = name;
        Endurance = endurance;
        Sprint = sprint;
        Dribble = dribble;
        Passing = passing;
        Shooting = shooting;
    }
   
    public double CalcSkillLevel()
    {
        var totalStats = (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;
        return Math.Round(totalStats);
    }
}
