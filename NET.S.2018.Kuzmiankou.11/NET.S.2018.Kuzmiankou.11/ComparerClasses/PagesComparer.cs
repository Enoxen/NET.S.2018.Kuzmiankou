using System;
using System.Collections.Generic;
using NET.S._2018.Kuzmiankou._11.Help;

namespace NET.S._2018.Kuzmiankou._11.ComparerClasses
{
    class PagesComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return NumbersCompare.CompareNumbers(x.NumberOfPages, y.NumberOfPages);
        }
    }
}
