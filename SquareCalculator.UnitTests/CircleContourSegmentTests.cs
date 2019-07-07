using System;
using NUnit.Framework;
using SquareCalculator.Segments;

namespace SquareCalculator.UnitTests
{
    [TestFixture]
    internal class CircleContourSegmentTests
    {
        [Test]
        public void CircleContourSegment_NegativeRadius_ThrowsArgumentException()
        {
            // Arrange.
            var negativeRadius = -1;

            // Act and assert.
            Assert.Throws<ArgumentException>(() => new CircleContourSegment(negativeRadius));
        }

        [Test]
        public void CircleContourSegment_ZeroRadius_ThrowsArgumentException()
        {
            // Arrange.
            var zeroRadius = 0;

            // Act and assert.
            Assert.Throws<ArgumentException>(() => new CircleContourSegment(zeroRadius));
        }

        [Test]
        public void CircleContourSegment_RadiusGreaterThanZero_ReturnsNewInstanceWithSpecifiedRadius()
        {
            // Arrange.
            var radius = 5;

            // Act.
            var segment = new CircleContourSegment(radius);

            // Assert.
            Assert.AreEqual(radius, segment.Radius);
        }

        [Test]
        public void CalculateIntegralValue_ReturnsValue()
        {
            // Arrange.
            var radius = 5;
            var segment = new CircleContourSegment(radius);
            var expectedResult = 2 * Math.PI * Math.Pow(radius, 2);
            // Act.
            var result = segment.CalculateIntegralValue();

            // Assert.
            Assert.AreEqual(expectedResult, result, double.Epsilon);
        }
    }
}