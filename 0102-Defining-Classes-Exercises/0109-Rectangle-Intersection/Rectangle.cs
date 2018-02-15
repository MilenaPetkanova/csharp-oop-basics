using System;

public class Rectangle
{
    private string id;
    private double width;
    private double height;
    private double x;
    private double y;

    public double Y
    {
        get { return y; }
        set { y = value; }
    }

    public double X
    {
        get { return x; }
        set { x = value; }
    }

    public double Height
    {
        get { return height; }
        set { height = value; }
    }

    public double Width
    {
        get { return width; }
        set { width = value; }
    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public bool IntersectsWith(Rectangle r2)
    {
        if ((this.X > r2.X + r2.Width) || 
            (this.X + this.Width < r2.X) || 
            (this.Y > r2.Y + r2.Height) ||
           (this.Y + this.Height < r2.Y))
        {
            return false;
        }
        else
	{
            return true;
        }
    }
}
