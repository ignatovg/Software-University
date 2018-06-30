using System.Collections.Generic;
using System.Linq;

public class StackOfStrings
{
    private List<string> data = new List<string>();

    public bool IsEmpty()
    {
        return data.Count == 0;
    }

    public void Push(string input)
    {
        data.Add(input);
    }

    public string Peek()
    {
        string element = string.Empty;
        if (!IsEmpty())
        {
            element = data.Last();
        }
        return element;
    }
    public string Pop()
    {
        string element = string.Empty;
        if (!IsEmpty())
        {
            element = data.Last();
            data.Remove(element);
        }
        return element;
    }
}

