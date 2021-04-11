using System;
using System.Collections.Generic;
using System.Linq;

namespace HarryCheckout.Tests
{
    public class HarryBasket
    {
        private Dictionary<int, decimal> discountLookup = new Dictionary<int, decimal>()
        {
            {1, 0},
            {2, 0.05m },
            {3, 0.1m},
            {4, 0.2m },
            {5, 0.25m }
        };

        internal decimal GetTotalPrice(List<Book> books)
        {
           decimal totalPrice = books.Sum(x => 8);

            return totalPrice * discountLookup[books.Count];
        }
    }
}