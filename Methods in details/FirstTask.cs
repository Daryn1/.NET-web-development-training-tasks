// <copyright file="FirstTask.cs" company="MyCompany.com">
// Contains the solutions to tasks of the 'Methods in detail' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace Methods_in_detail
{
    using System;

    /// <summary>
    /// Contains implementation of the given by the task algorithm.
    /// </summary>
    public static class FirstTask
    {
        /// <summary>
        /// Converts a real double-precision number to IEEE 754 binary representation.
        /// </summary>
        /// <param name="number">Real double-precision number.</param>
        /// <returns>IEEE 754 binary representation of given number.</returns>
        public static string ToIEEE754(this double number)
        {
            // Special values.
            switch (number)
            {
                case double.MinValue:
                    return "1111111111101111111111111111111111111111111111111111111111111111";
                case double.MaxValue:
                    return "0111111111101111111111111111111111111111111111111111111111111111";
                case double.Epsilon:
                    return "0000000000000000000000000000000000000000000000000000000000000001";
                case double.NaN:
                    return "1111111111111000000000000000000000000000000000000000000000000000";
                case double.NegativeInfinity:
                    return "1111111111110000000000000000000000000000000000000000000000000000";
                case double.PositiveInfinity:
                    return "0111111111110000000000000000000000000000000000000000000000000000";
                case 0.0:
                    if (double.IsNegative(number))
                    {
                        return "1000000000000000000000000000000000000000000000000000000000000000";
                    }
                    else
                    {
                        return "0000000000000000000000000000000000000000000000000000000000000000";
                    }
            }

            const int ExponentBias = 1023;

            // Set sign bit to 0 for positive number and 1 for negative.
            var signBit = (number > 0) ? "0" : "1";
            
            // Convert given number to absolute value. 
            var absValue = Math.Abs(number);

            // Get unbiased number exponent.
            var exponentOfNumber = (int)Math.Floor(Math.Log2(absValue));

            // Convert to binary form.
            var exponent = ConvertIntegerToBinary(ExponentBias + exponentOfNumber);

            // Exponent should always be 11 bit long so we add zeros to the left of it.
            while (exponent.Length != 11)
            {
                exponent = "0" + exponent;
            }

            // Write number in base-2 scientific notation.
            var scientificNotation = absValue * Math.Pow(2, -exponentOfNumber);

            // Get fractional part of number from scientific notation.
            var fractionalPartOfNumber = scientificNotation - Math.Floor(scientificNotation);

            // Convert fractional part of the number to a binary form.
            var mantissa = ConvertFractionalPartOfNumberToBinary(fractionalPartOfNumber);

            // Mantissa should always be 52 bit long so we add zeros to the right of it.
            while (mantissa.Length != 52)
            {
                mantissa += "0";
            }

            return signBit + exponent + mantissa;
        }

        /// <summary>
        /// Converts integer number to binary form.
        /// </summary>
        /// <param name="integerNumber">Number to be converted.</param>
        /// <returns>Binary representation of the given number.</returns>
        public static string ConvertIntegerToBinary(double integerNumber)
        {
            if (integerNumber == 0)
            {
                return "0";
            }

            var result = string.Empty;

            while (integerNumber > 0)
            {
                var remainder = integerNumber % 2;
                integerNumber = Math.Floor(integerNumber / 2);
                result = remainder.ToString() + result;
            }

            return result;
        }

        /// <summary>
        /// Converts a fractional part of a number to a binary form. 
        /// </summary>
        /// <param name="fractionalPartOfNumber">Fractional part of a number to be converted.</param>
        /// <returns>Binary representation of the given fractional part of a number.</returns>
        public static string ConvertFractionalPartOfNumberToBinary(double fractionalPartOfNumber)
        {
            if (fractionalPartOfNumber >= 1)
            {
                throw new ArgumentException("Fractional part of a number should be passed to the method.");
            }

            // Declare an empty string to store binary bits. 
            var binaryRepresentation = string.Empty;

            // Iterate through fractional part until the length of binaryRepresentation becomes 52. 
            while (binaryRepresentation.Length != 52)
            {
                fractionalPartOfNumber *= 2;
                int nextBit;

                if (fractionalPartOfNumber >= 1)
                {
                    nextBit = 1;
                    fractionalPartOfNumber -= 1;
                }
                else
                {
                    nextBit = 0;
                }

                // Add nextBit to binary representation after every iteration. 
                binaryRepresentation += nextBit.ToString();
            }
 
            return binaryRepresentation;
        }
    }
}