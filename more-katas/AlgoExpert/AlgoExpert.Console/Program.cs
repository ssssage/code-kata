using AlgoExpert.Lib;
using System;
using System.Collections.Generic;

namespace AlgoExpert.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] codes = new string[,]
        {
            {"AA", "BB"},
            {"CC", "DD"}
        };

            // Get the upper bound.
            // ... Use for-loop over rows.
            int myvalue = codes.GetUpperBound(0);
            for (int i = 0; i <= myvalue; i++)
            {
                string s1 = codes[i, 0];
                string s2 = codes[i, 1];
                System.Console.WriteLine("{0}, {1}", s1, s2);
            }

          

            System.Console.WriteLine("Index: {0}", myvalue);

        }

    }
}
