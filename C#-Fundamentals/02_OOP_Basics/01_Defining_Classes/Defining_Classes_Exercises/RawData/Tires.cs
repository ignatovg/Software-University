using System.Collections.Generic;

public class Tires
{
    public List<int> ageTires { get;}
    public List<double> pressureTires { get;}

    public Tires()
    {
        this.ageTires=new List<int>();
        this.pressureTires=new List<double>();
    }

    public void AddPressureTires(double t1, double t2, double t3, double t4)
    {
        pressureTires.Add(t1);
        pressureTires.Add(t2);
        pressureTires.Add(t3);
        pressureTires.Add(t4);
    }
}