// <copyright file="FirstTaskTest.cs" company="MyCompany.com">
// Contains the solutions to tasks of the 'Creating types in C#' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace Creating_types_in_CSharp_Tests
{
    using System;
    using Creating_types_in_CSharp;
    using NUnit.Framework;
    
    /// <summary>
    /// This is a test class for FirstTask and is intended
    /// to contain all FirstTask Unit Tests.
    /// </summary>
    [TestFixture]
    public class FirstTaskTest
    {
        /// <summary>
        /// A test for FindNthRootTest with correct input.
        /// </summary>
        /// <param name="a">Number from which we extract root.</param>
        /// <param name="n">Degree of the root.</param>
        /// <param name="accuracy">Precision with which we calculate the root of the number.</param>
        /// <returns>nth root of a number</returns>
        [TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.3)]
        [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
        public double FindNthRootTest(double a, double n, double accuracy)
        {
            return FirstTask.FindNthRoot(a, n, accuracy);
        }

        /// <summary>
        /// A test for FindNthRootTest with incorrect input.
        /// </summary>
        /// <param name="number">Number from which we extract root.</param>
        /// <param name="degree">Degree of the root.</param>
        /// <param name="precision">Precision with which we calculate the root of the number.</param>
        [TestCase(-0.01, 2, 0.0001)]
        [TestCase(0.001, -2, 0.0001)]
        [TestCase(0.01, 2, -1)]
        public void FindNthRoot_NegativeInput_ThrowsArgumentOutOfRangeException(
            double number, int degree, double precision) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => FirstTask.FindNthRoot(number, degree, precision));
    }
}