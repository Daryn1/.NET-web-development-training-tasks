namespace Encapsulation._Inheritance._Polymorphism
{
    using System;
    using System.Linq;

    /// <summary>
    /// Create Polynomial class for working with polynomials of degree n > 0 of one real variable (as an internal structure
    /// for storing coefficients use the sz-array).Override the necessary methods of the System.Object Type and also
    /// overload base operations for working with polynomials.Develop unit-tests.
    /// </summary>
    public class ThirdTask
    {
        public class Polynomial
        {
            public Polynomial(params double[] coefficients)
            {
                this.Coefficients = coefficients;
            }

            public double[] Coefficients { get; set; }

            public static Polynomial operator +(Polynomial polynomial1, Polynomial polynomial2)
            {
                // Element wise addition of two arrays.
                return new Polynomial(polynomial1.Coefficients.Zip(polynomial2.Coefficients, (x, y) => x + y).ToArray());
            }

            public static Polynomial operator -(Polynomial polynomial1, Polynomial polynomial2)
            {
                // Element wise subtraction of arrays.
                return new Polynomial(polynomial1.Coefficients.Zip(polynomial2.Coefficients, (x, y) => x - y).ToArray());
            }

            public static Polynomial operator *(double multiplier, Polynomial polynomial)
            {
                // Element wise multiplication of array.
                return new Polynomial(Array.ConvertAll(polynomial.Coefficients, x => multiplier * x));
            }

            public static Polynomial operator *(Polynomial polynomial, double multiplier)
            {
                return multiplier * polynomial;
            }

            public static Polynomial operator /(Polynomial polynomial, double divisor)
            {
                // Element wise division of array.
                return new Polynomial(Array.ConvertAll(polynomial.Coefficients, x => x / divisor));
            }

            /// <summary>
            /// Evaluates the value of the polynomial at the point x.
            /// </summary>
            /// <param name="x">Point at which we evaluate the polynomial.</param>
            /// <returns>The value of the polynomial at the given point x.</returns>
            public double Evaluate(double x)
            {
                var sum = Coefficients[0];

                for (var i = 1; i < Coefficients.Length; i++)
                {
                    sum += Coefficients[i] * Math.Pow(x, i);
                }

                return sum;
            }

            public override bool Equals(object obj)
            {
                if (!(obj is Polynomial polynomial))
                {
                    return false;
                }

                return this.Coefficients.SequenceEqual(polynomial.Coefficients);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    if (this.Coefficients == null)
                    {
                        return 0;
                    }

                    return this.Coefficients.Aggregate(17, (current, element) => (current * 31) + element.GetHashCode());
                }
            }

            public override string ToString()
            {
                var polynomial = Coefficients[0] != 0 ? Coefficients[0].ToString() : string.Empty;

                for (var i = 1; i < Coefficients.Length; i++)
                {
                    if (Coefficients[i] == 0.0)
                    {
                        continue;
                    }

                    polynomial += $" {Coefficients[i]:+ 0.##;- 0.##;}x^{i}";
                }

                return polynomial;
            }
        }
    }
}