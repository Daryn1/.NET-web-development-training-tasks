namespace Encapsulation._Inheritance._Polymorphism_Tests
{
    using Encapsulation._Inheritance._Polymorphism;
    using NUnit.Framework;

    [TestFixture]
    public class ThirdTaskTest
    {
        [TestCase(new double[] { 4, 3, 0, 1 }, 2, ExpectedResult = 18)]
        [TestCase(new double[] { 0, 3, 3, 3 }, 3, ExpectedResult = 117)]
        [TestCase(new double[] { 0, 5, 12, 14 }, 0, ExpectedResult = 0)]
        public double EvaluateTest(double[] coefficients, double x)
        {
            var polynomial = new ThirdTask.Polynomial(coefficients);

            return polynomial.Evaluate(x);
        }

        [TestCase(new double[] { 4, 3, 2, 1 }, new double[] { 1, 2, 3, 4 }, ExpectedResult = new double[] { 5, 5, 5, 5 })]
        [TestCase(new double[] { -4, -3, -2, -1 }, new double[] { 4, 3, 2, 1 }, ExpectedResult = new double[] { 0, 0, 0, 0 })]
        public double[] AdditionTest(double[] coefficients1, double[] coefficients2)
        {
            var polynomial1 = new ThirdTask.Polynomial(coefficients1);
            var polynomial2 = new ThirdTask.Polynomial(coefficients2);

            var sumOfPolynomials = polynomial1 + polynomial2;

            return sumOfPolynomials.Coefficients;
        }

        [TestCase(new double[] { 4, 3, 2, 1 }, new double[] { 4, 3, 2, 1 }, ExpectedResult = new double[] { 0, 0, 0, 0 })]
        [TestCase(new double[] { 9, 8, 7 }, new double[] { -5, 4, -7 }, ExpectedResult = new double[] { 14, 4, 14 })]
        public double[] SubtractionTest(double[] coefficients1, double[] coefficients2)
        {
            var polynomial1 = new ThirdTask.Polynomial(coefficients1);
            var polynomial2 = new ThirdTask.Polynomial(coefficients2);

            var subtractionOfPolynomials = polynomial1 - polynomial2;

            return subtractionOfPolynomials.Coefficients;
        }

        [TestCase(new double[] { 1, 2, 3, 4 }, 10, ExpectedResult = new double[] { 10, 20, 30, 40 })]
        [TestCase(new double[] { -5, 14, 23 }, -1, ExpectedResult = new double[] { 5, -14, -23 })]
        public double[] MultiplicationByNumberTest(double[] coefficients, double multiplier)
        {
            var polynomial = new ThirdTask.Polynomial(coefficients);

            var multiplicationResult1 = polynomial * multiplier;
            var multiplicationResult2 = multiplier * polynomial;

            if (!multiplicationResult1.Equals(multiplicationResult2))
            {
                Assert.Fail("Multiplication result depends on the order of multipliers.");
            }

            return multiplicationResult1.Coefficients;
        }

        [TestCase(new double[] { 10, 20, 30, 40 }, 10, ExpectedResult = new double[] { 1, 2, 3, 4 })]
        [TestCase(new double[] { 5, 4, 3 }, 2, ExpectedResult = new double[] { 2.5, 2, 1.5 })]
        public double[] DivisionTest(double[] coefficients, double divisor)
        {
            var polynomial = new ThirdTask.Polynomial(coefficients);

            var divisionOfPolynomials = polynomial / divisor;

            return divisionOfPolynomials.Coefficients;
        }

        [Test]
        public void EqualsTest()
        {
            var polynomial1 = new ThirdTask.Polynomial(1, 2, 3, 4);
            var polynomial2 = new ThirdTask.Polynomial(4, 3, 2, 1);
            var polynomial3 = new ThirdTask.Polynomial(4, 3, 2, 1);

            Assert.AreEqual(false, polynomial1.Equals(polynomial2));
            Assert.AreEqual(true, polynomial2.Equals(polynomial3));
            Assert.AreEqual(false, polynomial3.Equals(new double[] { 4.0, 3.0, 2.0, 1.0 }));
            Assert.AreEqual(false, polynomial3.Equals(null));
        }

        [TestCase(new double[] { 1, 2, 3, 4 }, ExpectedResult = "1 + 2x^1 + 3x^2 + 4x^3")]
        [TestCase(new double[] { 5, 0, -4, -3 }, ExpectedResult = "5 - 4x^2 - 3x^3")]
        [TestCase(new double[] { 3.5, 2.4, -0.1, 0.22222222 }, ExpectedResult = "3,5 + 2,4x^1 - 0,1x^2 + 0,22x^3")]
        [TestCase(new double[] { 2, 0, 0, 0, 0, 0, 0 }, ExpectedResult = "2")]
        public string ToStringTest(double[] coefficients)
        {
            var polynomial = new ThirdTask.Polynomial(coefficients);

            return polynomial.ToString();
        }
    }
}