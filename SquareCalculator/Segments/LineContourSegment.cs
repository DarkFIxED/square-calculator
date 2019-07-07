using System;
using SquareCalculator.Properties;

namespace SquareCalculator.Segments
{
    /// <summary>
    /// Line contour segment.
    /// </summary>
    public sealed class LineContourSegment : BaseContourSegment
    {
        /// <summary>
        /// Start segment point.
        /// </summary>
        public readonly Point StartPoint;

        /// <summary>
        /// End segment point.
        /// </summary>
        public readonly Point EndPoint;

        /// <summary>
        /// Length of contour segment.
        /// </summary>
        public readonly double Length;

        /// <summary>
        /// Create new instance of <see cref="LineContourSegment"/>.
        /// </summary>
        /// <param name="startPoint">Start segment point.</param>
        /// <param name="endPoint">End segment point.</param>
        public LineContourSegment(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;

            Length = Math.Sqrt(Math.Pow(EndPoint.X - StartPoint.X, 2) + Math.Pow(EndPoint.Y - StartPoint.Y, 2));
            AssertLengthIsPositive(Length);
        }

        /// <inheritdoc cref="BaseContourSegment"/>
        public override double CalculateIntegralValue()
        {
            return StartPoint.X * (EndPoint.Y - StartPoint.Y) - StartPoint.Y * (EndPoint.X - StartPoint.X);
        }

        private static void AssertLengthIsPositive(double length)
        {
            if (length < double.Epsilon)
                throw new ArgumentException(Exceptions.LengthOfLineSegmentMustBeGreaterThanZero);
        }
    }
}