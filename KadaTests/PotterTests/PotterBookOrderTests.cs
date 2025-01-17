﻿using NUnit.Framework;

namespace PotterTests
{
    public class PotterBookOrderTests
    {
        private PotterBookOrder order;

        [SetUp]
        public void Setup()
        {
            order = new PotterBookOrder();
        }

        //No book In The Basket Costs Nothing 

        [Test]
        public void No_Book_In_The_Basket_Cost_Nothing_Test()
        {
            AssertTotalAmount(0);
        }


       [Test]
       public void First_Book_In_The_Basket_Cost_8_Pounds_Test()
        {
            order.AddBook(new Book { ISBN = 1 });
            AssertTotalAmount(800);
        }

        [Test]
        public void Second_Book_In_The_Basket_Cost_8_Pounds_Test()
        {
            order.AddBook(new Book { ISBN = 2 });
            AssertTotalAmount(800);
        }

        [Test]
        public void Third_Book_In_The_Basket_Cost_8_Pounds_Test()
        {
            order.AddBook(new Book { ISBN = 3 });
            AssertTotalAmount(800);
        }

        [Test]
        public void Fourth_Book_In_The_Basket_Cost_8_Pounds_Test()
        {
            order.AddBook(new Book { ISBN = 4 });
            AssertTotalAmount(800);
        }

        [Test]
        public void Fifth_Book_In_The_Basket_Cost_8_Pounds_Test()
        {
            order.AddBook(new Book { ISBN = 5 });
            AssertTotalAmount(800);
        }


        [Test]
        public void Same_Two_Books_In_The_Basket_Cost_16_Pounds_Test()
        {
            order.AddBook(new Book { ISBN = 4 });
            order.AddBook(new Book { ISBN = 4 });
            AssertTotalAmount(1600);
        }



        [Test]
        public void Cost_Of_Different_Two_Books_In_The_Basket_Test()
        {
            order.AddBook(new Book { ISBN = 3 });
            order.AddBook(new Book { ISBN = 2 });
            AssertTotalAmount(1520);
        }


        [Test]
        public void Cost_Of_Two_Duplicat_Books_In_The_Basket_Test()
        {
            order.AddBook(new Book { ISBN = 3 });
            order.AddBook(new Book { ISBN = 3 });
            order.AddBook(new Book { ISBN = 2 });
            order.AddBook(new Book { ISBN = 2 });
            AssertTotalAmount(3040);
        }

        private void AssertTotalAmount(decimal value)
        {
            decimal actualAmount = order.GetTotalAmountInPence();

            Assert.AreEqual(actualAmount, value);
        }

    }
}
