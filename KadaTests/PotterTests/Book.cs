using System;

namespace PotterTests
{
    public class Book
    {
        public decimal ISBN { get; internal set; }

        public static implicit operator decimal(Book v)
        {
            throw new NotImplementedException();
        }
    }

}
