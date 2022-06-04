using NUnit.Framework;

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
            int value = 0;
            CalculateAmount(value);
        }

        [Test]
        public void One_Book_In_The_Basket_Cost_8_Pounds_Test()
        {
            order.AddBook(PotterBook.First);

           
        }


        private void CalculateAmount(int value)
        {
            int actualAmount = order.GetTotalAmountInPounds();

            Assert.AreEqual(actualAmount, value);
        }

    }
}
