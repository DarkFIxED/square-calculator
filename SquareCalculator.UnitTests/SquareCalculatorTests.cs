using System;
using System.Collections.Generic;
using NUnit.Framework;
using SquareCalculator.Figures;

namespace SquareCalculator.UnitTests
{
    [TestFixture]
    internal class SquareCalculatorTests
    {
        [Test]
        public void Calculate_Triangle_ReturnsTriangleSquare()
        {
            // Arrange.
            var sidesLengths = new List<double> {3, 4, 5};
            var figure = Triangle.FromSidesLengths(sidesLengths);
            var expectedResult = 6;

            var calculator = new SquareCalculator();

            // Act.
            var result = calculator.Calculate(figure);

            // Assert.
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Calculate_Circle_ReturnsCircleSquare()
        {
            // Arrange.
            var radius = 10;
            var figure = new Circle(radius);
            var expectedResult = Math.PI * Math.Pow(radius, 2);

            var calculator = new SquareCalculator();

            // Act.
            var result = calculator.Calculate(figure);

            // Assert.
            Assert.AreEqual(expectedResult, result);
        }
    }
}
