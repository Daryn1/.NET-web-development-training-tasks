namespace Object_oriented_design_principles_Tests
{
    using NUnit.Framework;
    using Object_oriented_design_principles;

    [TestFixture]
    public class FirstTaskTest
    {
        private static readonly double[][] SquareArray1 = new double[][]
        {
            new double[] { 1, 2, 3, 4 },
            new double[] { 5, 6, 7, 8 },
            new double[] { 9, 10, 11, 12 },
            new double[] { 13, 14, 15, 16 }
        };

        private static readonly double[][] SymmetricArray = new double[][]
        {
            new double[] { 1, 2, 3, 4 },
            new double[] { 2, 3, 4, 5 },
            new double[] { 3, 4, 5, 6 },
            new double[] { 4, 5, 6, 7 }
        };
        
        private static readonly double[][] SumOfSquareAndSymmetricArrays = new double[][]
        {
            new double[] { 2, 4, 6, 8 },
            new double[] { 7, 9, 11, 13 },
            new double[] { 12, 14, 16, 18 },
            new double[] { 17, 19, 21, 23 }
        };

        private static readonly double[][] DiagonalArray = new double[][]
        {
            new double[] { 1, 0, 0, 0 },
            new double[] { 0, 3, 0, 0 },
            new double[] { 0, 0, 5, 0 },
            new double[] { 0, 0, 0, 7 }
        };

        private static readonly double[][] SumOfSymmetricAndDiagonalArrays = new double[][]
        {
            new double[] { 2, 2, 3, 4 },
            new double[] { 2, 6, 4, 5 },
            new double[] { 3, 4, 10, 6 },
            new double[] { 4, 5, 6, 14 }
        };

        [Test]
        public void MatrixCreationTest()
        {
            var squareMatrix = FirstTask.MatrixFactory.Create(SquareArray1);
            var symmetricMatrix = FirstTask.MatrixFactory.Create(SymmetricArray);
            var diagonalMatrix = FirstTask.MatrixFactory.Create(DiagonalArray);

            Assert.IsInstanceOf<FirstTask.SquareMatrix>(squareMatrix);
            Assert.IsInstanceOf<FirstTask.SymmetricMatrix>(symmetricMatrix);
            Assert.IsInstanceOf<FirstTask.DiagonalMatrix>(diagonalMatrix);
        }

        [Test]
        public void AdditionTest()
        {
            var squareMatrix = FirstTask.MatrixFactory.Create(SquareArray1);
            var symmetricMatrix = FirstTask.MatrixFactory.Create(SymmetricArray);
            var diagonalMatrix = FirstTask.MatrixFactory.Create(DiagonalArray);
            var sumOfSquareAndSymmetricMatrices = FirstTask.MatrixFactory.Create(SumOfSquareAndSymmetricArrays);
            var sumOfSymmetricAndDiagonalMatrices = FirstTask.MatrixFactory.Create(SumOfSymmetricAndDiagonalArrays);

            Assert.AreEqual(squareMatrix + symmetricMatrix, sumOfSquareAndSymmetricMatrices);
            Assert.AreEqual(symmetricMatrix + diagonalMatrix, sumOfSymmetricAndDiagonalMatrices);
            Assert.IsInstanceOf<FirstTask.SquareMatrix>(squareMatrix + symmetricMatrix);
            Assert.IsInstanceOf<FirstTask.SymmetricMatrix>(symmetricMatrix + diagonalMatrix);
        }

        [Test]
        public void ElementChangedEventTest()
        {
            var squareMatrix = FirstTask.MatrixFactory.Create(SquareArray1);
            var symmetricMatrix = FirstTask.MatrixFactory.Create(SymmetricArray);
            var diagonalMatrix = FirstTask.MatrixFactory.Create(DiagonalArray);

            var elementChangedCounter = 0;

            squareMatrix.ElementChanged += (source, arg) => elementChangedCounter++;
            symmetricMatrix.ElementChanged += (source, arg) => elementChangedCounter++;
            diagonalMatrix.ElementChanged += (source, arg) => elementChangedCounter++;

            squareMatrix[0, 0] = 0;
            symmetricMatrix[1, 2] = 0;
            diagonalMatrix[3, 3] = 0;

            Assert.AreEqual(3, elementChangedCounter);
        }
    }
}