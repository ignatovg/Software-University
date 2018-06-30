using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06._1.BookLibralyModification
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Libraly myLibraly=new Libraly();
            myLibraly.Books=new List<Book>();
            myLibraly.Name = "George's libraly";

            int numberOfBooks=int.Parse(Console.ReadLine());

            for (int book = 0; book < numberOfBooks; book++)
            {
                string[] tokens = Console.ReadLine().Split(' ');
               
                Book myBook=new Book();
                myBook.Title = tokens[0];
                myBook.Author = tokens[1];
                myBook.Publisher = tokens[2];
                myBook.ReleaseDate=DateTime.ParseExact(tokens[3],"dd.MM.yyyy",
                    CultureInfo.InvariantCulture);
                myBook.IsbNnumber = tokens[4];
                myBook.Price = decimal.Parse(tokens[5]);

                myLibraly.Books.Add(myBook);
            }
            DateTime startDate=DateTime.ParseExact(Console.ReadLine(),"dd.MM.yyyy",CultureInfo.InvariantCulture);

            Dictionary<string,DateTime> filteredBooks=new Dictionary<string, DateTime>();

            for (int i = 0; i < myLibraly.Books.Count; i++)
            {
                if (!filteredBooks.ContainsKey(myLibraly.Books[i].Title))
                {
                   filteredBooks.Add(myLibraly.Books[i].Title,myLibraly.Books[i].ReleaseDate);
                }
                else
                {
                    filteredBooks[myLibraly.Books[i].Title] = myLibraly.Books[i].ReleaseDate;
                }
            }
            foreach (var book in filteredBooks.Where(a=>a.Value>startDate).OrderBy(a=>a.Value).ThenBy(a=>a.Key))
            {
                string date = book.Value.ToString("dd.MM.yyyy");
                Console.WriteLine($"{book.Key} -> {date}");
            }
        }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string IsbNnumber { get; set; }
        public decimal Price { get; set; }
    }

    class Libraly
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
