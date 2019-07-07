namespace SquareCalculator.Segments
{
    /// <summary>
    /// Base abstraction which describes segment of figure contour.
    /// </summary>
    public abstract class BaseContourSegment
    {
        /// <summary>
        /// Calculate integral value.
        /// </summary>
        public abstract double CalculateIntegralValue();
    }
}
