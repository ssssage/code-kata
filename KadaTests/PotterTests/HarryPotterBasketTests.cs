using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterTests
{
    public class HarryPotterBasketTests
    {
        HarryPotterBasket harryPotterBasket = new HarryPotterBasket();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Discount_Zero_On_FirstBook_Of_The_Series_In_Basket()
        {
            CalculateAmount(0m, new List<Book>()
            {
                new Book {ISBN = 1}
            });

        }

        [Test]
        public void Discount_5_Percent_On_Two_Different_Books_In_Basket()
        {
            CalculateAmount(.8m, new List<Book>()
            {
                new Book {ISBN = 1},
                new Book {ISBN = 2}
            });

        }

        [Test]
        public void Price_Of_5_Different_And_2_Same_Books_In_Basket()
        {
            CalculateAmount(10m, new List<Book>()
            {
                new Book {ISBN = 1},
                new Book {ISBN = 2},
                new Book {ISBN = 3},
                new Book {ISBN = 4},
                new Book {ISBN = 5}
            });

        }

        private void CalculateAmount(decimal expected, List<Book> Books)
        {
            decimal totalPrice = harryPotterBasket.GetTotalPrice(Books);

            Assert.AreEqual(expected, totalPrice);
        }
    }

    internal class HarryPotterBasket
    {
        Dictionary<int, decimal> discountLookup = new Dictionary<int, decimal>()
        {
            {1, 0},
            {2, 0.05m },
            {3, 0.1m},
            {4, 0.2m },
            {5, 0.25m }
        };

        internal decimal GetTotalPrice(List<Book> Books)
        {
            decimal totalPrice = Books.Sum(x => 8);

            return totalPrice * discountLookup[Books.Count];
        }
    }

    internal class Book
    {
        public int ISBN { get; internal set; }
    }
}