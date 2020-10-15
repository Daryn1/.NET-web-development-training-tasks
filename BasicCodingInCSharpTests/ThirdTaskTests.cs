// <copyright file="ThirdTaskTests.cs" company="MyCompany.com">
// Contains the solutions to tasks of the 'Basic Coding in C#' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace BasicCodingInCSharpTests
{
    using BasicCodingInCSharp;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// This is a test class for ThirdTask and is intended
    /// to contain all ThirdTask Unit Tests.
    /// </summary>
    [TestClass]
    public class ThirdTaskTests
    {
        /// <summary>
        /// A test for FindElementOfEqualityOfLeftAndRightSides with correct input.
        /// </summary>
        /// <param name="array">An array in which we find the index.</param>
        /// <param name="expectedResult">The expected result that method returns.</param>
        [TestMethod]
        [DataRow(new double[] { 1.0, 2.0, 3.0, 3.0 }, 3.0)]
        [DataRow(new double[] { -30.0, 2.0, 50.0, -80.0 }, 2.0)]
        [DataRow(new double[] { 1, 2, 3, 4 }, null)]
        public void FindElementOfEqualityOfLeftAndRightSidesTest(double[] array, double? expectedResult)
        {
            // Run the method under test
            var actualResult = ThirdTask.FindElementOfEqualityOfLeftAndRightSides(array);
            
            // Verify the result:
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}