namespace Encapsulation._Inheritance._Polymorphism
{
    using System;

    /// <summary>
    /// Contains implementation of the given by the task algorithm.
    /// </summary>
    public class SecondTask
    {
        public abstract class GeometricShape
        {
            public abstract double CalculateArea();

            public abstract double CalculatePerimeter();
        }

        public class Circle : GeometricShape
        {
            public Circle(double radius)
            {
                this.Radius = radius;
            }

            public double Radius
            {
                get; private set;
            }

            public override double CalculateArea()
            {
                return Math.PI * this.Radius * this.Radius;
            }

            public override double CalculatePerimeter()
            {
                return Math.PI * 2 * this.Radius;
            }
        }

        public class Triangle : GeometricShape
        {
            public Triangle(double firstSide, double secondSide, double thirdSide)
            {
                this.FirstSide = firstSide;
                this.SecondSide = secondSide;
                this.ThirdSide = thirdSide;
            }

            public double FirstSide
            {
                get; private set;
            }

            public double SecondSide
            {
                get; private set;
            }

            public double ThirdSide
            {
                get; private set;
            }

            public override double CalculateArea()
            {
                var semiPerimeter = this.CalculatePerimeter() / 2;

                // Calculate area of triangle using Heron’s formula.
                var area = Math.Sqrt(semiPerimeter * (semiPerimeter - this.FirstSide) * (semiPerimeter - this.SecondSide) *
                                     (semiPerimeter - this.ThirdSide));

                return area;
            }

            public override double CalculatePerimeter()
            {
                return this.FirstSide + this.SecondSide + this.ThirdSide;
            }
        }

        public class Square : GeometricShape
        {
            public Square(double side)
            {
                this.Side = side;
            }

            public double Side
            {
                get; private set;
            }

            public override double CalculateArea()
            {
                return this.Side * this.Side;
            }

            public override double CalculatePerimeter()
            {
                return 4 * this.Side;
            }
        }
        
        public class Rectangle : GeometricShape
        {
            public Rectangle(double firstSide, double secondSide)
            {
                this.FirstSide = firstSide;
                this.SecondSide = secondSide;
            }

            public double FirstSide
            {
                get; private set;
            }

            public double SecondSide
            {
                get; private set;
            }

            public override double CalculateArea()
            {
                return this.FirstSide * this.SecondSide;
            }

            public override double CalculatePerimeter()
            {
                return (2 * this.FirstSide) + (2 * this.SecondSide);
            }
        }
    }
}