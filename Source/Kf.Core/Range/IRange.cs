using System.Collections.Generic;

namespace Kf.Core.Range
{
    /// <summary>
    /// Specifies a range between a minimum and a maximum value of <typeparamref name="T"/>.
    /// </summary>
    public interface IRange<T>
    {
        /// <summary>
        /// The minimum value of the range.
        /// </summary>
        T Minimum { get; }

        /// <summary>
        /// The maximum value of the range.
        /// </summary>
        T Maximum { get; }

        /// <summary>
        /// Determines whether the given value of <typeparamref name="T"/> is within range.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="isMinimumIncluded">Determines whether the <see cref="Minimum"/> range is included in the comparison.</param>
        /// <param name="isMaximumIncluded">Determines whether the <see cref="Maximum"/> range is included in the comparison. </param>
        /// <returns>True when in range, false when not in range.</returns>
        bool IsInRange(T value, bool isMinimumIncluded = true, bool isMaximumIncluded = true);

        /// <summary>
        /// Lists all values of an <see cref="IRange"/> in an <see cref="IEnumerable"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerable"/> containing all elements within this specified range.</returns>        
        IEnumerable<T> AsEnumerable();
    }
}
