using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P10.BookLibraryModification
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

               books.Add(currentBook);

            }
            DateTime startDate=DateTime.ParseExact(input[input.Length-1],"dd.MM.yyyy",
                CultureInfo.InvariantCulture);

            File.WriteAllText("output.txt", string.Empty);

            foreach (var book in books.Where(a=>a.ReleaseDate>startDate).OrderBy(a=>a.ReleaseDate).ThenBy(a=>a.Title))
            {
                File.AppendAllText("output.txt",$"{book.Title} -> {book.ReleaseDate:dd.MM.yyyy}"+Environment.NewLine);
            }
        }
    }
}

