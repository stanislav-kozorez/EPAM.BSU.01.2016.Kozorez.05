﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.SortConditions
{
    public class SortByYear: IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x.Year > y.Year)
                return 1;
            else if (x.Year < y.Year)
                return -1;
            else return 0;
        }
    }
}
