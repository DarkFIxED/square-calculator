using System;
using SquareCalculator.Properties;
using SquareCalculator.Segments;

namespace SquareCalculator.Figures
{
    /// <summary>
    /// Describes circle figure.
    /// </summary>
    public sealed class Circle : BaseFigure
    {
        /// <summary>
        /// Create new instance of <see cref="Circle"/>.
        /// </summary>
        /// <param name="radius">Circle radius.</param>
        public Circle(double radius)
        {
            AssertIsCorrectCircle(radius);
            SegmentsList.Add(new CircleContourSegment(radius));
        }

        private void AssertIsCorrectCircle(double radius)
        {
            if (radius < 0)
                throw new ArgumentException(Exceptions.RadiusMustBeGreaterThanZero);
        }
    }
}