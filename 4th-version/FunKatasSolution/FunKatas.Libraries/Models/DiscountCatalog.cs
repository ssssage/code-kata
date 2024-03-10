using System;
using System.Collections.Generic;
using System.Text;

namespace HarryPotterKata.Models
{
    // This class represents a catalog of discounts.
    public class DiscountCatalog
    {
        // A private dictionary that holds the discount rates for different quantities of books.
        // The key is the quantity of books, and the value is the discount rate.
        private readonly Dictionary<int, double> catalogue = new Dictionary<int, double>
    {
        {1, 0},    // No discount for 1 book.
        {2, 0.05}, // 5% discount for 2 different books.
        {3, 0.1},  // 10% discount for 3 different books.
        {4, 0.20}, // 20% discount for 4 different books.
        {5, 0.25}  // 25% discount for 5 different books.
    };

        // A method that returns the discount for a given quantity of books.
        public double GetDiscount(int numberOfBooks)
        {
            // The discount is calculated as 1 minus the discount rate.
            // This is because the discount rate is subtracted from the total price,
            // so a discount rate of 0.05 (5%) means that 95% of the total price is paid.
            return 1 - catalogue[numberOfBooks];
        }
    }

}
