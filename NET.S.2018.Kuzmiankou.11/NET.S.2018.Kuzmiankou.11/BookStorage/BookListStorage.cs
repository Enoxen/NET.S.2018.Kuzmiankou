using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NET.S._2018.Kuzmiankou._11.BookStorage
{
    class BookListStorage : IBookStorage<Book>
    {
        /// <summary>
        /// Writes books to the file.
        /// </summary>
        /// <param name="books">Collection of books.</param>
        public void SaveBooks(IEnumerable<Book> books)
        {
            if (books == null)
            {
                throw new ArgumentNullException(nameof(books));
            }

            string path = " ";

            using (var writer = new BinaryWriter(File.Open(path, FileMode.Append)))
            {
                foreach (Book book in books)
                {
                    writer.Write(book.AuthorName);
                    writer.Write(book.ISBN);
                    writer.Write(book.NumberOfPages);
                    writer.Write(book.Price);
                    writer.Write(book.Title);
                    writer.Write(book.Year);
                }
            }
        }

        /// <summary>
        /// Reads books from file.
        /// </summary>
        public IEnumerable<Book> ReadBooks()
        {
            string path = " ";
            var books = new HashSet<Book>();
            using (var reader = new BinaryReader(File.OpenRead(path)))
            {
                while (reader.PeekChar() > -1)
                {
                    var book = new Book
                    {
                        AuthorName = reader.ReadString(),
                        ISBN = reader.ReadString(),
                        NumberOfPages = reader.ReadInt32(),
                        Price = reader.ReadDecimal(),
                        Title = reader.ReadString(),
                        Year = reader.ReadInt32()
                    };

                    books.Add(book);
                }

                return books;
            }
        }
    }
}
