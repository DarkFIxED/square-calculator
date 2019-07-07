using NUnit.Framework;

namespace SquareCalculator.UnitTests
{
    [TestFixture]
    internal class PointTests
    {
        [Test]
        public void Point_Coordinates_ReturnsNewInstanceWithSpecifiedCoordinates()
        {
            // Arrange.
            var x = 7;
            var y = 23;

            // Act.
            var point = new Point(x, y);

            // Assert.
            Assert.AreEqual(x, point.X);
            Assert.AreEqual(y, point.Y);
        }

        [Test]
        public void Zero_ReturnsNewInstanceWithZeroCoordinates()
        {
            // Act.
            var point = Point.Zero();

            // Assert.
            Assert.AreEqual(0, point.X);
            Assert.AreEqual(0, point.Y);
        }
    }
}
