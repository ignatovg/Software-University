using System.Collections.Generic;

public class BookComparator : IComparer<Book>
{
    public int Compare(Book x, Book y)
    {
        var result = x.Year.CompareTo(y.Year) * -1;
        if (result == 0) x.Title.CompareTo(y.Title);
        return result;
    }
}

