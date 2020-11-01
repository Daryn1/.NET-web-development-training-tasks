// <copyright file="FirstTaskTest.cs" company="MyCompany.com">
// Contains the solutions to tasks of the 'Encapsulation. Inheritance. Polymorphism' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace Encapsulation._Inheritance._Polymorphism_Tests
{
    using System;
    using Encapsulation._Inheritance._Polymorphism;
    using NUnit.Framework;

    /// <summary>
    /// This is a test class for FirstTask and is intended
    /// to contain all FirstTask Unit Tests.
    /// </summary>
    [TestFixture]
    public class FirstTaskTest
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
        /// A test for Accept.
        /// </summary>
        /// <param name="visitorType">Type of the visitor.</param>
        [TestCase(typeof(FirstTask.IncreasingSumsOfRowElements))]
        [TestCase(typeof(FirstTask.DecreasingSumsOfRowElements))]
        [TestCase(typeof(FirstTask.IncreasingMaximumElement))]
        [TestCase(typeof(FirstTask.DecreasingMaximumElement))]
        [TestCase(typeof(FirstTask.IncreasingMinimumElement))]
        [TestCase(typeof(FirstTask.DecreasingMinimumElement))]
        public void SortArrayRowsTest(Type visitorType)
        {
            // Create Matrix object from array.
            var matrix = new FirstTask.Matrix(UnsortedArray);

            // Create instance of visitor.
            var visitor = (FirstTask.IVisitor)Activator.CreateInstance(visitorType);

            // Matrix object is visited which leads to calling that implementation of Visit method that corresponds to visitor.
            matrix.Accept(visitor);

            // Get sorted array from Matrix object.
            var actualResult = matrix.Array;

            // Verify the result.
            if (visitorType == typeof(FirstTask.IncreasingSumsOfRowElements))
            {
                Assert.AreEqual(ArraySortedInOrderOfIncreasingSumsOfRowElements, actualResult);
            }
            else if (visitorType == typeof(FirstTask.DecreasingSumsOfRowElements))
            {
                Assert.AreEqual(ArraySortedInOrderOfDecreasingSumsOfRowElements, actualResult);
            }
            else if (visitorType == typeof(FirstTask.IncreasingMaximumElement))
            {
                Assert.AreEqual(ArraySortedInOrderOfIncreasingMaximumElements, actualResult);
            }
            else if (visitorType == typeof(FirstTask.DecreasingMaximumElement))
            {
                Assert.AreEqual(ArraySortedInOrderOfDecreasingMaximumElements, actualResult);
            }
            else if (visitorType == typeof(FirstTask.IncreasingMinimumElement))
            {
                Assert.AreEqual(ArraySortedInOrderOfIncreasingMinimumElements, actualResult);
            }
            else if (visitorType == typeof(FirstTask.DecreasingMinimumElement))
            {
                Assert.AreEqual(ArraySortedInOrderOfDecreasingMinimumElements, actualResult);
            }
        }
    }
}