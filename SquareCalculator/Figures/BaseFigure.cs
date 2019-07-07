using System.Collections.Generic;
using SquareCalculator.Segments;

namespace SquareCalculator.Figures
{
    /// <summary>
    /// Base figure class.
    /// </summary>
    public abstract class BaseFigure
    {
        /// <summary>
        /// List with figure segments.
        /// </summary>
        protected List<BaseContourSegment> SegmentsList;

        /// <summary>
        /// Figure segments.
        /// </summary>
        public IEnumerable<BaseContourSegment> Segments => SegmentsList;

        protected BaseFigure()
        {
            SegmentsList = new List<BaseContourSegment>();
        }
    }
}