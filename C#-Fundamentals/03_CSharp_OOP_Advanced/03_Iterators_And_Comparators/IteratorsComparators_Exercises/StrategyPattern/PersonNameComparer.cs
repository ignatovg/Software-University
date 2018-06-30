using System;
using System.Collections.Generic;

public class PersonNameComparer:IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        int result = x.Name.Length.CompareTo(y.Name.Length);

        if (result == 0)
        {
            var xName = Char.ToLower(x.Name[0]);
            var yName = Char.ToLower(y.Name[0]);

            result = xName.CompareTo(yName);
        }
        return result;
    }
}
