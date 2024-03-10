using HarryPotterKata.Enumerations;
using HarryPotterKata.Services;
using System;

namespace HarryPotterKata
{
    // This class is used to process user input.
    public static class UserInput
    {
        // This method processes the user input.
        public static void Process()
        {
            // Print a new line and a separator.
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------");

            // Create a new basket.
            var basket = new Basket();

            // Iterate over all possible book volumes.
            foreach (BookVolumeEnum bookVolume in Enum.GetValues(typeof(BookVolumeEnum)))
            {
                // Ask the user for the quantity of the current book volume.
                Console.Write($"Please enter the quantity for book volume {bookVolume.ToString()} : ");
                string input = Console.ReadLine();

                // Try to parse the user input as an integer.
                if (int.TryParse(input, out int quantity))
                {
                    // If the parsing is successful, add the specified quantity of the current book volume to the basket.
                    basket.AddBooks(bookVolume, quantity);
                }
                else
                {
                    // If the parsing is not successful, print an error message and assume a quantity of 0.
                    Console.WriteLine("Invalid input, we assume quantity 0");
                }
            }

            // Print the total price of the basket and the book combinations in the basket.
            Console.WriteLine();
            Console.WriteLine($"The total price of the basket is : {basket.TotalPrice}");
            Console.WriteLine("The book combinations in the basket are as following:");
            Console.WriteLine(basket.PrintBookSets());
        }
    }

}
