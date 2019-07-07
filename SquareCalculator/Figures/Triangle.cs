using System;
using System.Collections.Generic;
using System.Linq;
using SquareCalculator.Properties;
using SquareCalculator.Segments;

namespace SquareCalculator.Figures
{
    /// <summary>
    /// Describes triangle figure.
    /// </summary>
    public sealed class Triangle : BaseFigure
    {
        /// <summary>
        /// Required sides count to create triangle.
        /// </summary>
        private const int RequiredSidesCount = 3;

        /// <summary>
        /// Is triangle is right.
        /// </summary>
        public readonly bool IsRightTriangle;

        /// <summary>
        /// Create new instance of <see cref="Triangle"/> from side length.
        /// </summary>
        /// <param name="sideLengths">Collection of side lengths.</param>
        /// <returns>New instance of <see cref="Triangle"/></returns>
        public static Triangle FromSidesLengths(IEnumerable<double> sideLengths)
        {
            var sideLengthsList = sideLengths.ToList();

            AssertIsCorrectLengthsCount(sideLengthsList);
            AssertIsCorrectTriangle(sideLengthsList);

            var (vertex1, vertex2, vertex3) = CalculateVertexesCoordinates(sideLengthsList);
            return new Triangle(vertex1, vertex2, vertex3);
        }

        /// <summary>
        /// Create new instance of <see cref="Triangle"/>.
        /// </summary>
        /// <param name="vertex1">Coordinates of first vertex.</param>
        /// <param name="vertex2">Coordinates of second vertex.</param>
        /// <param name="vertex3">Coordinates of third vertex.</param>
        public Triangle(Point vertex1, Point vertex2, Point vertex3)
        {
            var lineSegments = new List<LineContourSegment>
            {
                new LineContourSegment(vertex1, vertex2),
                new LineContourSegment(vertex2, vertex3),
                new LineContourSegment(vertex3, vertex1)
            };
            var segmentsLengths = lineSegments.Select(x => x.Length).ToList();

            AssertIsCorrectTriangle(segmentsLengths);

            SegmentsList.AddRange(lineSegments);
            IsRightTriangle = CheckIsRightTriangle(segmentsLengths);
        }

        private static (Point, Point, Point) CalculateVertexesCoordinates(List<double> sideLengthsList)
        {
            var vertex1 = Point.Zero();
            var vertex2 = new Point(sideLengthsList[0], 0);

            // NOTE: used solution found here: https://e-maxx.ru/algo/circles_intersection
            var a = -2 * vertex2.X;
            var b = -2 * vertex2.Y;
            var c = Math.Pow(vertex2.X, 2) + Math.Pow(vertex2.Y, 2) + Math.Pow(sideLengthsList[1], 2) -
                    Math.Pow(sideLengthsList[2], 2);

            var divider = Math.Pow(a, 2) + Math.Pow(b, 2);
            var x0 = -a * c / divider;
            var y0 = -b * c / divider;

            var d = Math.Pow(sideLengthsList[1], 2) - Math.Pow(c, 2) / divider;
            var multiplier = Math.Sqrt(d / divider);
            var ax = x0 + b * multiplier;
            var ay = y0 - a * multiplier;

            var vertex3 = new Point(ax, ay);

            return (vertex1, vertex2, vertex3);
        }

        private bool CheckIsRightTriangle(List<double> segmentsLengths)
        {
            var orderedLengths = segmentsLengths.OrderBy(x => x).ToList();

            return (Math.Pow(orderedLengths[0], 2) + Math.Pow(orderedLengths[1], 2) - Math.Pow(orderedLengths[2], 2) <
                    double.Epsilon);
        }

        private static void AssertIsCorrectTriangle(List<double> segmentsLengths)
        {
            AssertSegmentLengthIsCorrect(segmentsLengths[0], segmentsLengths[1], segmentsLengths[2]);
            AssertSegmentLengthIsCorrect(segmentsLengths[1], segmentsLengths[0], segmentsLengths[2]);
            AssertSegmentLengthIsCorrect(segmentsLengths[2], segmentsLengths[0], segmentsLengths[1]);
        }

        private static void AssertSegmentLengthIsCorrect(double checkingSegmentLength, double otherSegmentLength1,
            double otherSegmentLength2)
        {
            if (checkingSegmentLength >= otherSegmentLength1 + otherSegmentLength2)
                throw new ArgumentException(Exceptions.InvalidTriangleCoordinates);
        }

        private static void AssertIsCorrectLengthsCount(List<double> sideLengthsList)
        {
            if (sideLengthsList.Count != RequiredSidesCount)
                throw new ArgumentException(Exceptions.TriangleCanContainsOnly3Sides);
        }
    }
}