using System;
using System.Text;

public class Book
{
    private string author;
    private string title;
    private decimal price;
    
    public string Author
    {
        get { return author; }
        set
        {
            string[] authorNames = value.Split();
            if (authorNames.Length==2 && Char.IsDigit(authorNames[1][0]))
            {
                throw new ArgumentException("Author not valid!");
            }
            author = value;
        }
    }
    

    protected string Title
    {
        get { return title; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            title = value;
        }
    }

    protected virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            price = value;
        }
    }

    public Book(string author, string title, decimal price )
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
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

