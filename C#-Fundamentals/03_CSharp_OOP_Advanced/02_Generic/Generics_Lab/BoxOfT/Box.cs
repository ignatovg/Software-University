using System;
using System.Collections.Generic;
using System.Linq;

public class Box<T>
{
    private List<T> data;

    public Box()
    {
     data = new List<T>();  
    }

    public int Count => data.Count;

    public void Add(T element) => data.Add(element);
    
    public T Remove()
    {
        var lastElement = data.Last();

        data.RemoveAt(data.Count-1);

        return lastElement;
    }
    
}
