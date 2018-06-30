using System;

public class Ferrari:ICar
{
    public string Name { get; }
    public string Model { get; } = "488-Spider";

    public Ferrari(string name)
    {
       this.Name = name;
    }
    public void Brakes()
    {
        Console.Write("/Brakes!");
    }

    public void Gas()
    {
        Console.Write("/Zadu6avam sA!");
    }

    public void PrintOutput()
    {
        Console.Write(this.Model);
        Brakes();
        Gas();
        Console.WriteLine($"/{this.Name}");
    }
}

