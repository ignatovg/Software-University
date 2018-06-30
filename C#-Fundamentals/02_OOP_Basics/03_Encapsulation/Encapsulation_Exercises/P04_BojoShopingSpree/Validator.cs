using System;

public static class Validator
{
    public static void ValidateMoney(decimal value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Money cannot be negative");
        }
    }

    public static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty");
        }
    }
}
