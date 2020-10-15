// <copyright file="FirstTaskTest.cs" company="MyCompany.com">
// Contains the solutions to tasks of the 'Basic Coding in C#' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace BasicCodingInCSharpTests
{
    using System;
    using BasicCodingInCSharp;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// This is a test class for FirstTask and is intended
    /// to contain all FirstTaskTest Unit Tests.
    /// </summary>
    [TestClass]
    public class FirstTaskTest
    {
        /// <summary>
        /// A test for InsertNumber with correct input
        /// </summary>
        /// <param name="numberSource">The source number</param>
        /// <param name="numberIn">The inserted number</param>
        /// <param name="startingBitPosition">The starting bit position for inserting</param>
        /// <param name="endingBitPosition">The ending bit position for inserting</param>
        /// <param name="expectedResult">The expected result that method returns</param>
        [TestMethod]
        [DataRow(15, 15, 0, 0, 15)]
        [DataRow(8, 15, 0, 0, 9)]
        [DataRow(8, 15, 3, 8, 120)]
        [DataRow(-15, -15, 0, 0, -15)]
        [DataRow(-8, -15, 3, 8, -120)]
        public void InsertNumberTestCorrectInput(int numberSource, int numberIn, int startingBitPosition, int endingBitPosition, int expectedResult)
        {
            // Run the method under test
            var actualResult = FirstTask.InsertNumber(numberSource, numberIn, startingBitPosition, endingBitPosition);

            // Verify the result:
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// A test for InsertNumber with incorrect input
        /// </summary>
        /// <param name="numberSource">The source number</param>
        /// <param name="numberIn">The inserted number</param>
        /// <param name="startingBitPosition">The starting bit position for inserting</param>
        /// <param name="endingBitPosition">The ending bit position for inserting</param> 
        [TestMethod]
        [DataRow(15, 15, -1, 0)]
        [DataRow(15, 15, 0, -1)]
        [DataRow(15, 15, 32, 0)]
        [DataRow(15, 15, 0, 32)]
        public void InsertNumberTestIncorrectInput(int numberSource, int numberIn, int startingBitPosition, int endingBitPosition)
        {
            // Run the method under test
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                FirstTask.InsertNumber(numberSource, numberIn, startingBitPosition, endingBitPosition));
        }

        /// <summary>
        /// A test for InsertNumber when starting bit position is greater than ending bit position
        /// </summary>
        /// <param name="numberSource">The source number</param>
        /// <param name="numberIn">The inserted number</param>
        /// <param name="startingBitPosition">The starting bit position for inserting</param>
        /// <param name="endingBitPosition">The ending bit position for inserting</param>
        [TestMethod]
        [DataRow(15, 15, 2, 1)]
        public void InsertNumberTestStartingBitPositionIsGreaterThanEndingBitPosition(int numberSource, int numberIn, int startingBitPosition, int endingBitPosition)
        {
            // Run the method under test
            Assert.ThrowsException<ArgumentException>(() =>
                FirstTask.InsertNumber(numberSource, numberIn, startingBitPosition, endingBitPosition));
        }
    }
}