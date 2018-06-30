using System;
using System.Text;

public class Human
{
    private const int FirstNameMinLenght = 4;
    private const int LastNameMinLenght = 3;

    private const string CapitalLetterError = "Expected upper case letter! Argument: {0}";
    private const string LenghtError = "Expected length at least {0} symbols! Argument: {1}";
    private string firstName;
    private string lastName;

    public string FirstName
    {
        get { return firstName; }
        set
        {
            ValidateName(value,nameof(firstName),FirstNameMinLenght);
            firstName = value;
        }
    }
    
    public string LastName
    {
        get { return lastName; }
        set
        {
            ValidateName(value,nameof(lastName),LastNameMinLenght);
            lastName = value;
        }
    }

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    private static void ValidateName(string value, string type,int lenght)
    {
        if (char.IsLower(value[0]))
        {
            throw new ArgumentException(string.Format(CapitalLetterError,type));
        }
        if (value.Length < lenght)
        {
            throw new ArgumentException(string.Format(LenghtError,lenght,type));
        }
    }

    public override string ToString()
    {
        StringBuilder resultBuilder = new StringBuilder();
        resultBuilder.AppendLine($"First Name: {FirstName}")
            .AppendLine($"Last Name: {LastName}");

        string result = resultBuilder.ToString().TrimEnd();
        return result;
    }
}

