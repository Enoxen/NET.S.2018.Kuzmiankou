using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.S._2018.Kuzmiankou._11.ComparerInterfaces;
using NET.S._2018.Kuzmiankou._11.Help;


namespace NET.S._2018.Kuzmiankou._11.ComparerClasses
{
    class YearComparer : IBookComparerYear
    {
        public int Compare(Book x, Book y)
        {
            return NumbersCompare.CompareNumbers(x.Year, y.Year);
        }
    }
}
