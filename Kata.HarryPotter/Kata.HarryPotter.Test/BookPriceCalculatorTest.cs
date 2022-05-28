using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata.HarryPotter.Test
{
    /// <summary>
    /// Summary description for BookPriceCalculatorTest
    /// </summary>
    [TestClass]
    public class BookPriceCalculatorTest
    {
        private BookPriceCalculator _bookPriceCalculator;

        [TestInitialize]
        public void Init()
        {
            this._bookPriceCalculator = new BookPriceCalculator();
        }

        [TestMethod]
        public void ZeroBooks_CostsZero()
        {
            List<Int32> books = this.GenerateBooksList();

            Decimal cost = this._bookPriceCalculator.Calculate(books);

            Assert.AreEqual(0, cost);

        }

        [TestMethod]
        public void OneCopyOfBookOne_CostsEight()
        {
            List<Int32> books = this.GenerateBooksList(1);

            Decimal cost = this._bookPriceCalculator.Calculate(books);

            Assert.AreEqual(8, cost);
        }

        [TestMethod]
        public void OneCopyOfBookTwo_CostsEight()
        {
            List<Int32> books = this.GenerateBooksList(2);

            Decimal cost = this._bookPriceCalculator.Calculate(books);

            Assert.AreEqual(8, cost);
        }

        [TestMethod]
        public void OneCopyOfBookThree_CostsEight()
        {
            List<Int32> books = this.GenerateBooksList(3);

            Decimal cost = this._bookPriceCalculator.Calculate(books);

            Assert.AreEqual(8, cost);
        }

        [TestMethod]
        public void OneCopyOfBookFour_CostsEight()
        {
            List<Int32> books = this.GenerateBooksList(4);

            Decimal cost = this._bookPriceCalculator.Calculate(books);

            Assert.AreEqual(8, cost);
        }

        [TestMethod]
        public void OneCopyOfBookFive_CostsEight()
        {
            List<Int32> books = this.GenerateBooksList(5);

            Decimal cost = this._bookPriceCalculator.Calculate(books);

            Assert.AreEqual(8, cost);
        }

        [TestMethod]
        public void TwoCoppiesOfSameBook_CostsSixteen()
        {
            List<Int32> books = this.GenerateBooksList(1, 1);

            Decimal cost = this._bookPriceCalculator.Calculate(books);

            Assert.AreEqual(16, cost);
        }

        [TestMethod]
        public void TwoDifferentBooks_GetFivePercentDiscount()
        {
            List<Int32> books = this.GenerateBooksList(1, 2);

            Decimal cost = this._bookPriceCalculator.Calculate(books);

            Assert.AreEqual(15.2m, cost);
        }

        [TestMethod]
        public void ThreeDifferentBooks_GetTenPercentDiscount()
        {
            List<Int32> books = this.GenerateBooksList(1, 2, 3);

            Decimal cost = this._bookPriceCalculator.Calculate(books);

            Assert.AreEqual(21.6m, cost);
        }

        [TestMethod]
        public void FourDifferentBooks_GetTwentyPercentDiscount()
        {
            List<Int32> books = this.GenerateBooksList(1, 2, 3, 4);

            Decimal cost = this._bookPriceCalculator.Calculate(books);

            Assert.AreEqual(25.6m, cost);
        }

        [TestMethod]
        public void FiveDifferentBooks_GetTwentyFivePercentDiscount()
        {
            List<Int32> books = this.GenerateBooksList(1, 2, 3, 4, 5);

            Decimal cost = this._bookPriceCalculator.Calculate(books);

            Assert.AreEqual(30, cost);
        }

        [TestMethod]
        public void ThreeBooksTwoDifferent_GetFivePercentDiscountOnTwoOfThem()
        {
            List<Int32> books = this.GenerateBooksList(1, 2, 1);

            Decimal cost = this._bookPriceCalculator.Calculate(books);

            Assert.AreEqual(23.2m, cost);
        }

        [TestMethod]
        public void ManyBooks_GetsBestPrice()
        {
            List<Int32> books = this.GenerateBooksList(1, 1,2 , 2, 3, 3, 4, 5);

            Decimal cost = this._bookPriceCalculator.Calculate(books);

            Assert.AreEqual(51.2m, cost);
        }

        private List<Int32> GenerateBooksList(params Int32[] books)
        {
            List<Int32> booksList = new List<Int32>();

            foreach(Int32 book in books)
            {
                booksList.Add(book);
            }

            return booksList;
        }
         
    }
}
