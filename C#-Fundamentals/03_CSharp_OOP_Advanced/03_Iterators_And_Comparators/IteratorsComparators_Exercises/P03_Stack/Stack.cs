using System;
using System.Collections;
using System.Collections.Generic;

public class Stack<T>:IEnumerable<T>
{
    private List<T> data;
    private int currentIndex;

    public Stack()
    {
        this.data = new List<T>();
    }

    public void Push(params T[] inputData)
    {
        this.currentIndex = this.data.Count + inputData.Length;

        for (int i = 0; i < inputData.Length; i++)
        {
            data.Add(inputData[i]);
        }
    }

    public void Pop()
    {
        if (MoveNext())
        {
           data.RemoveAt(currentIndex);
        }
        else
        {
            throw new ArgumentException("No elements");
        }
    }

    private bool MoveNext()
    {
        currentIndex--;
        return currentIndex >= 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.data.Count - 1; i >= 0; i--)
        {
            yield return this.data[i];
        }
        //for (int i = 0; i < this.data.Count; i++)
        //{
        //    yield return this.data[i];
        //}
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

