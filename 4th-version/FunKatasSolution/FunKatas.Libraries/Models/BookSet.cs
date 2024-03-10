using HarryPotterKata.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HarryPotterKata.Models
{
    // This class represents a set of books.
    public class BookSet
    {
        // A private list that holds the books in the set.
        private readonly List<Book> _books = new List<Book>();

        // An instance of the DiscountCatalog class that holds the discount information.
        private readonly DiscountCatalog _discounts = new DiscountCatalog();

        // A property that calculates and returns the total price of the books in the set.
        public double Price
        {
            get
            {
                // Get the discount based on the number of books in the set.
                var discount = _discounts.GetDiscount(_books.Count);

                // Calculate the total price of the books without the discount.
                var totalPrice = _books.Sum(x => x.BookPrice);

                // Apply the discount to the total price and return the result.
                return totalPrice * discount;
            }
        }

        // A method that checks if a specific book is in the set.
        public bool Contains(Book book)
        {
            // Use the Exists method to check if a book with the same volume as the input book exists in the list.
            return _books.Exists(x => x.BookVolume == book.BookVolume);
        }

        // A method that adds a book to the set.
        public void AddBook(Book book)
        {
            // Use the Add method to add the input book to the list.
            _books.Add(book);
        }

        // A method that removes a book from the set.
        public void RemoveBook(Book book)
        {
            // Use the Remove method to remove the input book from the list.
            _books.Remove(book);
        }

        // A method that returns a string representation of the book set.
        public string PrintBookSet()
        {
            string output = null;

            // Iterate over all possible book volumes.
            foreach (BookVolumeEnum bookVolume in Enum.GetValues(typeof(BookVolumeEnum)))
            {
                // Check if a book of the current volume exists in the set.
                // If it does, add "1" to the output string. Otherwise, add "0".
                string temp = _books.Exists(x => x.BookVolume == bookVolume) ? "1" : "0";

                // Add the current result to the output string.
                output = output == null ? temp : $"{output}, {temp}";
            }

            // Return the output string.
            return output;
        }
    }
}
