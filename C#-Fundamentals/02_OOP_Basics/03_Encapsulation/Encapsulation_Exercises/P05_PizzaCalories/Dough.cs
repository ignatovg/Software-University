using System;
using System.Security.Principal;

class Dough
{
    private const double WHITE = 1.5;
    private const double WHOLEGRAIN = 1.0;
    private const double CRYSPY = 0.9;
    private const double CHEWY = 1.1;
    private const double HOMEMADE = 1.0;

    private double flourType;
    private double bakingTechnique;
    private double weight;

    public double FlourType => flourType;

    public double BakingTechnique => bakingTechnique;

    public double Weight
    {
        get { return weight; }
    }

    public Dough()
    {

    }

    public Dough(string flourTypeInput, string techniqueInput, double weight)
    {
        if (flourTypeInput == "white")
        {
            this.flourType = WHITE;
        }
        else if (flourTypeInput == "wholegrain")
        {
            this.flourType = WHOLEGRAIN;
        }
        else
        {
            throw new ArgumentException("Invalid type of dough.");
        }

        if (techniqueInput == "crispy")
        {
            this.bakingTechnique = CRYSPY;
        }
        else if (techniqueInput == "chewy")
        {
            this.bakingTechnique = CHEWY;
        }
        else if (techniqueInput == "homemade")
        {
            this.bakingTechnique = HOMEMADE;
        }
        else
        {
            throw new ArgumentException("Invalid type of dough.");
        }

        if (weight < 1 || weight > 200)
        {
            throw new ArgumentException("Dough weight should be in the range [1..200].");
        }
        this.weight = weight;
    }

    public double CalculateCalories()
    {
        return (2 * weight) * flourType * bakingTechnique;
    }
}
