using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.SortConditions
{
    interface ISortCondition
    {
        bool CheckCondition(Book b1, Book b2);
    }
}
