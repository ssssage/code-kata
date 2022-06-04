using System;
using System.Collections.Generic;
using Xunit;

namespace HarryPotterTestsProject
{
    public class HarryPotterBasketTests
    {
        private HarryPotterBasket harryPotterBasket = new HarryPotterBasket();

        //No discount on 1 book or First Book

        [Fact]
        public void Discount_Zero_On_FirstBook_In_Basket()
        {
            CalculateAmount(0m, new List<Book>()
            {
                new Book {ISBN = 1}
            });

        }

        private void CalculateAmount(decimal discount, List<Book> Books)
        {
            decimal totalPrice = harryPotterBasket.GetTotalPrice(Books);
            Assert.Equal(discount, totalPrice);
        }
    }

    internal class HarryPotterBasket
    {
        internal decimal GetTotalPrice(List<Book> books)
        {
            throw new NotImplementedException();
        }
    }

    internal class Book
    {
        public int ISBN { get; internal set; }
    }
}
