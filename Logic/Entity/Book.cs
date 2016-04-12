using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    [Serializable]
    public class Book: IComparable<Book>
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public Book() { }
        public Book(string name, string author, int year)
        {
            Name = name;
            Author = author;
            Year = year;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            if (obj.GetType() != typeof(Book))
                return false;
            Book b = (Book)obj;
            return String.Compare(Name, b.Name, true) == 0 && String.Compare(Author, b.Author, true) == 0 && Year == b.Year;
        }

        public int CompareTo(Book other)
        {
            if (Year > other.Year)
                return 1;
            else if (Year < other.Year)
                return -1;
            else return 0;
        }
    }
}
