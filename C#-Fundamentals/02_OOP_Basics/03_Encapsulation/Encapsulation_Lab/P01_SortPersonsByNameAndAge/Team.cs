using System.Collections.Generic;

public class Team
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private List<Person> firstTeam;

    public IReadOnlyCollection<Person> FirstTeam
    {
        get { return firstTeam; }
    }

    private List<Person> reserveTeam;

    public IReadOnlyCollection<Person> ReserveTeam
    {
        get { return reserveTeam; }
    }


    public Team()
    {
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();
    }
    public Team(string name):this()
    {
        this.name = name;
    }

    public void AddPlayer(Person person)
    {
        if (person.Age < 40)
        {
           firstTeam.Add(person);
        }
        else
        {
            reserveTeam.Add(person);
        }
    }

}