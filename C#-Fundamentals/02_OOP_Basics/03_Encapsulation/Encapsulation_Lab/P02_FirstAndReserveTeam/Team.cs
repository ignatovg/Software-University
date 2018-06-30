using System.Collections.Generic;

class Team
{
    public string Name { get; private set; }
    public List<string> FirstTeam { get; private set; }
    public List<string> ReserveTeam { get; private set; }

    public Team()
    {
        this.FirstTeam = new List<string>();
        this.ReserveTeam = new List<string>();
    }
    public Team(string name)
    {
        Name = name;
    }

    public void AddPlayer(Person person)
    {
        
    }

}
