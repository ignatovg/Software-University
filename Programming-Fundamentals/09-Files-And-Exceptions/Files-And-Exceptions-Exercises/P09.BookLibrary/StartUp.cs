using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P09.BookLibrary
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }

    }
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            int n = int.Parse(input[0]);

            List<Book> books = new List<Book>();

            for (int i = 1; i <= n; i++)
            {
                string[] tokens = input[i].Split(' ');

                Book currentBook = new Book();
                currentBook.Title = tokens[0];
                currentBook.Author = tokens[1];
                currentBook.Publisher = tokens[2];
                currentBook.ReleaseDate = DateTime.ParseExact(tokens[3], "dd.MM.yyyy",
                    CultureInfo.InvariantCulture);
                currentBook.ISBN = tokens[4];
                currentBook.Price = double.Parse(tokens[5]);

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
                    books.Add(currentBook);
                }
              

            }
            File.WriteAllText("output.txt",string.Empty);
            foreach (var book in books.OrderByDescending(a=>a.Price).ThenBy(a=>a.Author))
            {
               File.AppendAllText("output.txt",$"{book.Author} -> {book.Price}"+Environment.NewLine);
            }

        }
    }
}
