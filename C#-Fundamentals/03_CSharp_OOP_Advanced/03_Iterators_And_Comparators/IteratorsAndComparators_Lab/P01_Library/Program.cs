using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Linq;

namespace P01_Library
{
    class Program
    {
        private static IEnumerable<object> libraryFull;

        public static void Main()
        {
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);
            
            var books = new List<Book>{bookOne,bookTwo,bookThree};
            books.Sort(new BookComparator());

            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
