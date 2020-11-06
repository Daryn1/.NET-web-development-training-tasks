namespace Object_oriented_design_principles
{
    using System;
    using System.Linq;

    /// <summary>
    /// Create generic classes for representing square, symmetric and diagonal matrices
    /// (a symmetric matrix is a square matrix that coincides with its transpose to it,
    /// a diagonal matrix is a square matrix whose elements outside the main diagonal
    /// obviously have default values for the element type). Describe in the created
    /// classes an event that occurs when a matrix element with indices (i, j) changes.
    /// To provide the possibility of extending the functionality of the class hierarchy,
    /// adding the possibility for the addition operation of two matrices of any kind.
    /// Develop unit-tests.
    /// </summary>
    public class FirstTask
    {
        public static class MatrixFactory
        {
            public static SquareMatrix Create(double[][] matrix)
            {
                if (IsMatrixDiagonal(matrix))
                {
                    return new DiagonalMatrix(matrix);
                }
                else if (IsMatrixSymmetric(matrix))
                {
                    return new SymmetricMatrix(matrix);
                }
                else
                {
                    return new SquareMatrix(matrix);
                }
            }

            private static bool IsMatrixSymmetric(double[][] matrix)
            {
                for (var row = 0; row < matrix.Length - 1; row++)
                {
                    for (var column = 0; column < matrix.Length - 1; column++)
                    {
                        if (Math.Abs(matrix[row][column] - matrix[column][row]) > 0.0001)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            private static bool IsMatrixDiagonal(double[][] matrix)
            {
                for (var row = 0; row < matrix.Length - 1; row++)
                {
                    for (var column = 0; column < matrix.Length - 1; column++)
                    {
                        if ((row != column && matrix[row][column] != 0.0) || (row == column && matrix[row][column] == 0.0))
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }

        public class SquareMatrix
        {
            private double[][] matrix;

            public SquareMatrix(double[][] matrix)
            {
                this.matrix = matrix;
            }

            public event EventHandler<ElementChangedArgs> ElementChanged = ElementChangedHandler;

            public double this[int row, int column]
            {
                get => matrix[row][column];
                set
                {
                    matrix[row][column] = value;
                    OnElementChanged(row, column);
                }
            }

            public static SquareMatrix operator +(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
            {
                if (firstMatrix.matrix.Length != secondMatrix.matrix.Length)
                {
                    throw new ArgumentException("Addition can only be applied to matrices of the same size.");
                }

                var sumOfMatrices = new double[firstMatrix.matrix.Length][];

                for (var i = 0; i < firstMatrix.matrix.Length; i++)
                {
                    sumOfMatrices[i] = firstMatrix.matrix[i].Zip(secondMatrix.matrix[i], (x, y) => x + y).ToArray();
                }

                return MatrixFactory.Create(sumOfMatrices);
            }

            public void OnElementChanged(int row, int column)
            {
                var arguments = new ElementChangedArgs { Row = row, Column = column };

                ElementChanged?.Invoke(this, arguments);
            }

            public override string ToString()
            {
                return matrix.Aggregate(string.Empty, (current, row) => current + $"[{string.Join(", ", row)}]" + Environment.NewLine);
            }

            public override bool Equals(object obj)
            {
                if (!(obj is SquareMatrix anotherMatrix))
                {
                    return false;
                }

                for (var row = 0; row < matrix.Length; row++)
                {
                    for (var column = 0; column < matrix.Length; column++)
                    {
                        if (Math.Abs(matrix[row][column] - anotherMatrix.matrix[row][column]) > 0.0001)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    if (this.matrix == null)
                    {
                        return 0;
                    }

                    return this.matrix.Aggregate(17, (current, element) => (current * 31) + element.GetHashCode());
                }
            }

            private static void ElementChangedHandler(object source, ElementChangedArgs arg)
            {
                Console.WriteLine($"The Element of the matrix with indices ({arg.Row}, {arg.Column}) has been changed by {source.GetType().Name}");
            }

            public class ElementChangedArgs : EventArgs
            {
                public int Row { get; set; }

                public int Column { get; set; }
            }
        }

        public class SymmetricMatrix : SquareMatrix
        {
            public SymmetricMatrix(double[][] matrix) : base(matrix)
            {
            }
        }

        public class DiagonalMatrix : SquareMatrix
        {
            public DiagonalMatrix(double[][] matrix) : base(matrix)
            {
            }
        }
    }
}