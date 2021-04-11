
namespace Harrycheckout.Console
{
    class Program
    {
        
        //Find a smallest number in a given array
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };

            int? smallesNumber = FindSmallestNumbernArray(numbers);

            int? smallestOddNumber = FindSmallestOddNumbernArray(numbers);

            System.Console.WriteLine(smallesNumber);
            System.Console.WriteLine(smallestOddNumber);
        }

        private static int? FindSmallestOddNumbernArray(int[] numbers)
        {
            int? result = null;

            foreach (var i in numbers)
            {
                if (i % 2 == 0 )
                {
                    if (!result.HasValue || i < result)
                    {
                        result = i;
                    }
                }
            }


            return result;
        }

        private static int? FindSmallestNumbernArray(int[] numbers)
        {
            

            int? result = null;

            foreach (int i in numbers)
            {
                if (!result.HasValue || i < result)
                {
                    result = i;
                }
            }

            return result;
        }
    }
}
