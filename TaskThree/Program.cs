using System.Reflection;
using static System.Reflection.Metadata.BlobBuilder;

namespace TaskThree
{
    internal class Program
    {
        class Book{
            string title;
            string author;
            string isbn;
            bool availability;

            public Book(string title,string author, string isbn,bool availability=true)
            {
                this.title= title;
                this.author = author;
                this.isbn = isbn;
                this.availability = availability;
            }
            public string GetTitle() { return title; }
            public string GetAuthor() { return author; }
            public string GetIsbn() { return isbn; }
            public bool GetAvailability() { return availability; }

            public void SetTitle(string title) { this.title = title; }
            public void SetAuthor(string author) { this.author = author; }
            public void SetIsbn(string isbn) { this.isbn = isbn; }
            public void SetAvailability(bool availability) { this.availability = availability; }

        }
        class Library
        {
            public List<Book> books = new List<Book>();
            
            public void AddBook(Book book)
            {
                books.Add(book);
                Console.WriteLine($"this book \"{books[^1].GetTitle()}\" is added success.");
            }
            public bool SearchBook(string tit)
            {
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].GetTitle() == tit || books[i].GetAuthor() == tit)
                    {
                        return true;
                    }
                }
              return false;
            }
            public bool BorrowBook(string tit)
            {
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].GetTitle() == tit || books[i].GetAuthor() == tit)
                    {
                        books[i].SetAvailability(false);
                        return true;
                    }
                }
                return false;
            }
        
            public bool ReturnBook(string tit)
            {
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].GetTitle() == tit || books[i].GetAuthor() == tit)
                    {
                        books[i].SetAvailability(true);
                        return true;
                    }
                }
                return false;
            }
           
        }
        static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library
            Console.WriteLine("-----------------Adding books to the library---------------------");
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));
            library.AddBook(new Book("maxFilm", "amin mohamed", "9780451524937"));
           
          
            //===================================
            Console.WriteLine("----------------Searching books----------------------");
            Console.WriteLine("Searching books...");
            if (library.SearchBook("George Orwell"))
                Console.WriteLine("This book is in the library");
            else
                Console.WriteLine("This book is not in the library");
            //------------------------
            if (library.SearchBook("Harry Potter"))
                Console.WriteLine("This book is in the library");
            else
                Console.WriteLine("This book is not in the library");

            //===================================
            Console.WriteLine("----------------Borrowing books----------------------");
            Console.WriteLine("borrowing books...");

            if (library.BorrowBook("maxFilm"))
                Console.WriteLine("This book has been borrowed.");
            else
                Console.WriteLine("This book is not in the library");

            //===================================
            Console.WriteLine("----------------Returning books----------------------");
            Console.WriteLine("Returning books...");

            if (library.ReturnBook("To Kill a Mockingbird"))
                Console.WriteLine("The borrowed book has been returned again.");
            else
                Console.WriteLine("This book is not borrowed");

            //===================================

            for (int i = 0; i < library.books.Count; i++)
            {
                Console.WriteLine(library.books[i].GetTitle());
                Console.WriteLine(library.books[i].GetAuthor());
                Console.WriteLine(library.books[i].GetIsbn());
                Console.WriteLine(library.books[i].GetAvailability());
                Console.WriteLine("=======================");

            }

            Console.ReadLine();
        }

    }
}
