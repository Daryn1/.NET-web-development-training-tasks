// <copyright file="AllTaskDemonstration.cs" company="MyCompany.com">
// Contains the solutions to the tasks of the 'Basic Coding in C#' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace BasicCodingInCSharp
{
    using System;

    /// <summary>
    /// Contains the demonstrations of the solutions to the tasks
    /// </summary>
    public class AllTaskDemonstration
    {
        /// <summary>
        /// The project should contain Main() method
        /// </summary>
        public static void Main()
        {
            // Demonstration of the solution of the first task
            Console.WriteLine("------------ First task ------------");
            var numberResult = FirstTask.InsertNumber(8, 15, 3, 8);
            Console.WriteLine($"The result of inserting bits from number 15 to number 8 starting from 3 to 8 positions is {numberResult}");

            // Demonstration of the solution of the second task
            Console.WriteLine("------------ Second task ------------");
            var array = new int[]
            {
                5, -3, 2, 9, -1, 16, 0, -6
            };
            var maxNumber = SecondTask.FindMaxRecursive(array, array.Length - 1);
            Console.WriteLine($"The maximum element of array [{string.Join(", ", array)}] is {maxNumber}");

            // Demonstration of the solution of the third task
            Console.WriteLine("------------ Third task ------------");
            var arrayForSecondTask = new double[]
            {
                1.0, 2.0, 3.0, 3.0
            };
            var elementOfEqualityOfLeftAndRightSides = ThirdTask.FindElementOfEqualityOfLeftAndRightSides(arrayForSecondTask);
            Console.WriteLine($"The element of equality of left and right sides of array [{string.Join(", ", arrayForSecondTask)}] is {elementOfEqualityOfLeftAndRightSides}");

            // Demonstration of the solution of the fourth task
            Console.WriteLine("------------ Fourth task ------------");
            var latinAlphabetString1 = new string("abcdefg");
            var latinAlphabetString2 = new string("efghijk");
            var concatenatedStringWithoutDuplicates = FourthTask.ConcatenateExcludingDuplicateCharacters(latinAlphabetString1, latinAlphabetString2);
            Console.WriteLine($"First string: {latinAlphabetString1}");
            Console.WriteLine($"Second string: {latinAlphabetString1}");
            Console.WriteLine($"Concatenated string: {concatenatedStringWithoutDuplicates}");

            // Demonstration of the solution of the fifth task
            Console.WriteLine("------------ Fifth task ------------");
            var nextBiggerNumber = FifthTask.FindNextBiggerNumber(3462345, out var executionTime);
            Console.WriteLine($"Next bigger number: {nextBiggerNumber}");
            Console.WriteLine($"Execution time: {executionTime}");

            // Demonstration of the solution of the sixth task
            Console.WriteLine("------------ Sixth task ------------");
            var testArrayForSixthTask = new int[]
            {
                7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17
            };
            var filteredArray = SixthTask.FilterDigit(testArrayForSixthTask, 7);
            Console.WriteLine($"Input array: [{string.Join(", ", testArrayForSixthTask)}]");
            Console.WriteLine($"Output array: [{string.Join(", ", filteredArray)}]");
        }
    }
}