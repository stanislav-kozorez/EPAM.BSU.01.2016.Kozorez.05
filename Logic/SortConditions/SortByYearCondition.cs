using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.SortConditions
{
    class SortByYearCondition: ISortCondition
    {
        public bool CheckCondition(Book b1, Book b2)
        {
            return b1.Year > b2.Year;
        }
    }
}
