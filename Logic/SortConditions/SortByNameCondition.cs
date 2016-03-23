using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.SortConditions
{
    class SortByNameCondition : ISortCondition
    {
        public bool CheckCondition(Book b1, Book b2)
        {
            return String.Compare(b1.Name, b2.Name) == 1 ? true : false; 
        }
    }
}
