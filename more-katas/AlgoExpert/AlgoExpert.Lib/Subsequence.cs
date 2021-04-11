using System;

namespace AlgoExpert.Lib
{
    public class Subsequence
    {
        public static bool IsValidSubsequence(int[] array, int[] sequence)
        {
            int indexOfFirstArray = 0;
            int indexOfSecondArray = 0;

            while (indexOfFirstArray < array.Length && indexOfSecondArray < sequence.Length)
            {
                //{ 1, 3, 4, 5, 6, 9 }                { 1, 6, 8, 10, 11 };
                if (array[indexOfFirstArray] == sequence[indexOfSecondArray])
                {
                    indexOfSecondArray++;
                }

                indexOfFirstArray++;
            }

            return indexOfSecondArray == sequence.Length;
        }
    }
}
//Run the following code in console
//int[] arr = { 1, 3, 4, 5, 6, 9 };
//int[] arr1 = { 7, 8, 10, 11 };

//System.Console.WriteLine(Subsequence.IsValidSubsequence(arr, arr1));