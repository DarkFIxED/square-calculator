using System.Linq;
using SquareCalculator.Figures;

namespace SquareCalculator
{
    /// <summary>
    /// Square calculator.
    /// </summary>
    public class SquareCalculator
    {
        /// <summary>
        /// Calculate square of specified figure.
        /// </summary>
        /// <param name="figure">Figure.</param>
        /// <returns>Figure square.</returns>
        public virtual double Calculate(BaseFigure figure)
        {
            // NOTE: used solution found here:
            // https://natalibrilenova.ru/blog/1303-formula-grina-ploschad-ploskoy-oblasti-massa-krivoy-ploschad-cilindricheskoy-poverhnosti.html
            return 0.5 * figure.Segments.Select(f => f.CalculateIntegralValue()).Sum();
        }
    }
}