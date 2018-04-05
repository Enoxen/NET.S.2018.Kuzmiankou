using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Kuzmiankou._11
{
    /// <summary>
    /// A book entity.
    /// </summary>
    public sealed class Book:IComparable
    {
        #region Fields
        /// <summary>
        /// ISBN number of book.
        /// </summary>
        private string isbn;

        /// <summary>
        /// Name of author.
        /// </summary>
        private string authorName;

        /// <summary>
        /// Title of the book.
        /// </summary>
        private string title;

        /// <summary>
        /// Year of publishing.
        /// </summary>
        private int year;

        /// <summary>
        /// Number of book's pages.
        /// </summary>
        private int numberOfPages;

        /// <summary>
        /// Price of the book.
        /// </summary>
        private decimal price;
        #endregion

        #region Properties
        public string AuthorName { get => this.authorName; set => this.authorName = value; }

        public string ISBN { get => this.isbn; set => this.isbn = value; }

        public string Title { get => this.title; set => this.title = value; }

        public int Year
        {
            get => this.year;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} is less then zero");
                }

                this.year = value;
            }
        }

        public int NumberOfPages
        {
            get => this.numberOfPages;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be more than zero");
                }

                this.numberOfPages = value;
            }
        }

        public decimal Price
        {
            get => this.price;

            set
            {
                if (value < 0.0m)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be more or equal to zero");
                }

                this.price = value;
            }
        }

        
        #endregion

        #region Object methods
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var item = (Book)obj;

            return this.isbn == item.isbn && this.authorName == item.authorName &&
                   this.title == item.title && this.year == item.year &&
                   this.numberOfPages == item.numberOfPages && this.price == item.price;
        }

        public override int GetHashCode()
        {
            return this.isbn.GetHashCode();
        }

        public override string ToString()
        {
            return "Book:" + "\n" +
                $"ISBN:{isbn}, author name: {authorName}, title: {title}, year: {year}, number of pages: {numberOfPages}, price: {price}";
        }

        #endregion

        #region Public methods
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
