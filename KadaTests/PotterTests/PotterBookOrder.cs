using System;
using System.Collections.Generic;

namespace PotterTests
{

    public class PotterBookOrder
    {
        int SingleBookPrice = 8;

        public List<Book> Books = new List<Book>();

        private Book _book;

        public int GetTotalAmountInPounds()
        {
            return Books.Count * SingleBookPrice;   
        }

        public void AddBook(Book book)
        {
          this.Books.Add(_book);
        }
    }


}
