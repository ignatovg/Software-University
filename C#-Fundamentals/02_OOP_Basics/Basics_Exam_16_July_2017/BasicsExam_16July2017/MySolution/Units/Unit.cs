using System;

public abstract class Unit
{
    protected Unit(string id)
    {
        this.Id = id;
    }

    public string Id { get; set; }

    public abstract string Type { get; }
}

