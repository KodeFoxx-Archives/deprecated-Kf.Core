using System;
using System.Collections.Generic;
using System.Reflection;

namespace Kf.Core.Range
{
    /// <summary>
    /// Abstract base implementation of <see cref="IRange"/> of <typeparam name="T"/>,
    /// specifies a range between a minimum and a maximum value of <typeparamref name="T"/>.
    /// </summary>
    public abstract class ImmutableRange<T> : IRange<T>
    {
        /// <summary>
        /// The minimum value of the range.
        /// </summary>
        public T Minimum { get; }

        /// <summary>
        /// The maximum value of the range.
        /// </summary>
        public T Maximum { get; }

        /// <summary>
        /// Creates a new <see cref="Range"/> object.
        /// </summary>
        /// <param name="minimum">The minimum value of the range.</param>
        /// <param name="maximum">The maximum value of the range.</param>
        public ImmutableRange(T minimum, T maximum) {
            if (!typeof(T).GetTypeInfo().IsValueType) {
                if (minimum.Equals(default(T))) {
                    throw new ArgumentNullException(nameof(minimum));
                }
                if (maximum.Equals(default(T))) {
                    throw new ArgumentNullException(nameof(maximum));
                }
            }

            Minimum = minimum;
            Maximum = maximum;
        }

        /// <summary>
        /// Determines whether the given value of <typeparamref name="T"/> is within range.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="isMinimumIncluded">Determines whether the <see cref="Minimum"/> range is included in the comparison.</param>
        /// <param name="isMaximumIncluded">Determines whether the <see cref="Maximum"/> range is included in the comparison.</param>
        /// <returns>True when in range, false when not in range.</returns>
        public abstract bool IsInRange(T value, bool isMinimumIncluded = true, bool isMaximumIncluded = true);

        /// <summary>
        /// Lists all values of an <see cref="IRange"/> in an <see cref="IEnumerable"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerable"/> containing all elements within this specified range.</returns>   
        public abstract IEnumerable<T> AsEnumerable();
    }
}
