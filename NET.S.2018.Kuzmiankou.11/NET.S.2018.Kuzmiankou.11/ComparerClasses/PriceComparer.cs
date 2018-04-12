using System;
using NET.S._2018.Kuzmiankou._11.Help;
using System.Collections.Generic;


namespace NET.S._2018.Kuzmiankou._11.ComparerClasses
{
    class PriceComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return NumbersCompare.CompareNumbers(x.Price, y.Price);
        }
    }
}
