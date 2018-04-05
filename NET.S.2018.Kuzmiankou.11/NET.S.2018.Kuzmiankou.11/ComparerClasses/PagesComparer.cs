using System;
using NET.S._2018.Kuzmiankou._11.ComparerInterfaces;
using NET.S._2018.Kuzmiankou._11.Help;

namespace NET.S._2018.Kuzmiankou._11.ComparerClasses
{
    class PagesComparer : IBookComparerPages
    {
        public int Compare(Book x, Book y)
        {
            return NumbersCompare.CompareNumbers(x.NumberOfPages, y.NumberOfPages);
        }
    }
}
