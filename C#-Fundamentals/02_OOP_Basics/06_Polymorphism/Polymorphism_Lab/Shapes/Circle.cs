using System;

public class Circle : Shape
{
    public Circle( double radius)
    {
        this.Radius = radius;
    }

    public  double Radius { get; set; }

    public override double CalculatePerimeter()
    {
        double result =2 * Math.PI * Radius;
        return result;
    }

    public override double CalculateArea()
    {
        double result = Math.PI * Radius * Radius;
        return result;
    }

    public override string Draw()
    {
        return base.Draw() + "Circle";
    }
}

