using System;

public class UltrasoftTyre : Tyre
{
    public UltrasoftTyre(double hardness, double grip) : base("Ultrasoft", hardness)
    {
        this.Grip = grip;
    }

    public double Grip { get; }

    public override double Degradation
    {
        get => this.Degradation;
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException(OutputMesseges.BlownTyre);
            }
            base.Degradation = value;
        }
    }

    public override void CompleteLab()
    {
        base.CompleteLab();
        this.Degradation -= this.Grip;

    }
}

