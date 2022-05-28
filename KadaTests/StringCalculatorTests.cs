using System;
using Xunit;

namespace KadaTests
{

    public class StringCalculatorTests
    {
        [Fact]
        public void Returns0WithGivenEmptyString()
        {
            var calculator = new StringCalculator();

            var result = calculator.Add("");

            Assert.Equal(0, result);

        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("1, 2", 3)]
        public void ReturnsSumWithGivenTwoNumbers(string numbers, int result)
        {
            var calculator = new StringCalculator();

            var expectedResult = calculator.Add(numbers);

            Assert.Equal(expectedResult, result);

        }

        [Theory]
        [InlineData("1, 2, 3", 6)]
        [InlineData("2, 3, 4", 9)]
        public void ReturnsSumWithGivenThreeNumbers(string numbers, int result)
        {
            var calculator = new StringCalculator();

            var expectedResult = calculator.Add(numbers);

            Assert.Equal(expectedResult, result);

        }
    }
}
