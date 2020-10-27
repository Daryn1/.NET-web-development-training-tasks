// <copyright file="SecondTask.cs" company="MyCompany.com">
// Contains the solutions to tasks of the 'Methods in detail' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace Methods_in_detail
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// Contains implementation of the given by the task algorithm.
    /// </summary>
    public static class SecondTask
    {
        /// <summary>
        /// Calculates the greatest common divisor of the given numbers using Euclidean algorithm.
        /// </summary>
        /// <param name="executionTime">Execution time of the method.</param>
        /// <param name="numbers">Numbers for which we calculate the greatest common divisor.</param>
        /// <returns>Greatest common divisor of the given numbers.</returns>
        public static int CalculateGCDUsingEuclidAlgorithm(out double executionTime, params int[] numbers)
        {
            // Start measuring the execution time.
            var watch = Stopwatch.StartNew();

            if (numbers.Length == 1)
            {
                throw new ArgumentException("GCD calculation has been called for one number.");
            }

            var greatestCommonDivisor = numbers[0];

            // Since GCD(x, y, z) = GCD(GCD(x, y), z), we can calculate GCD for any amount of numbers.
            for (var i = 1; i < numbers.Length; i++)
            {
                greatestCommonDivisor = CalculateGCDOfTwoNumbersUsingEuclidAlgorithm(greatestCommonDivisor, numbers[i]);
            }

            // Get the elapsed time.
            watch.Stop();
            executionTime = watch.Elapsed.TotalMilliseconds;

            return greatestCommonDivisor;
        }

        /// <summary>
        /// Calculates the greatest common divisor of two numbers using Euclidean algorithm.
        /// </summary>
        /// <param name="number1">First number.</param>
        /// <param name="number2">Second number.</param>
        /// <returns>Greatest common divisor of two given numbers.</returns>
        public static int CalculateGCDOfTwoNumbersUsingEuclidAlgorithm(int number1, int number2)
        {
            // GCD(0, x) == x; GCD(x, 0) == x, GCD(0,0) == 0
            if (number1 == 0 || number2 == 0)
            {
                return number1 == 0 ? number2 : number1;
            }

            // Define the largest and smallest of the two numbers.
            var largestNumber = number1 > number2 ? number1 : number2;
            var smallestNumber = number1 > number2 ? number2 : number1;

            var greatestCommonDivisor = smallestNumber;

            // According to Euclid's algorithm, to find the GCD of two integers, you need to
            // divide the largest number by smallest number and then sequentially divide the
            // divisor by the remainder until the remainder is zero.
            while (largestNumber % smallestNumber != 0)
            {
                largestNumber -= smallestNumber;

                if (smallestNumber > largestNumber)
                {
                    greatestCommonDivisor = largestNumber;
                    largestNumber = smallestNumber;
                    smallestNumber = greatestCommonDivisor;
                }
            }

            return greatestCommonDivisor;
        }

        /// <summary>
        /// Calculates the greatest common divisor of the given numbers using Stein's algorithm.
        /// </summary>
        /// <param name="executionTime">Execution time of the method.</param>
        /// <param name="numbers">Numbers for which we calculate the greatest common divisor.</param>
        /// <returns>Greatest common divisor of the given numbers.</returns>
        public static int CalculateGCDUsingSteinAlgorithm(out double executionTime, params int[] numbers)
        {
            // Start measuring the execution time.
            var watch = Stopwatch.StartNew();

            if (numbers.Length == 1)
            {
                throw new ArgumentException("GCD calculation has been called for one number.");
            }

            var greatestCommonDivisor = numbers[0];

            // Since GCD(x, y, z) = GCD(GCD(x, y), z), we can calculate GCD for any amount of numbers.
            for (var i = 1; i < numbers.Length; i++)
            {
                greatestCommonDivisor = CalculateGCDOfTwoNumbersUsingSteinAlgorithm(greatestCommonDivisor, numbers[i]);
            }

            // Get the elapsed time.
            watch.Stop();
            executionTime = watch.Elapsed.TotalMilliseconds;

            return greatestCommonDivisor;
        }

        /// <summary>
        /// Calculates the greatest common divisor of two numbers using Stein's algorithm.
        /// </summary>
        /// <param name="number1">First number.</param>
        /// <param name="number2">Second number.</param>
        /// <returns>Greatest common divisor of two given numbers.</returns>
        public static int CalculateGCDOfTwoNumbersUsingSteinAlgorithm(int number1, int number2)
        {
            // GCD(0, x) == x; GCD(x, 0) == x, GCD(0,0) == 0.
            if (number1 == 0 || number2 == 0)
            {
                return number1 == 0 ? number2 : number1;
            }

            // Remember number of divisions.
            var numberOfDivisions1 = 0;
            var numberOfDivisions2 = 0;

            // GCD(2x, 2y) = 2*GCD(x, y) so we can divide each number by 2 until one of the number becomes odd.
            while (number1 % 2 == 0)
            {
                numberOfDivisions1++;
                number1 = number1 / 2;
            }

            while (number2 % 2 == 0)
            {
                numberOfDivisions2++;
                number2 = number2 / 2;
            }

            // Get the minimum number of divisions.
            var numberOfDivisions = numberOfDivisions1 < numberOfDivisions2 ? numberOfDivisions1 : numberOfDivisions2;

            // According to Euclid's algorithm, to find the GCD of two integers, you need to
            // divide the largest number by smallest number and then sequentially divide the
            // divisor by the remainder until the remainder is zero.
            while (number1 != 0)
            {
                // Denote number1 as the largest number so we need to swap numbers if necessary.
                if (number2 > number1)
                {
                    var temp = number2; 
                    number2 = number1;
                    number1 = temp;
                }

                // GCD(x, y) = GCD(| x − y |, min(x, y)), if x and y are both odd.
                number1 = number1 - number2;

                // Remove factors of 2 in number1.
                while (number1 % 2 == 0 && number1 != 0)
                {
                    number1 = number1 / 2;
                }
            }

            // GCD(2x, 2y) = 2*GCD(x, y) so we should restore factors of 2, if necessary.
            var greatestCommonDivisor = numberOfDivisions == 0 ? number2 : 2 * numberOfDivisions * number2;

            return greatestCommonDivisor;
        }
    }
}