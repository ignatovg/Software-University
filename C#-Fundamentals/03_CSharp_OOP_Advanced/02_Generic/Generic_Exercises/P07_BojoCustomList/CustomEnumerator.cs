using System.Collections;
using System.Collections.Generic;
public class CustomEnumerator<T>:IEnumerator<T>
{
    public bool MoveNext()
    {
        throw new System.NotImplementedException();
    }

    public void Reset()
    {
        throw new System.NotImplementedException();
    }

    public T Current { get; }

    object IEnumerator.Current
    {
        get { return Current; }
    }

    public void Dispose()
    {
        throw new System.NotImplementedException();
    }
}

