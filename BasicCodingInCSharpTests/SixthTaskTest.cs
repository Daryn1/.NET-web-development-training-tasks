// <copyright file="SixthTaskTest.cs" company="MyCompany.com">
// Contains the solutions to tasks of the 'Basic Coding in C#' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace BasicCodingInCSharpTests
{
    using System;
    using BasicCodingInCSharp;
    using NUnit.Framework;

    /// <summary>
    /// This is a test class for SixthTask and is intended
    /// to contain all SixthTask Unit Tests.
    /// </summary>
    [TestFixture]
    public class SixthTaskTest
    {
        /// <summary>
        /// A test for FilterDigit with correct input.
        /// </summary>
        /// <param name="inputArray">Input array of integers.</param>
        /// <param name="digitForFiltering">Digit used for filtering.</param>
        /// <returns>Returns the array of numbers that contain the given digit.</returns>
        [TestCase(new[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 7, ExpectedResult = new[] { 7, 7, 70, 17 })]
        [TestCase(new[] { -777, -786, -117, 0, -24, -12, -17, -7 }, 7, ExpectedResult = new[] { -777, -786, -117, -17, -7 })]
        [TestCase(new[] { 1, 21, 441, 0, 4, 2, 232313232, 33221 }, 1, ExpectedResult = new[] { 1, 21, 441, 232313232, 33221 })]
        [TestCase(new[] { -1234567, -51, -16, -111117 }, 1, ExpectedResult = new[] { -1234567, -51, -16, -111117 })]
        [TestCase(new[] { 6547321, 34567890, 0, 77707777, 80898908 }, 0, ExpectedResult = new[] { 34567890, 0, 77707777, 80898908 })]
        [TestCase(new[] { int.MaxValue, int.MinValue }, 0, ExpectedResult = new int[] { })]
        [TestCase(new int[] { }, 0, ExpectedResult = new int[] { })]
        public int[] FilterDigitTest(int[] inputArray, int digitForFiltering)
        {
            return SixthTask.FilterDigit(inputArray, digitForFiltering);
        }

        /// <summary>
        /// A test for FilterDigit with incorrect input.
        /// </summary>
        /// <param name="inputArray">Input array of integers.</param>
        /// <param name="digitForFiltering">Digit used for filtering.</param>
        [TestCase(new[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, -7)]
        [TestCase(new[] { -777, -786, -117, 0, -24, -12, -17, -7 }, 10)]
        public void FilterDigitTestIncorrectInput(int[] inputArray, int digitForFiltering)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => SixthTask.FilterDigit(inputArray, digitForFiltering));
        }
    }
}