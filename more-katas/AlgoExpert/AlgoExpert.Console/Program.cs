using AlgoExpert.Lib;
using System;
using System.Collections.Generic;

namespace AlgoExpert.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] input = {
            {1, 0, 0, 1, 0},
            {1, 0, 1, 0, 0},
            {0, 0, 1, 0, 1},
            {1, 0, 1, 0, 1},
            {1, 0, 1, 1, 0},
        };
            //int[] expected = { 1, 2, 2, 2, 5 };
            List<int> output = Rivers.RiverSizes(input);
            output.Sort();
            foreach (var item in output)
            {
                System.Console.WriteLine(($"{item}"));
            }
        }

    }
}
