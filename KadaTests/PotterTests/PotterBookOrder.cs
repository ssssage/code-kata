using System;
using System.Collections.Generic;

namespace PotterTests
{

    public class PotterBookOrder
    {
       

        private Book _book;

        public int GetTotalAmountInPounds()
        {
            return _book == null ? 0 : 8;    
        }

        public void AddBook(Book book)
        {
            this._book = book;
            
        }
    }


}
