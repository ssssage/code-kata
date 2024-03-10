using HarryPotterKata.Enumerations;
using HarryPotterKata.Services;
using System;
using Xunit;

namespace FunKatas.Tests
{
    // This class contains unit tests for the Basket class.
    public class BasketTests
    {
        // This attribute indicates that the method below is a test method that should be run multiple times with different input data.
        [Theory]

        // These attributes provide the input data for the test method. Each InlineData attribute represents a different test case.
        // The first parameter is the expected total price of the basket, and the second parameter is an array of quantities for each book volume.
        [InlineData(8, new int[5] { 1, 0, 0, 0, 0 })]
        [InlineData(2 * 8 * 0.95, new int[5] { 1, 1, 0, 0, 0 })]
        [InlineData(3 * 8 * 0.9, new int[5] { 1, 1, 1, 0, 0 })]
        [InlineData(5 * 8 * 0.75, new int[5] { 1, 1, 1, 1, 1 })]
        [InlineData(2 * 8 * 0.95 + 1 * 8, new int[5] { 2, 1, 0, 0, 0 })]
        [InlineData(3 * 8 * 0.9 + 1 * 8, new int[5] { 2, 1, 1, 0, 0 })]
        [InlineData(4 * 8 * 0.8 + 4 * 8 * 0.8, new int[5] { 2, 2, 2, 1, 1 })]
        [InlineData(3 * (8 * 5 * 0.75) + 2 * (8 * 4 * 0.8), new int[5] { 5, 5, 4, 5, 4 })]

        // This is the test method. It checks whether the total price of a basket is calculated correctly.
        public void Total_ShouldEqual(double expected, int[] bookVolumeQuantities)
        {
            // Create a new basket.
            Basket basket = new Basket();

            // Add books to the basket. The quantity and volume of the books are taken from the bookVolumeQuantities array.
            for (int i = 0; i < bookVolumeQuantities.Length; i++)
            {
                basket.AddBooks((BookVolumeEnum)(i + 1), bookVolumeQuantities[i]);
            }

            // Calculate the actual total price of the basket.
            double actual = basket.TotalPrice;

            // Check if the actual total price is equal to the expected total price.
            Assert.Equal(expected, actual);
        }
    }

}




