using System.Linq;

public class Smartphone : ICallFunctionality, IBrowseFunctionality
{
    public string PrintBrowsing(string url)
    {
        if (!url.Any(char.IsDigit))
        {
            return $"Browsing: {url}!";
        }
        else
        {
            return "Invalid URL!";
        }
    }

    public string PrintCalling(string number)
    {
        if (number.All(char.IsDigit))
        {
            return $"Calling... {number}";
        }
        else
        {
            return "Invalid number!";
        }
    }
}