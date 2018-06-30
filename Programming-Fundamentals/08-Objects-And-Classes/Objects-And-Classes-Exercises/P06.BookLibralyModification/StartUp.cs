using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.BookLibralyModification
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            List<Book> books=new List<Book>();
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
                books.Add(book);
            }
            DateTime startDate=DateTime.ParseExact(Console.ReadLine(),"dd.MM.yyyy",
                CultureInfo.InvariantCulture);

            foreach (var book in books.Where(a=>a.ReleaseDate>startDate).OrderBy(a=>a.ReleaseDate).ThenBy(a=>a.Title))
            {
                Console.WriteLine($"{book.Title} -> {book.ReleaseDate:dd.MM.yyyy}");   
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
