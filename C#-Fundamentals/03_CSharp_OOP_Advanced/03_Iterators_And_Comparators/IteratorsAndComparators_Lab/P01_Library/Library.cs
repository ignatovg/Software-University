using System.Collections;
using System.Collections.Generic;

public class Library:IEnumerable<Book>
{
    private List<Book> books;

    public Library(params Book[] books)
    {
        this.books = new List<Book>(books);
    }
    
    public IEnumerator<Book> GetEnumerator()
    {
       // return new LibraryIterator(this.books);
        for (int i = 0; i < this.books.Count; i++)
        {
            yield return this.books[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class LibraryIterator : IEnumerator<Book>
    {
        private readonly List<Book> books;

        private int currentIndex;

        public Book Current => this.books[currentIndex];

        object IEnumerator.Current => this.Current;

        public LibraryIterator(List<Book> books)
        {
            this.Reset();
            this.books = new List<Book>(books);
        }

        public bool MoveNext()
        {
            currentIndex++;
            return currentIndex < this.books?.Count;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }

        public void Dispose()
        {
        }
    }
}

