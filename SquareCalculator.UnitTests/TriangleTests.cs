using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SquareCalculator.Figures;

namespace SquareCalculator.UnitTests
{
    [TestFixture]
    internal class TriangleTests
    {
        [Test]
        public void Triangle_DuplicatedVertexes_ThrowsNewArgumentException()
        {
            // Arrange.
            var vertex1 = Point.Zero();
            var vertex2 = Point.Zero();
            var vertex3 = new Point(5,6);

            // Act and assert.
            Assert.Throws<ArgumentException>(() => new Triangle(vertex1, vertex2, vertex3));
        }

        [Test]
        public void Triangle_RightTriangleVertexes_ContainsLineSegments()
        {
            // Arrange.
            var vertex1 = Point.Zero();
            var vertex2 = new Point(0, 4);
            var vertex3 = new Point(5, 0);

            // Act.
            var triangle = new Triangle(vertex1, vertex2, vertex3);

            // Assert.
            Assert.AreEqual(3, triangle.Segments.Count());
        }

        [Test]
        public void Triangle_RightTriangleVertexes_IsRightTriangleIsTrue()
        {
            // Arrange.
            var vertex1 = Point.Zero();
            var vertex2 = new Point(0, 4);
            var vertex3 = new Point(5, 0);

            // Act.
            var triangle = new Triangle(vertex1, vertex2, vertex3);

            // Assert.
            Assert.IsTrue(triangle.IsRightTriangle);   
        }

        [Test]
        public void Triangle_NotRightTriangleVertexes_IsRightTriangleIsFalse()
        {
            // Arrange.
            var vertex1 = Point.Zero();
            var vertex2 = new Point(1, 4);
            var vertex3 = new Point(5, 0);

            // Act.
            var triangle = new Triangle(vertex1, vertex2, vertex3);

            // Assert.
            Assert.IsFalse(triangle.IsRightTriangle);
        }

        [Test]
        public void FromSidesLengths_IncorrectLengths_ThrowsArgumentException()
        {
            // Arrange.
            var lengths = new List<double> {80, 1, 1};
            
            // Act and assert.
            Assert.Throws<ArgumentException>(() => Triangle.FromSidesLengths(lengths));
        }

        [Test]
        public void FromSidesLengths_RightTriangleLengths_IsRightTriangleIsTrue()
        {
            // Arrange.
            var lengths = new List<double> { 3, 4, 5 };

            // Act.
            var triangle = Triangle.FromSidesLengths(lengths);

            // Assert.
            Assert.IsTrue(triangle.IsRightTriangle);
        }

        [Test]
        public void FromSidesLengths_NotRightTriangleLengths_IsRightTriangleIsFalse()
        {
            // Arrange.
            var lengths = new List<double> { 3, 3.5, 5 };

            // Act.
            var triangle = Triangle.FromSidesLengths(lengths);

            // Assert.
            Assert.IsTrue(triangle.IsRightTriangle);
        }
    }
}
