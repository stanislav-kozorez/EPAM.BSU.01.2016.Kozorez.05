using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.FindConditions
{
    interface IFindCondition
    {
        bool CheckCondition(Book book, string pattern);
    }
}
