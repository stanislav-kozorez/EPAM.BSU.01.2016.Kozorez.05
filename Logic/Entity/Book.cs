using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

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
    }
}
