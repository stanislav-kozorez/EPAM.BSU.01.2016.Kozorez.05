using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.SortConditions
{
    public class SortByAuthor: IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return String.Compare(x.Author, y.Author);
        }
    }
}
