using System;
using System.Collections.Generic;

namespace PotterTests
{

    public class PotterBookOrder
    {
        decimal SingleBookPrice = 8.00M;

        public List<Book> Books = new List<Book>();

        private Book _book;

        public int GetTotalAmountInPounds()
        {
            return (int)(Books.Count * SingleBookPrice);   
        }

        public void AddBook(Book book)
        {
          this.Books.Add(_book);
        }
    }


}
