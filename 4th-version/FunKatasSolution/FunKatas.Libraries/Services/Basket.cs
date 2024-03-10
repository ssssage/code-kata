using HarryPotterKata.Enumerations;
using HarryPotterKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HarryPotterKata.Services
{
    // This class represents a basket of book sets.
    public class Basket
    {
        // A private list that holds the book sets in the basket.
        private readonly List<BookSet> bookSets = new List<BookSet>();

        // A property that calculates and returns the total price of the book sets in the basket.
        public double TotalPrice
        {
            get
            {
                // Use the Sum method to add up the prices of all the book sets in the basket.
                return bookSets.Sum(x => x.Price);
            }
        }

        // A method that adds a book to the optimal book set in the basket.
        public void AddBook(Book book)
        {
            // Find all the book sets in the basket that do not contain the book to be added.
            var availableBookSets = bookSets.Where(x => !x.Contains(book));

            // If there are any available book sets, add the book to the optimal one.
            // Otherwise, create a new book set, add the book to it, and add the new book set to the basket.
            if (availableBookSets != null && availableBookSets.Count() != 0)
            {
                ChooseOptimalBookSet(availableBookSets, book).AddBook(book);
            }
            else
            {
                var newBookSet = new BookSet();
                newBookSet.AddBook(book);
                bookSets.Add(newBookSet);
            }
        }

        // A method that adds a certain quantity of a specific volume of book to the basket.
        public void AddBooks(BookVolumeEnum bookVolume, int quantity)
        {
            // Use a for loop to add the book to the basket the specified number of times.
            for (int i = 1; i <= quantity; i++)
            {
                AddBook(new Book(bookVolume));
            }
        }

        // A method that adds a list of books to the basket.
        public void AddBooks(List<Book> books)
        {
            // Use a foreach loop to add each book in the list to the basket.
            foreach (var book in books)
            {
                AddBook(book);
            }
        }

        // A method that returns a string representation of the book sets in the basket.
        public string PrintBookSets()
        {
            string output = string.Empty;

            // Use a foreach loop to add the string representation of each book set to the output string.
            foreach (var bookSet in bookSets)
            {
                output = output + bookSet.PrintBookSet() + Environment.NewLine;
            }

            // Return the output string.
            return output;
        }

        // A private method that chooses the optimal book set to which a book should be added.
        private BookSet ChooseOptimalBookSet(IEnumerable<BookSet> availableBookSets, Book book)
        {
            BookSet optimalBookSet = null;
            double totalPrice = double.MaxValue;

            // Use a foreach loop to find the book set that results in the lowest total price when the book is added.
            foreach (var bookSet in availableBookSets)
            {
                bookSet.AddBook(book);
                if (TotalPrice < totalPrice)
                {
                    totalPrice = TotalPrice;
                    optimalBookSet = bookSet;
                }
                bookSet.RemoveBook(book);
            }

            // Return the optimal book set.
            return optimalBookSet;
        }
    }

}
