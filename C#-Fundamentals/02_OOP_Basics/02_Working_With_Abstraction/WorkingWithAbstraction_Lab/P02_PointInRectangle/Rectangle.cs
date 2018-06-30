class Rectangle
{
    public Point TopLeft { get; set; }
    public Point BottomRight { get; set; }

    public Rectangle(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY)
    {
        this.TopLeft = new Point{X = topLeftX, Y = topLeftY};
        this.BottomRight = new Point{X = bottomRightX, Y = bottomRightY};
    }
    public bool Contains(Point point)
    {
        return TopLeft.X <= point.X && TopLeft.Y <= point.Y
               && BottomRight.X >= point.X && BottomRight.Y >= point.Y;
    }
}



