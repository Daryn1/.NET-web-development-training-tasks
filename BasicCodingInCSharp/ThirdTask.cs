// <copyright file="ThirdTask.cs" company="MyCompany.com">
// Contains the solutions to tasks of the 'Basic Coding in C#' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace BasicCodingInCSharp
{
    using System;
    using System.Linq;

    /// <summary>
    /// Contains implementation of the given by the task algorithm.
    /// </summary>
    public class ThirdTask
    {
        /// <summary>
        /// Finds the index of the element of array for which the sum of elements on the left and the sum of elements on the right are equal.
        /// </summary>
        /// <param name="array">An array in which we find the index.</param>
        /// <returns>Returns the index of the element if one exists, and returns null if there is no such element.</returns>
        public static double? FindElementOfEqualityOfLeftAndRightSides(double[] array)
        {
            // Check the sum of the left and right sides for every element from the first to the penultimate
            for (var i = 1; i < array.Length - 1; i++)
            {
                var sumLeft = array.Take(i).Sum();
                var sumRight = array.Skip(i + 1).Sum();

                if (Math.Abs(sumLeft - sumRight) < 0.001)
                {
                    return array[i];
                }
            }

            return null;
        }
    }
}