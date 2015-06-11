using System;
using System.Collections.Generic;

namespace Kf.Core.Range
{
    /// <summary>
    /// Specifies a range between a minimum and a maximum <see cref="Int32"/> value.
    /// </summary>
    public sealed class Int32Range : ImmutableRange<int>
    {
        #region Construction
        /// <summary>
        /// Creates a new <see cref="Int32Range"/> object.
        /// </summary>
        /// <param name="minimum">The minimum value of the range.</param>
        /// <param name="maximum">The maximum value of the range.</param>
        public Int32Range(int minimum, int maximum)
            : base(minimum, maximum) {
        }

        /// <summary>
        /// Creates a new <see cref="Int32Range"/> object.
        /// </summary>
        /// <param name="minimum">The minimum value of the range.</param>
        public Int32Range(int minimum)
            : this(minimum, Int32.MaxValue) {
        }

        /// <summary>
        /// Creates a new <see cref="Int32Range"/> object.
        /// </summary>
        public Int32Range()
            : this(Int32.MinValue) {
        }
        #endregion

        #region IRange
        /// <summary>
        /// Determines whether the given value of <typeparamref name="T"/> is within range.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="isMinimumIncluded">Determines whether the <see cref="Minimum"/> range is included in the comparison.</param>
        /// <param name="isMaximumIncluded">Determines whether the <see cref="Maximum"/> range is included in the comparison. </param>
        /// <returns>True when in range, false when not in range.</returns>
        public override bool IsInRange(int value, bool isMinimumIncluded = true, bool isMaximumIncluded = true) {
            var isInRange =
                value >= (isMinimumIncluded ? Minimum : Minimum + 1) &&
                value <= (isMaximumIncluded ? Maximum : Maximum - 1);

            return isInRange;
        }

        /// <summary>
        /// Lists all values of an <see cref="IRange"/> of <see cref="int"/> in an <see cref="IEnumerable"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerable"/> of <see cref="int"> containing all elements within this specified range.</returns>
        public override IEnumerable<int> AsEnumerable() {
            var numbers = new List<int>();
            for (int i = Minimum; i <= Maximum; i++) {
                numbers.Add(i);
            }

            return numbers;
        }
        #endregion
    }
}
