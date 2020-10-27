// <copyright file="FirstTaskTest.cs" company="MyCompany.com">
// Contains the solutions to tasks of the 'Methods in detail' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace Methods_In_Detail_Tests
{
    using System;
    using Methods_in_detail;
    using NUnit.Framework;

    /// <summary>
    /// This is a test class for FirstTask and is intended
    /// to contain all FirstTask Unit Tests.
    /// </summary>
    [TestFixture]
    public class FirstTaskTest
    {
        /// <summary>
        /// A test for ToIEEE754.
        /// </summary>
        /// <param name="number">Real number to be converted.</param>
        /// <returns>IEEE 754 binary representation of the given number.</returns>
        [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, ExpectedResult = "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(double.MinValue, ExpectedResult = "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.MaxValue, ExpectedResult = "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.Epsilon, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(double.NaN, ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(-0.0, ExpectedResult = "1000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(0.0, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(0.00001, ExpectedResult = "0011111011100100111110001011010110001000111000110110100011110001")]
        [TestCase(1.0000000000000002, ExpectedResult = "0011111111110000000000000000000000000000000000000000000000000001")]
        [TestCase(1.0000000000000004, ExpectedResult = "0011111111110000000000000000000000000000000000000000000000000010")]
        [TestCase(1, ExpectedResult = "0011111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(2, ExpectedResult = "0100000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(23, ExpectedResult = "0100000000110111000000000000000000000000000000000000000000000000")]
        [TestCase(0.01171875, ExpectedResult = "0011111110001000000000000000000000000000000000000000000000000000")]
        [TestCase((double)1 / 3, ExpectedResult = "0011111111010101010101010101010101010101010101010101010101010101")]
        [TestCase(Math.PI, ExpectedResult = "0100000000001001001000011111101101010100010001000010110100011000")]
        public string ToIEEE754Test(double number)
        {
            return number.ToIEEE754();
        }
    }
}