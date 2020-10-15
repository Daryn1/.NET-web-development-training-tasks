// <copyright file="SixthTask.cs" company="MyCompany.com">
// Contains the solutions to tasks of the 'Basic Coding in C#' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace BasicCodingInCSharp
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Contains implementation of the given by the task algorithm.
    /// </summary>
    public class SixthTask
    {
        /// <summary>
        /// Filters an input array so that only numbers containing the given digit are left in the output.
        /// </summary>
        /// <param name="inputArray">Input array of integers.</param>
        /// <param name="digitForFiltering">Digit used for filtering.</param>
        /// <returns>Returns the array of numbers that contain the given digit.</returns>
        public static int[] FilterDigit(int[] inputArray, int digitForFiltering)
        {
            if (digitForFiltering < 0 || digitForFiltering > 9)
            {
                throw new ArgumentOutOfRangeException("digitForFiltering must be in the range from 0 to 9");
            }

            var outputArray = new List<int>();

            // Check every number in array.
            foreach (var number in inputArray)
            {
                // Convert the number to a char array.
                var numberAsCharArray = number.ToString().ToCharArray();

                // Check all digits of a number for equality to digitForFiltering.
                foreach (var digitOfNumber in numberAsCharArray)
                {
                    if ((int)char.GetNumericValue(digitOfNumber) == digitForFiltering)
                    {
                        outputArray.Add(number);
                        break;
                    }
                }
            }
            
            return outputArray.ToArray();
        }
    }
}