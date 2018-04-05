using System;
using NET.S._2018.Kuzmiankou._11.ComparerInterfaces;
using NET.S._2018.Kuzmiankou._11.Help;

namespace NET.S._2018.Kuzmiankou._11.ComparerClasses
{
    class PriceComparer : IBookComparerPrice
    {
        public int Compare(Book x, Book y)
        {
            return NumbersCompare.CompareNumbers(x.Price, y.Price);
        }
    }
}
