using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PotterTests
{

    public class PotterBookOrder
    {
        int SingleBookPrice = 800;

        private List<Book> Books = new List<Book>();

        public int GetTotalAmountInPence()
        {
            int numberOfBooks = GetNumberOfBooks();
            int numberOfDistinctBooks = (int)GetNumberOfDistinctBooks();

            return (int)(numberOfDistinctBooks == 2 ? numberOfBooks * SingleBookPrice * 0.95M : numberOfBooks * SingleBookPrice);

        }

        public decimal GetNumberOfDistinctBooks()
        {
            HashSet<Book> DifferentBooks = new HashSet<Book>(Books);
            return DifferentBooks.Count();
        }

        public int GetNumberOfBooks()
        {
          return Books.Count();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }
    }


}
