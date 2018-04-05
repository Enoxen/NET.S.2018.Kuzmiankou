using System;
using NET.S._2018.Kuzmiankou._11.ComparerInterfaces;

namespace NET.S._2018.Kuzmiankou._11.ComparerClasses
{
    class AuthorComparer : IBookComparerAuthor
    {
        public int Compare(Book x, Book y)
        {
            return String.Compare(x.AuthorName, y.AuthorName);
        }
    }
}
