using System;
using NUnit.Framework;
using SquareCalculator.Segments;

namespace SquareCalculator.UnitTests
{
    [TestFixture]
    internal class LineContourSegmentTests
    {

        [Test]
        public void LineContourSegment_SamePoints_ThrowsArgumentException()
        {
            // Arrange.
            var startPoint = Point.Zero();
            var endPoint = Point.Zero();

            // Act and assert.
            Assert.Throws<ArgumentException>(() => new LineContourSegment(startPoint, endPoint));
        }

        [Test]
        public void LineContourSegment_DifferentPoints_ReturnsNewInstanceWithCalculatedLength()
        {
            // Arrange.
            var startPoint = Point.Zero();
            var endPoint = new Point(5,5);
            var length = Math.Sqrt(50);

            // Act.
            var segment = new LineContourSegment(startPoint, endPoint);

            // Assert.
            Assert.AreEqual(startPoint, segment.StartPoint);
            Assert.AreEqual(endPoint, segment.EndPoint);
            Assert.AreEqual(length, segment.Length);
        }

        [Test]
        public void CalculateIntegralValue_ReturnsValue()
        {
            // Arrange.
            var startPoint = new Point(1, 2);
            var endPoint = new Point(5, 5);
            double expectedResult = -5;

            var segment = new LineContourSegment(startPoint, endPoint);

            // Act.
            var result = segment.CalculateIntegralValue();

            // Assert.
            Assert.AreEqual(expectedResult, result);
        }
    }
}