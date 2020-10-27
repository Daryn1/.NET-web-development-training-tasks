// <copyright file="ThirdTaskTest.cs" company="MyCompany.com">
// Contains the solutions to tasks of the 'Methods in detail' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace Methods_In_Detail_Tests
{
    using Methods_in_detail;
    using NUnit.Framework;

    /// <summary>
    /// This is a test class for ThirdTask and is intended
    /// to contain all ThirdTask Unit Tests.
    /// </summary>
    [TestFixture]
    public class ThirdTaskTest
    {
        /// <summary>
        /// A test for IsNull.
        /// </summary>
        /// <param name="nullableVariable">Variable of null-able type.</param>
        /// <returns>true if a given null-able variable is equal to null; otherwise false.</returns>
        [TestCase(null, ExpectedResult = true)]
        [TestCase("Kathy", ExpectedResult = false)]
        [TestCase(2, ExpectedResult = false)]
        [TestCase(new int[] { 1, 2, 3, 4 }, ExpectedResult = false)]
        [TestCase(new int[] { }, ExpectedResult = false)]
        public bool CalculateGCDUsingEuclidAlgorithmTest(object nullableVariable)
        {
            return nullableVariable.IsNull();
        }
    }
}