// <copyright file="FirstTask.cs" company="MyCompany.com">
// Contains the solutions to tasks of the 'Creating types in C#' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace Creating_types_in_CSharp
{
    using System;

    /// <summary>
    /// Contains implementation of the given by the task algorithm.
    /// </summary>
    public class FirstTask
    {
        /// <summary>
        /// Finds root of a number using Newton’s method.
        /// </summary>
        /// <param name="a">Number from which we extract root.</param>
        /// <param name="n">Degree of the root.</param>
        /// <param name="accuracy">Precision with which we calculate the root of the number.</param>
        /// <returns>nth root of a number</returns>
        public static double FindNthRoot(double a, double n, double accuracy)
        {
            if (n < 0 || accuracy < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(a)} and {nameof(accuracy)} should be positive numbers");
            }

            if (a < 0 && n % 2 == 0)
            {
                throw new ArgumentOutOfRangeException($"For square roots {nameof(a)} should be positive number");
            }

            // We need to find x = a^(1/n). It can be represented as a following: x^n = a.
            // We can imagine the problem as finding root of the function f(x) = x^n - a.
            // Definition of this function:
            double Function(double x) => Math.Pow(x, n) - a;

            // Newton’s method require the derivative of the function:
            double FunctionsDerivative(double x) => n * Math.Pow(x, n - 1);

            // The initial guess of the root.
            var xPrevious = 0.5;

            // Next iteration of the calculation of the root.
            var xNext = xPrevious - (Function(xPrevious) / FunctionsDerivative(xPrevious));

            // Stop when the desired accuracy is achieved.
            while (Math.Abs(xNext - xPrevious) > accuracy)
            {
                xPrevious = xNext;

                // Next iteration.
                xNext = xPrevious - (Function(xPrevious) / FunctionsDerivative(xPrevious));
            }

            // Calculate the number of fractional digits that the value of root should have taking
            // into account the specified accuracy.
            var numberOfFractionalDigits = accuracy.ToString().Length - 2;
            
            // Round the value of root.
            return Math.Round(xNext, numberOfFractionalDigits);
        }
    }
}