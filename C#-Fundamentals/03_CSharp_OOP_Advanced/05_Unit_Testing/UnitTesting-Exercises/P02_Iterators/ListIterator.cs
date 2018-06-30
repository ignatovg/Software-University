using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerable<T>
{
    private IReadOnlyList<T> data;
    private int currnetIndex;

    public ListyIterator()
    {
        this.currnetIndex = 0;
    }

    public void Create(params T[] data)
    {
        this.data = new List<T>(data);
    }

    public bool Move()
    {
        if (HasNext())
        {
            currnetIndex++;
            return true;
        }
        return false;
    }

    public bool HasNext()
    {
        if (currnetIndex + 1 < data.Count)
        {
            return true;
        }
        return false;
    }

    public void Print()
    {
        if (data.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        Console.WriteLine(data[currnetIndex]);
    }

    public void PrintAll()
    {
        if (data.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        Console.WriteLine(string.Join(" ", this.data));
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < data.Count; i++)
        {
            yield return this.data[currnetIndex];

        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
