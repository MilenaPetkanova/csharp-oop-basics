using System;
using System.Linq;
using System.Text;

public class Book
{
    private string title;
    private string author;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public string Author
    {
        get { return this.author; }
        protected set
        {
            if (value.Any(c => char.IsDigit(c)))
            {
                throw new ArgumentException("Author not valid!");
            }
            this.author = value;
        }
    }

    public string Title
    {
        get { return this.title; }
        protected set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }

    public virtual decimal Price
    {
        get { return this.price; }
        protected set
        {
            if (value <= 0)
            { 
                throw new ArgumentException("Price not valid!");
            }
            this.price = value;
        }
    }

    public override string ToString()
    {
        var resultBuilder = new StringBuilder();
        resultBuilder.AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Title: {this.Title}")
            .AppendLine($"Author: {this.Author}")
            .AppendLine($"Price: {this.Price:f2}");

        string result = resultBuilder.ToString().TrimEnd();
        return result;

    }
}