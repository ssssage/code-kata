using HarryPotterKata;
using System;

namespace FunKatas.Console

{
    // This is the main class of the program.
    public class Program
    {
        // The Main method is the entry point of the program.
        static void Main(string[] args)
        {
            // Print a welcome message to the console.
            System.Console.WriteLine("Welcome to Harro Potter Kata !!!");

            // Start a loop that continues until the user enters 'q'.
            do
            {
                // Call the Process method of the UserInput class.
                // This method handles the user input.
                UserInput.Process();

                // Ask the user if they want to quit or continue.
                // If the user enters 'q', the program will quit.
                // If the user enters any other key, the program will continue for another round.
                System.Console.Write("Please enter 'q' key to quit, or any key to continue for another round : ");

                // Continue the loop as long as the user does not enter 'q'.
            } while (!"q".Equals(System.Console.ReadLine(), StringComparison.CurrentCultureIgnoreCase));
        }
    }

}

