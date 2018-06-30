using System;
public class Box<T> where T :IComparable<T>
{
    public Box(T element)
    {
        this.Element = element;
    }

    public T Element { get;private set; }

    public int CompareTo(Box<T> other)
    {
        return this.Element.CompareTo(other.Element);
    }
}



