using System;
using System.Collections.Generic;
using Logic.FindConditions;
using Logic.SortConditions;
using Logic.BookManagers;

namespace Logic
{
    public sealed class BookLibrary
    {
        private List<Book> books = new List<Book>();
        private readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public List<Book> Books { get { return new List<Book>(books); } }

        public List<Book> Load(IBookManager bookManager)
        {
            if(bookManager == null)
            {
                logger.Error($"{nameof(bookManager)} is null");
                throw new ArgumentNullException($"{nameof(bookManager)} is null");
            }
            books = bookManager.Load();
            return books;
        }

        public void Save(IBookManager bookManager)
        {
            if (bookManager == null)
            {
                logger.Error($"{nameof(bookManager)} is null");
                throw new ArgumentNullException($"{nameof(bookManager)} is null");
            }
            bookManager.Save(books);
        }

        public void AddBook(Book book)
        {
            if (book == null)
            {
                logger.Error($"Argument {nameof(book)} is null");
                throw new ArgumentNullException($"Argument {nameof(book)} is null");
            }
            if (books.Contains(book))
            {
                logger.Error($"Attempt to add book that already exists in the library");
                throw new ArgumentException("The book is already exists in the library");
            }
            books.Add(book);
            logger.Info("New Book was added");
        }

        public bool RemoveBook(Book book)
        {
            if (book == null)
            {
                logger.Error($"Argument {nameof(book)} is null");
                throw new ArgumentNullException($"Argument {nameof(book)} is null");
            }
            logger.Info("Attempt to remove book");
            return books.Remove(book);
        }

        public List<Book> FindBooks(Predicate<Book> predicate)
        {
            List<Book> result = new List<Book>();
            foreach (var book in books)
            {
                if (predicate(book))
                    result.Add(book);
            }
            logger.Info("Find Method");
            return result;
        }

        public List<Book> SortBooks(IComparer<Book> comparer = null)
        {
            IComparer<Book> c = comparer ?? Comparer<Book>.Default;

            for (int i = 0; i < books.Count - 1; i++)
                for (int j = i + 1; j < books.Count; j++)
                    if (c.Compare(books[i], books[j]) > 0)
                        Swap(i, j);
            logger.Info("Sort Method");
            return new List<Book>(books);
        }

        private void Swap(int i, int j)
        {
            Book temp = books[i];
            books[i] = books[j];
            books[j] = temp;
        }
    }
}
