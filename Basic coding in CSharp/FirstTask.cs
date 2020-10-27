// <copyright file="FirstTask.cs" company="MyCompany.com">
//    Contains the solutions to tasks of the 'Basic Coding in C#' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace Basic_coding_in_CSharp
{
    using System;

    /// <summary>
    /// Contains implementation of the given by the task algorithm.
    /// </summary>
    public class FirstTask
    {
        /// <summary>
        /// Replace the bits of numberSource starting from startingBitPosition and ending with endingBitPosition with bits of numberIn.
        /// </summary>
        /// <param name="numberSource">The source number</param>
        /// <param name="numberIn">The inserted number</param>
        /// <param name="startingBitPosition">The starting bit position for inserting</param>
        /// <param name="endingBitPosition">The ending bit position for inserting</param>
        /// <returns>The result number of replacing.</returns>
        public static int InsertNumber(int numberSource, int numberIn, int startingBitPosition, int endingBitPosition)
        {
            if (startingBitPosition < 0 || startingBitPosition > 31 || endingBitPosition < 0 || endingBitPosition > 31)
            {
                throw new ArgumentOutOfRangeException("Bit positions should be positive number not exceeding 31");
            }

            if (startingBitPosition > endingBitPosition)
            {
                throw new ArgumentException("Ending bit position should be greater than starting bit position");
            }

            // Get binary representation of input numbers
            var numberSourceBinary = Convert.ToString(numberSource, 2).ToCharArray();
            var numberInBinary = Convert.ToString(numberIn, 2).ToCharArray();

            Array.Reverse(numberSourceBinary);
            Array.Reverse(numberInBinary);

            // Create a copy of numberSourceBinary with sufficient length
            var numberResultBinary = new char[Math.Max(endingBitPosition + 1, numberSourceBinary.Length)];
            Array.Copy(numberSourceBinary, numberResultBinary, numberSourceBinary.Length);

            // Replace bits of numberResult with bits from numberIn
            for (int i = startingBitPosition, j = 0; i <= endingBitPosition; i++, j++)
            {
                numberResultBinary[i] = j < numberInBinary.Length ? numberInBinary[j] : '0';
            }

            Array.Reverse(numberResultBinary);

            // Convert char array to string
            var numberResultBinaryString = new string(numberResultBinary);

            // Convert string to int
            var numberResult = Convert.ToInt32(numberResultBinaryString, 2);
            return numberResult;
        }
    }
}
