using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NET.S._2018.Kuzmiankou._11.BookStorage
{
    class BookListStorage
    {
        private List<Book> books = new List<Book>();

        private readonly string path = @"..\..\..\Resources\Books.txt";

        public List<Book> Books { get => books; }

        public void WriteBookToFile(Book book)
        {
            using (var writer = new BinaryWriter(File.Open(path, FileMode.Append)))
            {
                WriteBookToFile(book, writer);
            }
        }

        private void WriteBookToFile(Book book, BinaryWriter writer)
        {
            writer.Write(book.AuthorName);
            writer.Write(book.ISBN);
            writer.Write(book.NumberOfPages);
            writer.Write(book.Price);
            writer.Write(book.Title);
            writer.Write(book.Year);
        }

        public void WriteBooksToFile()
        {
            using (var writer = new BinaryWriter(File.Open(path, FileMode.Append)))
            {
                foreach (Book book in books)
                {
                    WriteBookToFile(book, writer);
                }
            }
        }

        public void ReadBooksFromFile(string path = null)
        {
            if(path == null)
            {
                using(var reader = new BinaryReader(File.OpenRead(path)))
                {
                    while(reader.PeekChar() > -1)
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
                }
            }
            
        }
    }
}
