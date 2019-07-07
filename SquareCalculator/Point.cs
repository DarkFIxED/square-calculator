namespace SquareCalculator
{
    /// <summary>
    /// Two-dimensional point.
    /// </summary>
    public struct Point
    {
        /// <summary>
        /// Returns new instance of <see cref="Point"/> with zero coordinates.
        /// </summary>
        public static Point Zero()
        {
            return new Point(0, 0);
        }

        /// <summary>
        /// Create instance of <see cref="Point"/>.
        /// </summary>
        /// <param name="x">X value.</param>
        /// <param name="y">Y value.</param>
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// X value.
        /// </summary>
        public double X { get; }

        /// <summary>
        /// Y value.
        /// </summary>
        public double Y { get; }

        public bool Equals(Point other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }
    }
}
