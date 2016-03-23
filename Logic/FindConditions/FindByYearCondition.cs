using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.FindConditions
{
    class FindByYearCondition: IFindCondition
    {
        public bool CheckCondition(Book book, string pattern)
        {
            return book.Year == int.Parse(pattern);
        }
    }
}
