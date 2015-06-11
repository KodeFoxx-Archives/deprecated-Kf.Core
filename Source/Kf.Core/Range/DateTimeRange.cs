using System;
using System.Collections.Generic;

namespace Kf.Core.Range
{
    /// <summary>
    /// Specifies a range between a minimum and a maximum <see cref="DateTime"/> value.
    /// </summary>
    public sealed class DateTimeRange : ImmutableRange<DateTime>
    {
        #region Construction
        /// <summary>
        /// Creates a new <see cref="DateTimeRange"/> object.
        /// </summary>
        /// <param name="minimum">The minimum value of the range.</param>
        /// <param name="maximum">The maximum value of the range.</param>
        public DateTimeRange(DateTime minimum, DateTime maximum)
            : base(minimum, maximum) {
        }

        /// <summary>
        /// Creates a new <see cref="DateTimeRange"/> object.
        /// </summary>
        /// <param name="minimum">The minimum value of the range.</param>
        public DateTimeRange(DateTime minimum)
            : this(minimum, DateTime.MaxValue) {
        }

        /// <summary>
        /// Creates a new <see cref="DateTimeRange"/> object.
        /// </summary>
        public DateTimeRange()
            : this(DateTime.MinValue) {
        }

        /// <summary>
        /// Creates a new <see cref="DateTimeRange"/> object.
        /// </summary>
        /// <param name="year">The year of the minimum value.</param>
        /// <param name="month">The month of the maximum value.</param>
        /// <param name="day">The day of the maximul value.</param>
        public DateTimeRange(int year, int month, int day)
            : this(new DateTime(year, month, day)) {
        }

        /// <summary>
        /// Creates a new <see cref="DateTimeRange"/> object.
        /// </summary>
        /// <param name="minYear">The year of the minimum value.</param>
        /// <param name="minMonth">The month of the minimum value.</param>
        /// <param name="minDay">The day of the minimum value.</param>
        /// <param name="maxYear">The year of the maximum value.</param>
        /// <param name="maxMonth">The month of the maximum value.</param>
        /// <param name="maxDay">The day of the maximum value.</param>
        public DateTimeRange(int minYear, int minMonth, int minDay, int maxYear, int maxMonth, int maxDay)
            : this(new DateTime(minYear, minMonth, minDay), new DateTime(maxYear, maxMonth, maxDay)) {
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
        public override bool IsInRange(DateTime value, bool isMinimumIncluded = true, bool isMaximumIncluded = true) {
            var isInRange =
                value >= (isMinimumIncluded ? Minimum : Minimum.AddMilliseconds(1)) &&
                value <= (isMaximumIncluded ? Maximum : Maximum.AddMilliseconds(-1));

            return isInRange;
        }

        /// <summary>
        /// Lists all values of an <see cref="IRange"/> in an <see cref="IEnumerable"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerable"/> containing all elements within this specified range.</returns>
        public override IEnumerable<DateTime> AsEnumerable() {
            var currentValue = Minimum;
            while (Minimum > Maximum) {
                yield return currentValue;
                currentValue.AddMilliseconds(1);
            }
        }
        #endregion IRange
    }
}