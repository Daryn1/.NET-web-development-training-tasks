// <summary> All task demonstration. </summary>
// <copyright file="AllTaskDemonstration.cs" company="MyCompany.com">
// Contains the solutions to the tasks of the 'Encapsulation. Inheritance. Polymorphism' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace Encapsulation._Inheritance._Polymorphism
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
            var array = new int[][]
            {
                new[] { 11, 34, 67, -89, 8 },
                new[] { 1, 4, 3, 2, 5 },
                new[] { 89, 23, 39, 12, -54 },
                new[] { 0, 0, 0, 0, 0 },
                new[] { -3, -54, -99, 81, 66 }
            };

            // Create Matrix object from array.
            var matrix = new FirstTask.Matrix(array);

            // Print the two dimensional array.
            Console.WriteLine($"Unsorted array:");
            Console.WriteLine(matrix);

            // Initialize the visitor.
            FirstTask.IVisitor visitor = new FirstTask.IncreasingSumsOfRowElements();

            // Matrix object is visited which leads to calling that implementation of Visit method that corresponds to visitor.
            matrix.Accept(visitor);

            // Print the sorted array.
            Console.WriteLine("Array sorted in order of increasing sums of row elements:");
            Console.WriteLine(matrix);

            // Change visitor.
            visitor = new FirstTask.DecreasingSumsOfRowElements();
            matrix.Accept(visitor);

            Console.WriteLine("Array sorted in order of decreasing sums of row elements:");
            Console.WriteLine(matrix);

            visitor = new FirstTask.IncreasingMaximumElement();
            matrix.Accept(visitor);

            Console.WriteLine("Array sorted in order of increasing maximum elements in a row:");
            Console.WriteLine(matrix);

            visitor = new FirstTask.IncreasingMinimumElement();
            matrix.Accept(visitor);

            Console.WriteLine("Array sorted in order of increasing minimum elements in a row:");
            Console.WriteLine(matrix);

            // Demonstration of the solution of the second task.
            Console.WriteLine("------------ Second task ------------");
            var circle = new SecondTask.Circle(3.0);
            var triangle = new SecondTask.Triangle(3, 4, 5);
            var square = new SecondTask.Square(4.0);
            var rectangle = new SecondTask.Rectangle(5.0, 6.0);

            Console.WriteLine($"The perimeter of the circle with a radius of {circle.Radius} cm is {circle.CalculatePerimeter()}");
            Console.WriteLine($"The perimeter of the triangle with sides {triangle.FirstSide}, {triangle.SecondSide}, {triangle.ThirdSide} cm is {triangle.CalculatePerimeter()}");
            Console.WriteLine($"The perimeter of the square with a side of {square.Side} cm is {square.CalculatePerimeter()}");
            Console.WriteLine($"The perimeter of the rectangle with sides {rectangle.FirstSide}, {rectangle.SecondSide} cm is {rectangle.CalculatePerimeter()}");

            Console.WriteLine($"The area of the circle with a radius of {circle.Radius} cm is {circle.CalculateArea()} cm2");
            Console.WriteLine($"The area of the triangle with sides {triangle.FirstSide}, {triangle.SecondSide}, {triangle.ThirdSide} cm is {triangle.CalculateArea()} cm2");
            Console.WriteLine($"The area of the square with a side of {square.Side} cm is {square.CalculateArea()} cm2");
            Console.WriteLine($"The area of the rectangle with sides {rectangle.FirstSide}, {rectangle.SecondSide} cm is {rectangle.CalculateArea()} cm2");

            // Demonstration of the solution of the third task.
            Console.WriteLine("------------ Third task ------------");

            // Initialize polynomial f(x) = 1 + 2x + 3x^3 + 4x^4.
            var polynomial1 = new ThirdTask.Polynomial(1, 2, 3, 4);

            // Initialize polynomial f(x) = 4 + 3x + 2x^3 + 1x^4.
            var polynomial2 = new ThirdTask.Polynomial(4, 3, 2, 1);

            Console.WriteLine("Two polynomial:");
            Console.WriteLine(polynomial1);
            Console.WriteLine(polynomial2);
            Console.WriteLine($"Check for equality of two polynomial: p1.Equals(p2) = {polynomial1.Equals(polynomial2)}");
            Console.WriteLine($"The value of the first polynomial at the point x = 2 is {polynomial1.Evaluate(2)}");
            Console.WriteLine($"The value of the second polynomial at the point x = 2 is {polynomial2.Evaluate(2)}");
            Console.WriteLine("Sum of two polynomial:");
            Console.WriteLine(polynomial1 + polynomial2);
            Console.WriteLine("Subtraction of two polynomial:");
            Console.WriteLine(polynomial1 - polynomial2);
            Console.WriteLine("Multiplying the first polynomial by 5:");
            Console.WriteLine(5 * polynomial1);
            Console.WriteLine("Division of the first polynomial by 5:");
            Console.WriteLine(polynomial1 / 5);
        }
    }
}
