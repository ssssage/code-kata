using NUnit.Framework;
using System.Collections.Generic;

namespace AlgoExpert.Lib.Tests
{
    [TestFixture]
    public class RiversTests
    {

        [Test]
        public void RiverSizesTests()
        {
            int[,] input = 
            { 
                { 1, 0, 0, 1, 0 }, 
                { 1, 0, 1, 0, 0 }, 
                { 0, 0, 1, 0, 1 }, 
                { 1, 0, 1, 0, 1 }, 
                { 1, 0, 1, 1, 0 } 
            };
            int[] expected = {1, 2, 2, 2, 5 };
            List<int> output = Rivers.RiverSizes(input);
            output.Sort();
            Assert.AreEqual(expected, output);
        }
            
        }
    }