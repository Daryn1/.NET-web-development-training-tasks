// <copyright file="SecondTaskTest.cs" company="MyCompany.com">
// Contains the solutions to tasks of the 'Basic Coding in C#' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace Basic_coding_in_CSharp_Tests
{
    using Basic_coding_in_CSharp;
    using NUnit.Framework;

    /// <summary>
    /// This is a test class for SecondTask and is intended
    /// to contain all SecondTask Unit Tests.
    /// </summary>
    [TestFixture]
    public class SecondTaskTest
    {
        /// <summary>
        /// A test for FindMaxRecursive.
        /// </summary>
        /// <param name="sourceArray">The array in which we find the maximum element.</param>
        /// <returns>Maximum element in unsortedArray.</returns>
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1 }, ExpectedResult = 1)]
        [TestCase(new int[] { 0, -1, 11, 21, 1, 2, 8, 65, 34, 21, 765, -12, 566, 7878, -199, 0, 34, 65, 87, 12, 34 }, ExpectedResult = 7878)]
        public int FindMaxRecursiveTest(int[] sourceArray)
        {
            return SecondTask.FindMaxRecursive(sourceArray, sourceArray.Length - 1);
        }
    }
}