// <copyright file="AllTaskDemonstration.cs" company="MyCompany.com">
// Contains the solutions to the tasks of the 'Basic Coding in C#' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace Creating_types_in_CSharp
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
            var root = FirstTask.FindNthRoot(8, 3, 0.0001);
            Console.WriteLine($"The root of {3}-degree from the number {8} is {root}");

            // Demonstration of the solution of the second task.
            Console.WriteLine("------------ Second task ------------");
            var array = new int[][]
            {
                new[] { 11, 34, 67, -89, 8 },
                new[] { 1, 4, 3, 2, 5 },
                new[] { 89, 23, 39, 12, -54 },
                new[] { 0, 0, 0, 0, 0 },
                new[] { -3, -54, -99, 81, 66 }
            };

            Console.WriteLine($"Unsorted array:");
            foreach (var row in array)
            {
                Console.WriteLine($"[{string.Join(", ", row)}]");
            }

            // Create Context and initialize it with the strategy.
            var context = new SecondTask.Context(new SecondTask.IncreasingSumsOfRowElements());

            // Perform Context operation that uses the specified strategy.
            var sortedArray = context.SortArrayRows(array);

            Console.WriteLine("Array sorted in order of increasing sums of row elements:");
            foreach (var row in sortedArray)
            {
                Console.WriteLine($"[{string.Join(", ", row)}]");
            }

            // Replace the first strategy with the second in Context.
            context.SetStrategy(new SecondTask.DecreasingSumsOfRowElements());

            // Perform Context operation that uses the second strategy.
            context.SortArrayRows(array);

            Console.WriteLine("Array sorted in order of decreasing sums of row elements:");
            foreach (var row in sortedArray)
            {
                Console.WriteLine($"[{string.Join(", ", row)}]");
            }

            // Replace strategy.
            context.SetStrategy(new SecondTask.IncreasingMaximumElement());

            // Perform operation.
            context.SortArrayRows(array);

            Console.WriteLine("Array sorted in order of increasing maximum elements in a row:");
            foreach (var row in sortedArray)
            {
                Console.WriteLine($"[{string.Join(", ", row)}]");
            }

            // Replace strategy.
            context.SetStrategy(new SecondTask.IncreasingMinimumElement());

            // Perform operation.
            context.SortArrayRows(array);

            Console.WriteLine("Array sorted in order of increasing minimum elements in a row:");
            foreach (var row in sortedArray)
            {
                Console.WriteLine($"[{string.Join(", ", row)}]");
            }
        }
    }
}
