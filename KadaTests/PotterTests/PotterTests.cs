using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterTests
{
    public class PotterTests
    {
        private Potter harryPotterBasket = new Potter();


        [Test]
        public void NoBook_In_Basket_Test()
        {
            CalculateAmount(0m, new List<Book>()
            {
               null
            }); ;

        }

        [Test]
        public void FirstBook_In_Basket_Test()
        {
            CalculateAmount(0m, new List<Book>()
            {
               new Book { ISBN = 1 }
            });
           
        }


        [Test]
        public void FirstBook_SecondBook_In_Basket_Test()
        {
            CalculateAmount(0.8m, new List<Book>() 
            {
                new Book { ISBN = 1 },
                new Book { ISBN = 2 }
            });

        }

        [Test]
        public void FirstBook_SecondBook_ThirdBook_In_Basket()
        {
            CalculateAmount(2.4m, new List<Book>()
            {
                new Book { ISBN = 1 },
                new Book { ISBN = 2 },
                new Book { ISBN = 3 }
            });
        }

        [Test]
        public void FirstBook_SecondBook_ThirdBook_FourthBook_In_Basket()
        {
            CalculateAmount(6.4m, new List<Book>()
            {
                new Book { ISBN = 1 },
                new Book { ISBN = 2 },
                new Book { ISBN = 3 },
                new Book { ISBN = 4 }
            });
        }

        [Test]
        public void FirstBook_SecondBook_ThirdBook_FourthBook_FifthBook_In_Basket()
        {
            CalculateAmount(10m, new List<Book>()
            {
                new Book { ISBN = 1 },
                new Book { ISBN = 2 },
                new Book { ISBN = 3 },
                new Book { ISBN = 4 },
                new Book { ISBN = 5 }
            });
        }

        //[Test]
        //public void FB2_SB2_TB2_FoB1_FiB1_In_Basket()
        //{
        //    CalculateAmount(12.8m, new List<Book>()
        //    {
        //        new Book {ISBN = 1 },
        //        new Book {ISBN = 1 },
        //        new Book {ISBN = 2},
        //        new Book {ISBN = 2},
        //        new Book {ISBN = 3},
        //        new Book {ISBN = 3},
        //        new Book {ISBN = 4},
        //        new Book {ISBN = 5}
        //    });
        //}

        private void CalculateAmount(decimal expected, List<Book> books)
        {
            decimal totalPrice = harryPotterBasket.GetTotalPrice(books);

            Assert.AreEqual(expected, totalPrice);
        }
    }
}
