// <copyright file="SecondTask.cs" company="MyCompany.com">
// Contains the solutions to tasks of the 'Creating types in C#' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace Creating_types_in_CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Contains implementation of the given by the task algorithm.
    /// </summary>
    public class SecondTask
    {
        /// <summary>
        /// A class that implements a specific strategy must inherit this interface.
        /// Context class uses this interface to call a specific strategy.
        /// </summary>
        public interface IStrategy
        {
            /// <summary>
            /// Sorts rows of an array.
            /// </summary>
            /// <param name="array">Array to be sorted.</param>
            /// <returns>Sorted array.</returns>
            int[][] SortArrayRows(int[][] array);
        }

        /// <summary>
        /// Sorts rows of an array in the given order using the given rows comparison criteria.
        /// </summary>
        /// <param name="array">Array to be sorted.</param>
        /// <param name="comparisonCriteria">Method that is called for two compared rows to get the comparison criteria.</param>
        /// <param name="inAscending">Boolean variable used to specify the order in which the array is sorted.</param>
        /// <returns>Sorted using comparisonCriteria array in ascending order if inAscending = true; in descending order otherwise.</returns>
        public static int[][] ParameterizedSortArrayRows(int[][] array, Func<IEnumerable<int>, int> comparisonCriteria, bool inAscending)
        {
            var length = array.Length;
            
            // Bubble sort in order of increasing sums of elements of rows of the matrix.
            for (var i = 0; i < length; i++)
            {
                for (var j = i + 1; j < length; j++)
                {
                    if (comparisonCriteria(array[i]) > comparisonCriteria(array[j]))
                    {
                        // Swap rows.
                        var temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            if (inAscending)
            {
                return array;
            }
            else
            {
                return array.Reverse().ToArray();
            }
        }

        /// <summary>
        /// Contains the implementation of SortArrayRows that sorts array rows in ascending order of the sum of their elements.
        /// </summary>
        public class IncreasingSumsOfRowElements : IStrategy
        {
            /// <summary>
            /// Sorts array rows in ascending order of the sum of their elements.
            /// </summary>
            /// <param name="array">Array to be sorted.</param>
            /// <returns>Array whose rows are in ascending order of the sum of their elements.</returns>
            public int[][] SortArrayRows(int[][] array)
            {
                return ParameterizedSortArrayRows(array, Enumerable.Sum, true);
            }
        }

        /// <summary>
        /// Contains the implementation of SortArrayRows that sorts array rows in descending order of the sum of their elements.
        /// </summary>
        public class DecreasingSumsOfRowElements : IStrategy
        {
            /// <summary>
            /// Sorts array rows in descending order of the sum of their elements.
            /// </summary>
            /// <param name="array">Array to be sorted.</param>
            /// <returns>Array whose rows are in descending order of the sum of their elements.</returns>
            public int[][] SortArrayRows(int[][] array)
            {
                return ParameterizedSortArrayRows(array, Enumerable.Sum, false);
            }
        }

        /// <summary>
        /// Contains the implementation of SortArrayRows that sorts array rows in ascending order of the maximum elements of rows.
        /// </summary>
        public class IncreasingMaximumElement : IStrategy
        {
            /// <summary>
            /// Sorts array rows in ascending order of the maximum elements of rows.
            /// </summary>
            /// <param name="array">Array to be sorted.</param>
            /// <returns>Array whose rows are in ascending order of the maximum elements of rows.</returns>
            public int[][] SortArrayRows(int[][] array)
            {
                return ParameterizedSortArrayRows(array, Enumerable.Max, true);
            }
        }

        /// <summary>
        /// Contains the implementation of SortArrayRows that sorts array rows in descending order of the maximum elements of rows.
        /// </summary>
        public class DecreasingMaximumElement : IStrategy
        {
            /// <summary>
            /// Sorts array rows in descending order of the maximum elements of rows.
            /// </summary>
            /// <param name="array">Array to be sorted.</param>
            /// <returns>Array whose rows are in descending order of the maximum elements of rows.</returns>
            public int[][] SortArrayRows(int[][] array)
            {
                return ParameterizedSortArrayRows(array, Enumerable.Max, false);
            }
        }

        /// <summary>
        /// Contains the implementation of SortArrayRows that sorts array rows in ascending order of the minimum elements of rows.
        /// </summary>
        public class IncreasingMinimumElement : IStrategy
        {
            /// <summary>
            /// Sorts array rows in ascending order of the minimum elements of rows.
            /// </summary>
            /// <param name="array">Array to be sorted.</param>
            /// <returns>Array whose rows are in ascending order of the minimum elements of rows.</returns>
            public int[][] SortArrayRows(int[][] array)
            {
                return ParameterizedSortArrayRows(array, Enumerable.Min, true);
            }
        }

        /// <summary>
        /// Contains the implementation of SortArrayRows that sorts array rows in descending order of the minimum elements of rows.
        /// </summary>
        public class DecreasingMinimumElement : IStrategy
        {
            /// <summary>
            /// Sorts array rows in descending order of the minimum elements of rows.
            /// </summary>
            /// <param name="array">Array to be sorted.</param>
            /// <returns>Array whose rows are in descending order of the minimum elements of rows.</returns>
            public int[][] SortArrayRows(int[][] array)
            {
                return ParameterizedSortArrayRows(array, Enumerable.Min, false);
            }
        }

        /// <summary>
        /// Context that uses a strategy to solve its problem.
        /// </summary>
        public class Context
        {
            /// <summary>
            /// IStrategy interface reference that allows the program to automatically switch between specific implementations.
            /// </summary>
            private IStrategy strategy;

            /// <summary>
            /// Initializes a new instance of the Context class.
            /// </summary>
            /// <param name="strategy">Chosen strategy (an object that implements IStrategy interface).</param>
            public Context(IStrategy strategy)
            {
                this.strategy = strategy;
            }

            /// <summary>
            /// Sets a strategy that used by Context to solve its problem.
            /// </summary>
            /// <param name="strategy">Chosen strategy (an object that implements IStrategy interface).</param>
            public void SetStrategy(IStrategy strategy)
            {
                this.strategy = strategy;
            }

            /// <summary>
            /// Sorts rows of an array using chosen strategy.
            /// </summary>
            /// <param name="array">Array to be sorted.</param>
            /// <returns>Sorted array.</returns>
            public int[][] SortArrayRows(int[][] array)
            {
                return this.strategy.SortArrayRows(array);
            }
        }
    }
}