using System;
using System.Collections.Generic;

public class Comparer<T> where T : IComparable<T>
{

    public static int CountGreater(Box<T> box, List<Box<T>> list)
    {
        int count = 0;
        foreach (var item in list)
        {
            if (box.CompareTo(item) < 0)
            {
                count++;
            }
        }
        return count;
    }
}

