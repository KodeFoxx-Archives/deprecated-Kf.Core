using System;
using System.Collections.Generic;
using System.Linq;
using Kf.Core.Range;

namespace Kf
{
    /// <summary>
    /// Provides extension methods to interact with <see cref="IRange"/> of "T" objects.
    /// </summary>
    public static class IRangeExtensions
    {
        #region IRange<DateTime>
        /// <summary>
        /// Lists all weekdays of an <see cref="IRange"/> of <see cref="DateTime"/> in an <see cref="IEnumerable"/>.
        /// </summary>        
        /// <returns>An <see cref="IEnumerable"/> of <see cref="int"> containing all weekdays within the specified range.</returns>
        public static IEnumerable<DateTime> GetWeekdays(this IRange<DateTime> range) {
            return range.GetDays(d => !d.IsWeekend());
        }

        /// <summary>
        /// Lists all weekend days of an <see cref="IRange"/> of <see cref="DateTime"/> in an <see cref="IEnumerable"/>.
        /// </summary>        
        /// <returns>An <see cref="IEnumerable"/> of <see cref="int"> containing all weekend days within the specified range.</returns>
        public static IEnumerable<DateTime> GetWeekendDays(this IRange<DateTime> range) {
            return range.GetDays(d => d.IsWeekend());
        }

        /// <summary>
        /// Lists all <see cref="Datetime"/> objects of an <see cref="IRange"/> of <see cref="Datetime"/> that are equal to the given <see cref="DayOfWeek"/>.
        /// </summary>        
        /// <param name="dayOfWeek">The <see cref="DayOfWeek"/> to return all days of.</param>
        /// <returns>All <see cref="Datetime"/> objects of an <see cref="IRange"/> of <see cref="Datetime"/> that are equal to the given <see cref="DayOfWeek"/>.</returns>
        public static IEnumerable<DateTime> GetDays(this IRange<DateTime> range, DayOfWeek dayOfWeek) {
            return range.GetDays(d => d.DayOfWeek.Equals(dayOfWeek));
        }

        /// <summary>
        /// Lists all <see cref="Datetime"/> objects of an <see cref="IRange"/> of <see cref="Datetime"/> that are equal to the given <see cref="DayOfWeek"/>s.
        /// </summary>        
        /// <param name="daysOfWeek">The <see cref="DayOfWeek"/>s to return all days of.</param>
        /// <returns>All <see cref="Datetime"/> objects of an <see cref="IRange"/> of <see cref="Datetime"/> that are equal to the given <see cref="DayOfWeek"/>s.</returns>
        public static IEnumerable<DateTime> GetDays(this IRange<DateTime> range, IEnumerable<DayOfWeek> daysOfWeek) {
            if (daysOfWeek == null) {
                return new List<DateTime>();
            }

            return range.GetDays(d => daysOfWeek.Distinct().Contains(d.DayOfWeek));
        }

        /// <summary>
        /// Lists all <see cref="DateTime"/> objects of an <see cref="IRange"/> of <see cref="DateTime"/> that comply with the given <paramref name="condition"/>.
        /// </summary>        
        /// <param name="condition">The condition each date time is tested against.</param>
        /// <returns>All <see cref="DateTime"/> objects of an <see cref="IRange"/> of <see cref="DateTime"/> that comply with the given <paramref name="condition"/>.</returns>
        public static IEnumerable<DateTime> GetDays(this IRange<DateTime> range, Func<DateTime, bool> condition) {
            var date = range.Minimum;

            do {
                if (condition(date)) {
                    yield return date.Date;
                }

                date = date.NextDay();
            } while (range.IsInRange(date));
        }

        /// <summary>
        /// Lists all <see cref="DateTime"/> objects of an <see cref="IRange"/> of <see cref="DateTime"/>.
        /// </summary>
        /// <returns>All <see cref="DateTime"/> objects of an <see cref="IRange"/> of <see cref="DateTime"/>.</returns>
        public static IEnumerable<DateTime> GetDays(this IRange<DateTime> range) {
            var date = range.Minimum;

            do {
                yield return date.Date;

                date = date.NextDay();
            } while (range.IsInRange(date));
        }
        #endregion
    }
}
