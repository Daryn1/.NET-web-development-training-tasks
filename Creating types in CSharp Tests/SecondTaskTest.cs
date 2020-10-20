// <copyright file="SecondTaskTest.cs" company="MyCompany.com">
// Contains the solutions to tasks of the 'Creating types in C#' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace Creating_types_in_CSharp_Tests
{
    using System;
    using Creating_types_in_CSharp;
    using NUnit.Framework;

    /// <summary>
    /// This is a test class for SecondTask and is intended
    /// to contain all SecondTask Unit Tests.
    /// </summary>
    [TestFixture]
    public class SecondTaskTest
    {
        /// <summary>
        /// Unsorted array used to test methods.
        /// </summary>
        private static readonly int[][] UnsortedArray = new int[][]
        {
            new[] { 11, 34, 67, -89, 8 },
            new[] { 1, 4, 3, 2, 5 },
            new[] { 89, 23, 39, 12, -54 },
            new[] { 0, 0, 0, 0, 0 },
            new[] { -3, -54, -99, 81, 66 }
        };

        /// <summary>
        /// Array sorted in order of increasing sums of row elements.
        /// </summary>
        private static readonly int[][] ArraySortedInOrderOfIncreasingSumsOfRowElements = new int[][]
        {
            new[] { -3, -54, -99, 81, 66 },
            new[] { 0, 0, 0, 0, 0 },
            new[] { 1, 4, 3, 2, 5 },
            new[] { 11, 34, 67, -89, 8 },
            new[] { 89, 23, 39, 12, -54 }
        };

        /// <summary>
        /// Array sorted in order of decreasing sums of row elements.
        /// </summary>
        private static readonly int[][] ArraySortedInOrderOfDecreasingSumsOfRowElements = new int[][]
        {
            new[] { 89, 23, 39, 12, -54 },
            new[] { 11, 34, 67, -89, 8 },
            new[] { 1, 4, 3, 2, 5 },
            new[] { 0, 0, 0, 0, 0 },
            new[] { -3, -54, -99, 81, 66 }
        };

        /// <summary>
        /// Array sorted in order of increasing maximum elements in a row.
        /// </summary>
        private static readonly int[][] ArraySortedInOrderOfIncreasingMaximumElements = new int[][]
        {
            new[] { 0, 0, 0, 0, 0 },
            new[] { 1, 4, 3, 2, 5 },
            new[] { 11, 34, 67, -89, 8 },
            new[] { -3, -54, -99, 81, 66 },
            new[] { 89, 23, 39, 12, -54 }
        };

        /// <summary>
        /// Array sorted in order of decreasing maximum elements in a row.
        /// </summary>
        private static readonly int[][] ArraySortedInOrderOfDecreasingMaximumElements = new int[][]
        {
            new[] { 89, 23, 39, 12, -54 },
            new[] { -3, -54, -99, 81, 66 },
            new[] { 11, 34, 67, -89, 8 },
            new[] { 1, 4, 3, 2, 5 },
            new[] { 0, 0, 0, 0, 0 }
        };

        /// <summary>
        /// Array sorted in order of increasing minimum elements in a row.
        /// </summary>
        private static readonly int[][] ArraySortedInOrderOfIncreasingMinimumElements = new int[][]
        {
            new[] { -3, -54, -99, 81, 66 },
            new[] { 11, 34, 67, -89, 8 },
            new[] { 89, 23, 39, 12, -54 },
            new[] { 0, 0, 0, 0, 0 },
            new[] { 1, 4, 3, 2, 5 }
        };

        /// <summary>
        /// Array sorted in order of decreasing minimum elements in a row.
        /// </summary>
        private static readonly int[][] ArraySortedInOrderOfDecreasingMinimumElements = new int[][]
        {
            new[] { 1, 4, 3, 2, 5 },
            new[] { 0, 0, 0, 0, 0 },
            new[] { 89, 23, 39, 12, -54 },
            new[] { 11, 34, 67, -89, 8 },
            new[] { -3, -54, -99, 81, 66 }
        };

        /// <summary>
        /// A test for SortArrayRows.
        /// </summary>
        /// <param name="strategyType">Type of array sort strategy.</param>
        [TestCase(typeof(SecondTask.IncreasingSumsOfRowElements))]
        [TestCase(typeof(SecondTask.DecreasingSumsOfRowElements))]
        [TestCase(typeof(SecondTask.IncreasingMaximumElement))]
        [TestCase(typeof(SecondTask.DecreasingMaximumElement))]
        [TestCase(typeof(SecondTask.IncreasingMinimumElement))]
        [TestCase(typeof(SecondTask.DecreasingMinimumElement))]
        public void SortArrayRowsTest(Type strategyType)
        {
            // Create instance of strategy type.
            var strategy = (SecondTask.IStrategy)Activator.CreateInstance(strategyType);

            // Create Context and initialize it with the strategy.
            var context = new SecondTask.Context(strategy);

            // Perform Context operation that uses the specified strategy.
            var actualResult = context.SortArrayRows(UnsortedArray);

            // Verify the result.
            if (strategyType == typeof(SecondTask.IncreasingSumsOfRowElements))
            {
                Assert.AreEqual(ArraySortedInOrderOfIncreasingSumsOfRowElements, actualResult);
            }
            else if (strategyType == typeof(SecondTask.DecreasingSumsOfRowElements))
            {
                Assert.AreEqual(ArraySortedInOrderOfDecreasingSumsOfRowElements, actualResult);
            }
            else if (strategyType == typeof(SecondTask.IncreasingMaximumElement))
            {
                Assert.AreEqual(ArraySortedInOrderOfIncreasingMaximumElements, actualResult);
            }
            else if (strategyType == typeof(SecondTask.DecreasingMaximumElement))
            {
                Assert.AreEqual(ArraySortedInOrderOfDecreasingMaximumElements, actualResult);
            }
            else if (strategyType == typeof(SecondTask.IncreasingMinimumElement))
            {
                Assert.AreEqual(ArraySortedInOrderOfIncreasingMinimumElements, actualResult);
            }
            else if (strategyType == typeof(SecondTask.DecreasingMinimumElement))
            {
                Assert.AreEqual(ArraySortedInOrderOfDecreasingMinimumElements, actualResult);
            }
        }
    }
}