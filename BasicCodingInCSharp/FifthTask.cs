// <copyright file="FifthTask.cs" company="MyCompany.com">
// Contains the solutions to tasks of the 'Basic Coding in C#' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace BasicCodingInCSharp
{
    using System.Linq;
    using static System.Diagnostics.Stopwatch;

    /// <summary>
    /// Contains implementation of the given by the task algorithm.
    /// </summary>
    public class FifthTask
    {
        /// <summary>
        /// Finds the nearest and larger integer that consisting of the digits of the given number.
        /// </summary>
        /// <param name="number">Given number.</param>
        /// <param name="executionTime">Execution time of the method.</param>
        /// <returns>The next bigger number consisting of the digits of the given number, if exist; and -1 otherwise.</returns>
        public static int FindNextBiggerNumber(int number, out long executionTime)
        {
            var watch = StartNew();

            // Convert the number to a string
            var numberAsString = number.ToString();

            // Convert the string to a list of digits
            var listOfDigits = numberAsString.Select(digit => (int)char.GetNumericValue(digit)).ToList();

            // Check each digit from the end
            for (var indexOfDigit = listOfDigits.Count - 1; indexOfDigit > 0; indexOfDigit--)
            {
                // Find the first decreasing digit
                if (listOfDigits[indexOfDigit] >= listOfDigits[indexOfDigit - 1])
                {
                    // Check each digit from the end
                    for (var i = listOfDigits.Count - 1; i >= indexOfDigit; i--)
                    {
                        // Find the digit that is greater than the first decreasing digit
                        if (listOfDigits[i] > listOfDigits[indexOfDigit - 1])
                        {
                            // Swap the found digit with the first decreasing digit
                            var temp = listOfDigits[indexOfDigit - 1];
                            listOfDigits[indexOfDigit - 1] = listOfDigits[i];
                            listOfDigits[i] = temp;

                            // Reverse digits to the right of the first decreasing digit
                            listOfDigits.Reverse(indexOfDigit, listOfDigits.Count - indexOfDigit);

                            // Convert the list of digits to an integer
                            var nextBiggerNumber = int.Parse(string.Join(string.Empty, listOfDigits));

                            // Get the elapsed time
                            watch.Stop();
                            executionTime = watch.ElapsedMilliseconds;

                            return nextBiggerNumber;
                        }
                    }
                }
            }

            // Get the elapsed time
            watch.Stop();
            executionTime = watch.ElapsedMilliseconds;

            return -1;
        }
    }
}