public class Rectangle
{
    public Point TopLeft { get; set; }
    public Point BottomRight { get; set; }

    public Rectangle(int topX, int topY, int bottomX, int bottomY)
    {
        this.TopLeft = new Point(topX, topY);
        this.BottomRight = new Point(bottomX, bottomY);
    }

    public bool ContainsPoint(Point point)
    {
        var contains =
            point.X >= this.TopLeft.X && point.X <= this.BottomRight.X &&
            point.Y >= this.TopLeft.Y && point.Y <= this.BottomRight.Y;
        return contains;
    }
}