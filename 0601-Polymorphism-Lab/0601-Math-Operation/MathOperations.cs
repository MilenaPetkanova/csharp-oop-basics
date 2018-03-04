using System.Linq;

public class MathOperations
{
    public int Add(int a, int b)
    {
        var result = a + b;
        return result;
    }

    public double Add(double a, double b, double c)
    {
        var result = a + b + c;
        return result;
    }

    public decimal Add(decimal a, decimal b, decimal c)
    {
        var result = a + b + c;
        return result;
    }
}