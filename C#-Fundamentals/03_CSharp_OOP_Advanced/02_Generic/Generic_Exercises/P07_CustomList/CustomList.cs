using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

public class CustomList<T> where T : IComparable<T>
{
    protected List<T> data;

    public CustomList(List<T> dataList)
    {
        this.data = dataList;
    }

    public void Add(T element) => data.Add(element);
    
    public void Remove(int index) => data.RemoveAt(index);
    
    public bool Contains(T element) =>   data.Contains(element);

    public T Max() => data.Max();

    public T Min() => data.Min();

    public void Swap(int index1, int index2)
    {
        var temp = data[index1];
        data[index1] = data[index2];
        data[index2] = temp;
    }

    public int CountGreaterThan(T element)
    {
        int count = 0;
        foreach (var el in data)
        {
            if ((el.CompareTo(element)) > 0)
            {
                count++;
            } 
        }
        return count;
    }

    public void Print()
    {
        Console.WriteLine(string.Join("\n",data));
    }
}
