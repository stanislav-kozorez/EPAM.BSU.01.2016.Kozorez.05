using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using Logic.BookManagers;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BookLibrary bookLibrary = new BookLibrary();

            bookLibrary.AddBook(new Book("C# via CLR", "Jeffrey Richter", 2013));
            bookLibrary.AddBook(new Book("C# via CLR", "Jeffrey Richter", 2010));
            bookLibrary.AddBook(new Book("Test Book", "Фамилия автора", 2007));
            bookLibrary.AddBook(new Book("C# 4.0", "Bart De Smet", 2010));
            bookLibrary.AddBook(new Book("Book name", "Автор 2", 2007));

            Console.WriteLine($"Books count: {bookLibrary.Books.Count}");
            bookLibrary.RemoveBook(new Book("Test Book", "Фамилия автора", 2007));
            Console.WriteLine($"Books count: {bookLibrary.Books.Count}");

            bookLibrary.Save(new BinaryManager("books.dat"));
            bookLibrary.RemoveBook(new Book("C# via CLR", "Jeffrey Richter", 2010));
            Console.WriteLine($"Books count: {bookLibrary.Books.Count}\n");
            bookLibrary.Load(new BinaryManager("books.dat"));
            bookLibrary.AddBook(new Book("Паттерны проектирования на платформе .NET", "Тепляков Сергей", 2015));

            foreach (var book in bookLibrary.Books)
            {
                Console.WriteLine($"Название: {book.Name}\nАвтор: {book.Author}\nГод: {book.Year}\n------------");
            }

            Console.WriteLine($"\nFound books count: {bookLibrary.FindBooks((x) => { return String.Compare(x.Author, "Jeffrey Richter") == 0; }).Count}\n");

            bookLibrary.SortBooks();

            foreach (var book in bookLibrary.Books)
            {
                Console.WriteLine($"Название: {book.Name}\nАвтор: {book.Author}\nГод: {book.Year}\n------------");
            }

            
            Console.WriteLine();
            bookLibrary.SortBooks(new Logic.SortConditions.SortByAuthor());
            foreach (var book in bookLibrary.Books)
            {
                Console.WriteLine($"Название: {book.Name}\nАвтор: {book.Author}\nГод: {book.Year}\n------------");
            }
            Console.ReadKey();
        }
    }
}
