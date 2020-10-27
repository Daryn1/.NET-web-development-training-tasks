// <copyright file="SecondTask.cs" company="MyCompany.com">
// Contains the solutions to tasks of the 'Basic Coding in C#' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace Basic_coding_in_CSharp
{
    using System;

    /// <summary>
    /// Contains implementation of the given by the task algorithm.
    /// </summary>
    public class SecondTask
    {
        /// <summary>
        /// Finds the maximum element of an unsorted array using the recursive algorithm.
        /// </summary>
        /// <param name="unsortedArray">The array in which we find the maximum element.</param>
        /// <param name="currentIndex">Current index of the array. Initial call should be done with currentIndex = unsortedArray.Length - 1</param>
        /// <returns>Maximum element in unsortedArray.</returns>
        public static int FindMaxRecursive(int[] unsortedArray, int currentIndex)
        {
            if (currentIndex >= unsortedArray.Length)
            {
                throw new ArgumentOutOfRangeException("currentIndex should be less than unsortedArray.Length");
            }

            if (currentIndex == 0)
            {
                return unsortedArray[currentIndex];
            }

            return Math.Max(unsortedArray[currentIndex], FindMaxRecursive(unsortedArray, currentIndex - 1));
        }
    }
}