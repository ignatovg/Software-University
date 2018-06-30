using System;

public abstract class Provider : Unit
{
    const double MAX_ENERGY_OUPUT = 10000;
    private double energyOutput;

    public Provider(string id, double energyOutput) : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get { return energyOutput; }
        private set
        {
            if (value < 0 || value >= MAX_ENERGY_OUPUT)
            {
                throw new ArgumentException($"Provider is not registered, because of it's {nameof(this.EnergyOutput)}");
            }
            energyOutput = value;
        }
    }

    public override string ToString()
    {
        return $"{this.Type} Provider - {this.Id}" + Environment.NewLine +
                $"Energy Output: {this.EnergyOutput}";
    }
}
