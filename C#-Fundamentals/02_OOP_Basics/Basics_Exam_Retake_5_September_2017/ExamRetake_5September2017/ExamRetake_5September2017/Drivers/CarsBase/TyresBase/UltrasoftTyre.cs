using System;
using System.Runtime.InteropServices.ComTypes;

public class UltrasoftTyre : Tyre
{
    public UltrasoftTyre(double hardness,double grip) : base("Ultrasoft", hardness)
    {
        this.Grip = grip;
        
    }

    public double Grip { get; private set; }


    public override void LabDegradate()
    {
        this.Degradation = this.Degradation - (this.Hardness + this.Grip);

        if (this.Degradation < 30)
        {
            throw new ArgumentException("Blown Tyre");
        }
    }
}

