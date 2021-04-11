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

        [Test]
        public void FirstBook_SecondBook_ThirdBook_FourthBook_In_Basket()
        {
            CalculateAmount(6.4m, new List<Book>()
            {
                new Book {ISBN = 1 },
                new Book {ISBN = 2},
                new Book {ISBN = 3},
                new Book {ISBN = 4}
            });
        } 
        
        [Test]
        public void FirstBook_SecondBook_ThirdBook_FourthBook_FifthBook_In_Basket()
        {
            CalculateAmount(10m, new List<Book>()
            {
                new Book {ISBN = 1 },
                new Book {ISBN = 2},
                new Book {ISBN = 3},
                new Book {ISBN = 4},
                new Book {ISBN = 5}
            });
        }

        [Test]
        public void FirstBook2_SecondBook1_ThirdBook1_In_Basket()
        {
            CalculateAmount(2.4m, new List<Book>()
            {
                new Book {ISBN = 1 },
                new Book {ISBN = 1 },
                new Book {ISBN = 2},
                new Book {ISBN = 3}
            });
        }

        [Test]
        public void FB2_SB2_TB2_FoB1_FiB1_In_Basket()
        {
            CalculateAmount(12.8m, new List<Book>()
            {
                new Book {ISBN = 1 },
                new Book {ISBN = 1 },
                new Book {ISBN = 2},
                new Book {ISBN = 2},
                new Book {ISBN = 3},
                new Book {ISBN = 3},
                new Book {ISBN = 4},
                new Book {ISBN = 5}
            });
        }

        [Test]
        public void FB2_In_Basket()
        {
            CalculateAmount(0m, new List<Book>()
            {
                new Book {ISBN = 1 },
                new Book {ISBN = 1 }

                });
        }

        [Test]
        public void FB2_SB1_In_Basket()
        {
            CalculateAmount(0.8m, new List<Book>()
            {
                new Book {ISBN = 1 },
                new Book {ISBN = 1 },
                 new Book {ISBN = 2 }

                });
        }


        private void CalculateAmount(decimal expected, List<Book> books)
        {
            decimal totalPrice = harryBasket.GetTotalPrice(books);
            Assert.AreEqual(expected, totalPrice);
        }
    }
}