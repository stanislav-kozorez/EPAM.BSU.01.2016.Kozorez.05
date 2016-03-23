using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.FindConditions
{
    class FindByAuthorCondition: IFindCondition
    {
        public bool CheckCondition(Book book, string pattern)
        {
            return String.Compare(book.Author, pattern, true) == 0;
        }
    }
}
