public class Rectangle : Shape
{
    public Rectangle(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public double Width { get; set; }

    public double Height  { get; set; }

    public override double CalculatePerimeter()
    {
        double result = 2 * (Width + Height);
        return result;
    }

    public override double CalculateArea()
    {
        double result = Width * Height;
        return result;
    }

    public override string Draw()
    {
        return base.Draw() + "Rectangle";
    }
}
