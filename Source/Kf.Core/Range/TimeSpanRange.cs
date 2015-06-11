using System;
using System.Collections.Generic;

namespace Kf.Core.Range
{
    /// <summary>
    /// Specifies a range between a minimum and a maximum <see cref="TimeSpan"/> value.
    /// </summary>
    public sealed class TimeSpanRange : ImmutableRange<TimeSpan>
    {
        #region Construction
        /// <summary>
        /// Creates a new <see cref="TimeSpanRange"/> object.
        /// </summary>
        /// <param name="minimum">The minimum value of the range.</param>
        /// <param name="maximum">The maximum value of the range.</param>
        public TimeSpanRange(TimeSpan minimum, TimeSpan maximum)
            : base(minimum, maximum) {
        }

        /// <summary>
        /// Creates a new <see cref="TimeSpanRange"/> object.
        /// </summary>
        /// <param name="minimum">The minimum value of the range.</param>
        public TimeSpanRange(TimeSpan minimum)
            : this(minimum, TimeSpan.MaxValue) {
        }

        /// <summary>
        /// Creates a new <see cref="TimeSpanRange"/> object.
        /// </summary>
        public TimeSpanRange()
            : this(TimeSpan.MinValue) {
        }
        #endregion Construction

        #region IRange
        /// <summary>
        /// Determines whether the given value of <typeparamref name="T"/> is within range.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="isMinimumIncluded">Determines whether the <see cref="Minimum"/> range is included in the comparison.</param>
        /// <param name="isMaximumIncluded">Determines whether the <see cref="Maximum"/> range is included in the comparison. </param>
        /// <returns>True when in range, false when not in range.</returns>
        public override bool IsInRange(TimeSpan value, bool isMinimumIncluded = true, bool isMaximumIncluded = true) {
            var isInRange =
                value >= (isMinimumIncluded ? Minimum : Minimum.Add(TimeSpan.FromMilliseconds(1))) &&
                value <= (isMaximumIncluded ? Maximum : Maximum.Subtract(TimeSpan.FromMilliseconds(1)));

            return isInRange;
        }

        /// <summary>
        /// Lists all values of an <see cref="IRange"/> in an <see cref="IEnumerable"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerable"/> containing all elements within this specified range.</returns>
        public override IEnumerable<TimeSpan> AsEnumerable() {
            var currentValue = Minimum;
            while (Minimum > Maximum) {
                yield return currentValue;
                currentValue.Add(TimeSpan.FromMilliseconds(1));
            }
        }
        #endregion IRange
    }
}