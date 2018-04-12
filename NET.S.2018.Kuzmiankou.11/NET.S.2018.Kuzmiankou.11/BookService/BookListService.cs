using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.S._2018.Kuzmiankou._11.BookStorage;

namespace NET.S._2018.Kuzmiankou._11.BookService
{
    class BookListService
    {
        private List<Book> books = new List<Book>();

        public List<Book> Books
        {
            get => books;

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"Property set value is null");
                }
            }
        }

        #region Public methods
        public void SortByTag(IComparer<Book> comparer)
        {

        }
        #endregion
    }
}
