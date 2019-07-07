using System;
using System.Linq;
using NUnit.Framework;
using SquareCalculator.Figures;

namespace SquareCalculator.UnitTests
{
    [TestFixture]
    internal class CircleTests
    {
        [Test]
        public void Circle_NegativeRadius_ThrowsArgumentException()
        {
            // Arrange.
            var negativeRadius = -5;

            // Act and assert.
            Assert.Throws<ArgumentException>(() => new Circle(negativeRadius));
        }

        [Test]
        public void Circle_ZeroRadius_ThrowsArgumentException()
        {
            // Arrange.
            var zeroRadius = 0;

            // Act and assert.
            Assert.Throws<ArgumentException>(() => new Circle(zeroRadius));
        }

        [Test]
        public void Circle_RadiusGreaterThanZero_CreatesInstanceWithCircleSegment()
        {
            // Arrange.
            var radius = 14;

            // Act.
            var circle = new Circle(radius);

            // Assert.
            Assert.True(circle.Segments.Any());
        }
    }
}