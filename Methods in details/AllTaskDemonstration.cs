// <copyright file="AllTaskDemonstration.cs" company="MyCompany.com">
// Contains the solutions to the tasks of the 'Methods in detail' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace Methods_in_detail
{
    using System;

    /// <summary>
    /// Contains the demonstrations of the solutions to the tasks.
    /// </summary>
    public class AllTaskDemonstration
    {
        /// <summary>
        /// The project should contain Main() method.
        /// </summary>
        public static void Main()
        {
            // Demonstration of the solution of the first task.
            Console.WriteLine("------------ First task ------------");
            var numberInIEEE754Format = 0.001.ToIEEE754();
            Console.WriteLine($"The number {255.255} in IEEE754 format is {numberInIEEE754Format}");

            // Demonstration of the solution of the second task.
            Console.WriteLine("------------ Second task ------------");
            var greatestCommonDivisor = SecondTask.CalculateGCDUsingEuclidAlgorithm(out var executionTimeEuclid, 1071231, 462657);
            SecondTask.CalculateGCDUsingSteinAlgorithm(out var executionTimeStein, 1071231, 462657);
            Console.WriteLine($"The greatest common divisor of numbers 1071231 and 462657 is {greatestCommonDivisor} ");
            Console.WriteLine($"Execution time of Euclid's algorithm: {executionTimeEuclid} milliseconds");
            Console.WriteLine($"Execution time of Stein's algorithm: {executionTimeStein} milliseconds");

            // Demonstration of the solution of the third task.
            Console.WriteLine("------------ Third task ------------");
            int? nullableInt = null;
            Console.WriteLine($"The variable {nameof(nullableInt)} value is null. The result of call of IsNull({nameof(nullableInt)}) is {nullableInt.IsNull()}");
            nullableInt = 2;
            Console.WriteLine($"The variable {nameof(nullableInt)} value is {nullableInt}. The result of call of IsNull({nameof(nullableInt)}) is {nullableInt.IsNull()}");
            string testString = "Non empty string";
            Console.WriteLine($"The variable {nameof(testString)} value is {testString}. The result of call of IsNull({nameof(testString)}) is {testString.IsNull()}");
        }
    }
}
