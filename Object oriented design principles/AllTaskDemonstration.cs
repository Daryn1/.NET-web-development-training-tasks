namespace Object_oriented_design_principles
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
            var squareArray = new double[][]
            {
                new double[] { 1, 2, 3, 4 },
                new double[] { 5, 6, 7, 8 },
                new double[] { 9, 10, 11, 12 },
                new double[] { 13, 14, 15, 16 }
            };

            var symmetricArray = new double[][]
            {
                new double[] { 1, 2, 3, 4 },
                new double[] { 2, 3, 4, 5 },
                new double[] { 3, 4, 5, 6 },
                new double[] { 4, 5, 6, 7 }
            };
            
            var diagonalArray = new double[][]
            {
                new double[] { 1, 0, 0, 0 },
                new double[] { 0, 3, 0, 0 },
                new double[] { 0, 0, 5, 0 },
                new double[] { 0, 0, 0, 7 }
            };

            var squareMatrix = FirstTask.MatrixFactory.Create(squareArray);
            var symmetricMatrix = FirstTask.MatrixFactory.Create(symmetricArray);
            var diagonalMatrix = FirstTask.MatrixFactory.Create(diagonalArray);

            Console.WriteLine("The following matrix:");
            Console.Write(squareMatrix);
            Console.WriteLine($"has type {squareMatrix.GetType().Name}.");

            Console.WriteLine("The following matrix:");
            Console.Write(symmetricMatrix);
            Console.WriteLine($"has type {symmetricMatrix.GetType().Name}.");

            Console.WriteLine("The following matrix:");
            Console.Write(diagonalMatrix);
            Console.WriteLine($"has type {diagonalMatrix.GetType().Name}.");

            var sumOfSymmetricAndDiagonalMatrices = symmetricMatrix + diagonalMatrix;
            var sumOfSquareAndSymmetricMatrices = squareMatrix + symmetricMatrix;

            Console.WriteLine("The sum of symmetric and diagonal matrices:");
            Console.Write(sumOfSymmetricAndDiagonalMatrices);
            Console.WriteLine($"has type {sumOfSymmetricAndDiagonalMatrices.GetType().Name}."); 
            
            Console.WriteLine("The sum of square and symmetric matrices:");
            Console.Write(sumOfSquareAndSymmetricMatrices);
            Console.WriteLine($"has type {sumOfSquareAndSymmetricMatrices.GetType().Name}.");

            Console.WriteLine("Trying to change the first element of the square matrix.");
            squareMatrix[0, 0] = 0;
            Console.WriteLine("Square matrix after modification:");
            Console.Write(squareMatrix);
        }
    }
}
