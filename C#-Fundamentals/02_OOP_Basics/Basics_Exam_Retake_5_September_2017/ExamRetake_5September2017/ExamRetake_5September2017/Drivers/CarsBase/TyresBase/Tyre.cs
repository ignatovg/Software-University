public abstract class Tyre
{
    protected Tyre(string name, double hardness)
    {
        this.Name = name;
        this.Hardness = hardness;
        this.Degradation = 100;
    }
    public string Name { get; private set; }

    public double Hardness { get; private set; }

    public double Degradation { get; protected set;}

    public abstract void LabDegradate();
}

