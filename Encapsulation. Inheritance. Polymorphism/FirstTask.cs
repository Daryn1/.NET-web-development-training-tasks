// <summary> First task. </summary>
// <copyright file="FirstTask.cs" company="MyCompany.com">
// Contains the solutions to the tasks of the 'Encapsulation. Inheritance. Polymorphism' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace Encapsulation._Inheritance._Polymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Contains implementation of the given by the task algorithm.
    /// </summary>
    public class FirstTask
    {
        /// <summary>
        /// The Visitor interface, which declares a Visit operation for each the concrete visitor to implement.
        /// </summary>
        public interface IVisitor
        {
            /// <summary>
            /// Sorts rows of the array in Matrix object.
            /// </summary>
            /// <param name="matrix">Matrix object that contains the array to be sorted.</param>
            void Visit(Matrix matrix);
        }

        /// <summary>
        /// Sorts rows of an array in the given order using the given rows comparison criteria.
        /// </summary>
        /// <param name="array">Array to be sorted.</param>
        /// <param name="comparisonCriteria">Method that is called for two compared rows to get the comparison criteria.</param>
        /// <param name="inAscending">Boolean variable used to specify the order in which the array is sorted.</param>
        public static void ParameterizedSortArrayRows(int[][] array, Func<IEnumerable<int>, int> comparisonCriteria, bool inAscending)
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

            if (!inAscending)
            {
                Array.Reverse(array);
            }
        }

        /// <summary>
        /// Defines an Accept operation, which needs to be implemented by any class that can be visited.
        /// </summary>
        public abstract class Element
        {
            /// <summary>
            /// It calls the method that corresponds to visitor.
            /// </summary>
            /// <param name="visitor">The object of class that implements IVisitor interface and that provides an implementation to the Visit method.</param>
            public abstract void Accept(IVisitor visitor);
        }

        /// <summary>
        /// It is concrete element class, which implements Accept operation defined by the Element.
        /// Stores a two dimensional array.
        /// </summary>
        public class Matrix : Element
        {
            /// <summary>
            /// Initializes a new instance of the Matrix class.
            /// </summary>
            /// <param name="array">Two dimensional array to store.</param>
            public Matrix(int[][] array)
            {
                this.Array = array;
            }

            /// <summary>
            /// Gets two dimensional array.
            /// </summary>
            public int[][] Array { get; }

            /// <summary>
            /// Resolved at runtime, it calls the method that corresponds to visitor.
            /// </summary>
            /// <param name="visitor">The object that visits the Matrix class.</param>
            public override void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }

            /// <summary>
            /// Makes printable representation of two dimensional array.
            /// </summary>
            /// <returns>A string that represent two dimensional array that Matrix object stores.</returns>
            public override string ToString()
            {
                return this.Array.Aggregate(string.Empty, (current, row) => current + $"[{string.Join(", ", row)}]" + Environment.NewLine);
            }
        }

        /// <summary>
        /// A Concrete Visitor class.
        /// Contains the implementation of Visit that sorts array rows in ascending order of the sum of their elements.
        /// </summary>
        public class IncreasingSumsOfRowElements : IVisitor
        {
            /// <summary>
            /// Sorts array rows in ascending order of the sum of their elements.
            /// </summary>
            /// <param name="matrix">Matrix object that contains the array to be sorted.</param>
            public void Visit(Matrix matrix)
            {
                ParameterizedSortArrayRows(matrix.Array, Enumerable.Sum, true);
            }
        }

        /// <summary>
        /// A Concrete Visitor class.
        /// Contains the implementation of Visit that sorts array rows in descending order of the sum of their elements.
        /// </summary>
        public class DecreasingSumsOfRowElements : IVisitor
        {
            /// <summary>
            /// Sorts array rows in descending order of the sum of their elements.
            /// </summary>
            /// <param name="matrix">Matrix object that contains the array to be sorted.</param>
            public void Visit(Matrix matrix)
            {
                ParameterizedSortArrayRows(matrix.Array, Enumerable.Sum, false);
            }
        }

        /// <summary>
        /// A Concrete Visitor class.
        /// Contains the implementation of Visit that sorts array rows in ascending order of the maximum elements of rows.
        /// </summary>
        public class IncreasingMaximumElement : IVisitor
        {
            /// <summary>
            /// Sorts array rows in ascending order of the maximum elements of rows.
            /// </summary>
            /// <param name="matrix">Matrix object that contains the array to be sorted.</param>
            public void Visit(Matrix matrix)
            {
                ParameterizedSortArrayRows(matrix.Array, Enumerable.Max, true);
            }
        }

        /// <summary>
        /// A Concrete Visitor class.
        /// Contains the implementation of Visit that sorts array rows in descending order of the maximum elements of rows.
        /// </summary>
        public class DecreasingMaximumElement : IVisitor
        {
            /// <summary>
            /// Sorts array rows in descending order of the maximum elements of rows.
            /// </summary>
            /// <param name="matrix">Matrix object that contains the array to be sorted.</param>
            public void Visit(Matrix matrix)
            {
                ParameterizedSortArrayRows(matrix.Array, Enumerable.Max, false);
            }
        }

        /// <summary>
        /// A Concrete Visitor class.
        /// Contains the implementation of Visit that sorts array rows in ascending order of the minimum elements of rows.
        /// </summary>
        public class IncreasingMinimumElement : IVisitor
        {
            /// <summary>
            /// Sorts array rows in ascending order of the minimum elements of rows.
            /// </summary>
            /// <param name="matrix">Matrix object that contains the array to be sorted.</param>
            public void Visit(Matrix matrix)
            {
                ParameterizedSortArrayRows(matrix.Array, Enumerable.Min, true);
            }
        }

        /// <summary>
        /// A Concrete Visitor class.
        /// Contains the implementation of Visit that sorts array rows in descending order of the minimum elements of rows.
        /// </summary>
        public class DecreasingMinimumElement : IVisitor
        {
            /// <summary>
            /// Sorts array rows in descending order of the minimum elements of rows.
            /// </summary>
            /// <param name="matrix">Matrix object that contains the array to be sorted.</param>
            public void Visit(Matrix matrix)
            {
                ParameterizedSortArrayRows(matrix.Array, Enumerable.Min, false);
            }
        }
    }
}