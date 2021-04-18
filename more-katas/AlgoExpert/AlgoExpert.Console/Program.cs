using AlgoExpert.Lib;
using System;
using System.Collections.Generic;

namespace AlgoExpert.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //MaxProfitWithKTransactions(int[] prices, int k)
            int[] stockPrices = { 5, 11, 3, 50, 60, 90 };
            int transactionLimit = 2;
            var profit = Stocking.MaxProfitWithKTransactions(stockPrices, transactionLimit);
            System.Console.WriteLine(profit);
            System.Console.WriteLine("-------------------");

            var profits = Stocks.MaxProfitWithKTransactions(stockPrices, transactionLimit);
            System.Console.WriteLine(profits);
        }

    }
}
