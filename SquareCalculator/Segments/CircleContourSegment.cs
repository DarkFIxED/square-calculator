using System;
using SquareCalculator.Properties;

namespace SquareCalculator.Segments
{
    /// <summary>
    /// Circle contour segment.
    /// </summary>
    public sealed class CircleContourSegment : BaseContourSegment
    {
        /// <summary>
        /// Circle radius.
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// Create new instance of <see cref="CircleContourSegment"/>.
        /// </summary>
        /// <param name="radius">Circle radius.</param>
        public CircleContourSegment(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException(Exceptions.RadiusMustBeGreaterThanZero);

            Radius = radius;
        }

        /// <inheritdoc cref="BaseContourSegment"/>
        public override double CalculateIntegralValue()
        {
            return 2 * Math.PI * Math.Pow(Radius, 2);
        }
    }
}