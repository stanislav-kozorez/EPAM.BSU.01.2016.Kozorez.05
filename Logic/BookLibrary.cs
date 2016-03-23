using System;
using System.Collections.Generic;
using Logic.FindConditions;
using Logic.SortConditions;
using Logic.BookManagers;

namespace Logic
{
    public enum SortTag
    {
        Name,
        Author,
        Year
    }

    public enum FindTag
    {
        Name,
        Author,
        Year
    }

    public static class BookLibrary
    {
        private static readonly IBookManager DEFAULT_BOOK_MANAGER = new BookManagers.BinaryManager();
        private static List<Book> books = new List<Book>();
        private static IBookManager currentBookManager = DEFAULT_BOOK_MANAGER;
        private static readonly Dictionary<FindTag, IFindCondition> findConditions;
        private static readonly Dictionary<SortTag, ISortCondition> sortConditions;
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static List<Book> Books { get { return new List<Book>(books); } }

        public static IBookManager CurrentBookManager
        {
            get
            {
                return currentBookManager;
            }
            set
            {
                currentBookManager = (value) ?? DEFAULT_BOOK_MANAGER;
            }
        }

        static BookLibrary()
        {
            findConditions = new Dictionary<FindTag, IFindCondition>()
            {
                { FindTag.Name,  new FindByNameCondition() },
                { FindTag.Author,  new FindByAuthorCondition() },
                { FindTag.Year,  new FindByYearCondition() },
            };

            sortConditions = new Dictionary<SortTag, ISortCondition>()
            {
                { SortTag.Name,  new SortByNameCondition() },
                { SortTag.Author,  new SortByAuthorCondition() },
                { SortTag.Year,  new SortByYearCondition() },
            };
        }

        public static List<Book> LoadFromFile(string fileName)
        {
            if (fileName == null)
            {
                logger.Error($"{nameof(fileName)} is null");
                throw new ArgumentNullException($"{nameof(fileName)} is null");
            }
            books = currentBookManager.LoadFile(fileName);
            return books;
        }

        public static void SaveToFile(string fileName)
        {
            if (fileName == null)
            {
                logger.Error($"{nameof(fileName)} is null");
                throw new ArgumentNullException($"{nameof(fileName)} is null");
            }
            currentBookManager.SaveToFile(fileName, books);
        }

        public static void AddBook(Book book)
        {
            if (book == null)
            {
                logger.Error($"Argument {nameof(book)} is null");
                throw new ArgumentNullException($"Argument {nameof(book)} is null");
            }
            books.Add(book);
            logger.Info("New Book was added");
        }

        public static bool RemoveBook(Book book)
        {
            if (book == null)
            {
                logger.Error($"Argument {nameof(book)} is null");
                throw new ArgumentNullException($"Argument {nameof(book)} is null");
            }
            logger.Info("Book was deleted");
            return books.Remove(book);
        }

        public static List<Book> FindBooks(string pattern, FindTag tag)
        {
            List<Book> result = new List<Book>();
            foreach (var book in books)
            {
                if (findConditions[tag].CheckCondition(book, pattern))
                    result.Add(book);
            }
            logger.Info("Find Method");
            return result;
        }

        public static List<Book> SortBooks(SortTag tag)
        {
            for (int i = 0; i < books.Count - 1; i++)
                for (int j = i + 1; j < books.Count; j++)
                    if (sortConditions[tag].CheckCondition(books[i], books[j]))
                        Swap(i, j);
            logger.Info("Sort Method");
            return new List<Book>(books);
        }

        private static void Swap(int i, int j)
        {
            Book temp = books[i];
            books[i] = books[j];
            books[j] = temp;
        }
    }
}
