using System;
using System.Collections.Generic;
using System.Text;

public class Parallelepiped
{
    private double length;

    public double Length
    {
        get { return length; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Length cannot be zero or negative.");
            }
            this.length = value;
        }
    }

    private double width;

    public double Width
    {
        get { return width; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Width cannot be zero or negative.");
            }
            this.width = value;
        }
    }

    private double height;

    public double Height
    {
        get { return height; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Height cannot be zero or negative.");
            }
            this.height = value;
        }
    }


    public Parallelepiped()
    {
        
    }
    public Parallelepiped(double lenght, double width, double height)
    {
        this.Length = lenght;
        this.Width = width;
        this.Height = height;
    }
    

    public double CalculateSurface()
    {
        //Volume = lwh
       // Lateral Surface Area = 2lh + 2wh
       // Surface Area = 2lw + 2lh + 2wh
        return 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
    }

    public double CalcualateLateralSurface()
    {
        return 2 * Length * Height + 2 * Width * Height;
    }

    public double CalculateVolume()
    {
        return Length * Width * Height;
    }
}
