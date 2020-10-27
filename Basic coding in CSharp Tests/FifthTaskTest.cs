// <copyright file="FifthTaskTest.cs" company="MyCompany.com">
// Contains the solutions to tasks of the 'Basic Coding in C#' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace Basic_coding_in_CSharp_Tests
{
    using Basic_coding_in_CSharp;
    using NUnit.Framework;

    /// <summary>
    /// This is a test class for ThirdTask and is intended
    /// to contain all ThirdTask Unit Tests.
    /// </summary>
    [TestFixture]
    public class FifthTaskTest
    {
        /// <summary>
        /// A test for FindNextBiggerNumber.
        /// </summary>
        /// <param name="number">Given number.</param>
        /// <returns>The next bigger number consisting of the digits of the given number, if exist; and -1 otherwise.</returns>
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public int FindNextBiggerNumberTest(int number)
        {
            return FifthTask.FindNextBiggerNumber(number, out _);
        }
    }
}