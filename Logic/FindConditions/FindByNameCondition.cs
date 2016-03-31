using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.FindConditions
{
    class FindByNameCondition
    {
        public bool CheckCondition(Book book, string pattern)
        {
            return String.Compare(book.Name, pattern, true) == 0;
        }
    }
}
