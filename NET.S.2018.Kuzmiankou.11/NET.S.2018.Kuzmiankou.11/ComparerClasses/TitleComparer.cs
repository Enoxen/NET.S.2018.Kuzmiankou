using System;
using System.Collections.Generic;

namespace NET.S._2018.Kuzmiankou._11.ComparerClasses
{
    class TitleComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return String.Compare(x.Title, y.Title);
        }
    }
}
