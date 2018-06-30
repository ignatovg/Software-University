using System.Text;
using System.Xml.Schema;

class Engine
{
    private const string Offset = "  ";

    public string Model;
    public int Power;
    public int Displacement;
    public string Efficiency;

    public Engine()
    {
        this.Displacement = -1;
        this.Efficiency = "n/a";
    }

    public Engine(string model, int power) : this()
    {
        this.Model = model;
        this.Power = power;
    }

    public Engine(string model, int power, int displacement, string efficiency)
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = displacement;
        this.Efficiency = efficiency;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("{0}{1}:\n", Offset, this.Model);
        sb.AppendFormat("{0}{0}Power: {1}\n", Offset, this.Power);
        sb.AppendFormat("{0}{0}Displacement: {1}\n", Offset, this.Displacement == -1 ? "n/a" : this.Displacement.ToString());
        sb.AppendFormat("{0}{0}Efficiency: {1}\n", Offset, this.Efficiency);

        return sb.ToString();
    }
}
