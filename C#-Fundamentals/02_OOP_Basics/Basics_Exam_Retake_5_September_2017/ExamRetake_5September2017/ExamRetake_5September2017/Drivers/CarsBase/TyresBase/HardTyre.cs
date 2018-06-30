using System;

public class HardTyre:Tyre
{
    public HardTyre(double hardness) : base("Hard", hardness)
    {
    }

    public override void LabDegradate()
    {
        this.Degradation = this.Degradation - this.Hardness;

        if (this.Degradation < 0)
        {
            throw new ArgumentException("Blown Tyre");
        }
    }
}

