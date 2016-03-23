using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.SortConditions
{
    class SortByAuthorCondition: ISortCondition
    {
        public bool CheckCondition(Book b1, Book b2)
        {
            return String.Compare(b1.Author, b2.Author) == 1 ? true : false;
        }
    }
}
