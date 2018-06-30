using System;

public abstract class Tyre
{
    private double degradation;

    protected Tyre(string name, double hardness)
    {
        this.Name = name;
        this.Hardness = hardness;
        Degradation = 100;
    }

    public string Name { get; }

    public double Hardness { get; }

    public virtual double Degradation
    {
        get => this.degradation;
        protected set
        {
            if (value< 0)
            {
                throw new ArgumentException(OutputMesseges.BlownTyre);
            }
            this.degradation = value;
        }
    }

    public virtual void CompleteLab()
    {
        this.Degradation -= this.Hardness;
    }
}

