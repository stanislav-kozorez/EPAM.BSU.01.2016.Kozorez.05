using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BookLibrary.AddBook(new Book("C# via CLR", "Jeffrey Richter", 2013));
            BookLibrary.AddBook(new Book("C# via CLR", "Jeffrey Richter", 2010));
            BookLibrary.AddBook(new Book("Test Book", "Фамилия автора", 2007));
            BookLibrary.AddBook(new Book("C# 4.0", "Bart De Smet", 2010));
            BookLibrary.AddBook(new Book("Book name", "Автор 2", 2007));

            Console.WriteLine($"Books count: {BookLibrary.Books.Count}");
            BookLibrary.RemoveBook(new Book("Test Book", "Фамилия автора", 2007));
            Console.WriteLine($"Books count: {BookLibrary.Books.Count}");

            BookLibrary.SaveToFile("books.dat");
            BookLibrary.RemoveBook(new Book("C# via CLR", "Jeffrey Richter", 2010));
            Console.WriteLine($"Books count: {BookLibrary.Books.Count}\n");
            BookLibrary.LoadFromFile("books.dat");
            BookLibrary.AddBook(new Book("Паттерны проектирования на платформе .NET", "Тепляков Сергей", 2015));

            foreach (var book in BookLibrary.Books)
            {
                Console.WriteLine($"Название: {book.Name}\nАвтор: {book.Author}\nГод: {book.Year}\n------------");
            }

            Console.WriteLine($"\nFound books count: {BookLibrary.FindBooks("C# via CLR", FindTag.Name).Count}\n");

            BookLibrary.SortBooks(SortTag.Year);

            foreach (var book in BookLibrary.Books)
            {
                Console.WriteLine($"Название: {book.Name}\nАвтор: {book.Author}\nГод: {book.Year}\n------------");
            }
            Console.ReadKey();
        }
    }
}
