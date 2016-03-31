using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.SortConditions
{
    public class SortByName : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return String.Compare(x.Name, y.Name);
        }
    }
}
