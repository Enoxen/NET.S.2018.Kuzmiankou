using System;
using System.Collections.Generic;


namespace NET.S._2018.Kuzmiankou._11.BookStorage
{
    interface IBookStorage<Book>
    {
        void SaveBooks(IEnumerable<Book> books);
        IEnumerable<Book> ReadBooks();
    }

}
