using NUnit.Framework;
using System.Collections.Generic;

namespace HarryCheckout.Tests
{
    [TestFixture]
    public class HarryBasketTests
    {
        private HarryBasket harryBasket = new HarryBasket();

        [Test]
        public void FirstBook_In_Basket()
        {
            CalculateAmount(0m, new List<Book>() 
            { 
                new Book {ISBN = 1}
            });
        }

        [Test]
        public void FirstBook_SecondBook_In_Basket()
        {
            CalculateAmount(0.8m, new List<Book>()
            {
                new Book {ISBN = 1},
                new Book {ISBN = 2}
            });
        }

        [Test]
        public void FirstBook_SecondBook_ThirdBook_In_Basket()
        {
            CalculateAmount(2.4m, new List<Book>()
            {
                new Book {ISBN = 1 },
                new Book {ISBN = 2},
                new Book {ISBN = 3}
            });
        }


        private void CalculateAmount(decimal expected, List<Book> books)
        {
            decimal totalPrice = harryBasket.GetTotalPrice(books);
            Assert.AreEqual(expected, totalPrice);
        }
    }
}