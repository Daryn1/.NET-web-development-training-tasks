// <copyright file="SecondTaskTest.cs" company="MyCompany.com">
// Contains the solutions to tasks of the 'Methods in detail' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace Methods_In_Detail_Tests
{
    using System;
    using Methods_in_detail;
    using NUnit.Framework;

    /// <summary>
    /// This is a test class for SecondTask and is intended
    /// to contain all SecondTask Unit Tests.
    /// </summary>
    [TestFixture]
    public class SecondTaskTest
    {
        /// <summary>
        /// A test for CalculateGCDUsingEuclidAlgorithm.
        /// </summary>
        /// <param name="numbers">Numbers for which we calculate the greatest common divisor.</param>
        /// <returns>Greatest common divisor of the given numbers.</returns>
        [TestCase(4, 2, ExpectedResult = 2)]
        [TestCase(1071, 462, ExpectedResult = 21)]
        [TestCase(21672, 19997, ExpectedResult = 1)]
        [TestCase(36, 48, 210, ExpectedResult = 6)]
        [TestCase(126, 162, 180, ExpectedResult = 18)]
        [TestCase(500, 2450, 16500, ExpectedResult = 50)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, ExpectedResult = 1)]
        [TestCase(3, 12, 15, 18, 21, 24, 27, 30, ExpectedResult = 3)]
        public int CalculateGCDUsingEuclidAlgorithmTest(params int[] numbers)
        {
            return SecondTask.CalculateGCDUsingEuclidAlgorithm(out _, numbers);
        }

        /// <summary>
        /// A test for CalculateGCDUsingSteinAlgorithm.
        /// </summary>
        /// <param name="numbers">Numbers for which we calculate the greatest common divisor.</param>
        /// <returns>Greatest common divisor of the given numbers.</returns>
        [TestCase(4, 2, ExpectedResult = 2)]
        [TestCase(1071, 462, ExpectedResult = 21)]
        [TestCase(21672, 19997, ExpectedResult = 1)]
        [TestCase(36, 48, 210, ExpectedResult = 6)]
        [TestCase(126, 162, 180, ExpectedResult = 18)]
        [TestCase(500, 2450, 16500, ExpectedResult = 50)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, ExpectedResult = 1)]
        [TestCase(3, 12, 15, 18, 21, 24, 27, 30, ExpectedResult = 3)]
        public int CalculateGCDUsingSteinAlgorithmTest(params int[] numbers)
        {
            return SecondTask.CalculateGCDUsingSteinAlgorithm(out _, numbers);
        }
    }
}