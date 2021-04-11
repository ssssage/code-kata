using System;
using System.Collections.Generic;
using System.Linq;

namespace HarryCheckout.Tests
{
    public class HarryBasket
    {
        private Dictionary<int, decimal> discountLookup = new Dictionary<int, decimal>()
        {
            {1, 0 },
            {2, 0.05m },
            {3, 0.1m},
            {4, 0.2m },
            {5, 0.25m }
        };

        internal decimal GetTotalPrice(List<Book> books)
        {
            Dictionary<int, List<Book>> suites = GetSuites(books);
            Convert5and3PairTo4And4(suites);
            return suites.Sum(s => AmountOfSuite(s.Value));
        }

private void Convert5and3PairTo4And4(Dictionary<int, List<Book>> suites)
        {
            var fiveSuites = suites.Where(x => x.Value.Count == 5);
            var threeSuites = suites.Where(x => x.Value.Count == 3);
            var fiveAndThreePairs = fiveSuites.Zip(threeSuites, (five, three) => new { five, three });
            foreach (var fiveAndthreePair in fiveAndThreePairs)
            {
                var movingBook = fiveAndthreePair.five.Value.Except(fiveAndthreePair.three.Value).First();
                suites[fiveAndthreePair.five.Key].Remove(movingBook);
                suites[fiveAndthreePair.three.Key].Add(movingBook);
            }
        }



        private static Dictionary<int, List<Book>> GetSuites(List<Book> books)
        {
            var index = 0;
            var uncheckoutBooks = books;
            var suites = new Dictionary<int, List<Book>>();
            while (uncheckoutBooks.Any())
            {
                var suite = uncheckoutBooks.GroupBy(x => x.ISBN).Select(x => x.First()).ToList();
                suites.Add(index, suite);
                uncheckoutBooks = uncheckoutBooks.Except(suite).ToList();
                index++;
            }

            return suites;
        }

        private decimal AmountOfSuite(List<Book> books)
        {
            return books.Sum(x => 8) * discountLookup[books.Count];
        }
    }
}