using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.BookLibrary
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Book> books = new List<Book>();
            for (int i = 0; i < n; i++)
            {

                string[] tokens = Console.ReadLine().Split(' ');
                Book book = new Book
                {
                    Title = tokens[0],
                    Author = tokens[1],
                    Publisher = tokens[2],
                    ReleaseDate = DateTime.ParseExact(tokens[3], "dd.MM.yyyy", CultureInfo.InvariantCulture),
                    ISBNNumber = tokens[4],
                    Price = double.Parse(tokens[5])

                };
                bool isContained = false;
                int index = 0;
               
                for (int k = 0; k < books.Count; k++)
                {
                    if (books[k].Author == tokens[1])
                    {
                        isContained = true;
                        index = k;
                        break;
                    }
                }

                if (isContained)
                {
                    books[index].Price += double.Parse(tokens[5]);
                }
                else
                {
                    books.Add(book);
                }
            }

            foreach (var book in books.OrderByDescending(a=>a.Price).ThenBy(a=>a.Author))
            {
                Console.WriteLine($"{book.Author} -> {book.Price:f2}");
            }
        }
    }

    class Library
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBNNumber { get; set; }
        public double Price { get; set; }

    }
}
