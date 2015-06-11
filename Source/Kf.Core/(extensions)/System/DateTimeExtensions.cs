using System;
using System.Collections.Generic;
using System.Linq;
using Kf.Core.Range;

namespace Kf
{
    /// <summary>
    /// Provides extension methods to interact with <see cref="DateTime"/> objects.
    /// </summary>
    public static class DateTimeExtensions
    {
        #region IsDay (Method Family)
        /// <summary>
        /// Holds a reference to the weekend days.
        /// </summary>
        private readonly static IEnumerable<DayOfWeek> _weekendDays = new List<DayOfWeek>() {
            DayOfWeek.Saturday, DayOfWeek.Sunday
        };

        /// <summary>
        /// Determines whether the current <see cref="DateTime"/> matches with the given <paramref name="dayOfWeek"/>.
        /// </summary>
        /// <param name="dateTime">The given date to check.</param>
        /// <param name="dayOfWeek">The <see cref="DayOfWeek"/> to check for.</param>
        /// <returns>True when <paramref name="dayOfWeek"/> matches; false when not.</returns>
        public static bool IsDay(this DateTime dateTime, DayOfWeek dayOfWeek) {
            return dateTime.DayOfWeek.Equals(dayOfWeek);
        }

        /// <summary>
        /// Determines whether the current <see cref="DateTime"/> matches with any of the given <paramref name="daysOfWeek"/>.
        /// </summary>
        /// <param name="dateTime">The given date to check.</param>
        /// <param name="daysOfWeek">The <see cref="DayOfWeek"/>s to check for.</param>
        /// <returns>True when <paramref name="daysOfWeek"/> matches one; false when not.</returns>
        public static bool IsDayIn(this DateTime dateTime, IEnumerable<DayOfWeek> daysOfWeek) {
            if (daysOfWeek == null)
                return false;

            if (daysOfWeek.Count() == 0)
                return false;

            return daysOfWeek.Contains(dateTime.DayOfWeek);
        }

        /// <summary>
        /// Datermines whether the current <see cref="DateTime"/> is a weekend day (<see cref="DayOfWeek.Saturday"/> or <see cref="DayOfWeek.Sunday"/>).
        /// </summary>
        /// <param name="dateTime">The given date to check.</param>
        /// <returns>True when weekend day (<see cref="DayOfWeek.Saturday"/> or <see cref="DayOfWeek.Sunday"/>); false when not.</returns>
        public static bool IsWeekend(this DateTime dateTime) {
            return _weekendDays.Contains(dateTime.DayOfWeek);
        }

        /// <summary>
        /// Determines whether the current <see cref="DateTime"/> is a <see cref="DayOfWeek.Monday"/>.
        /// </summary>
        /// <param name="dateTime">The given date to check.</param>
        /// <returns>True when <see cref="DayOfWeek.Monday"/>, false when not.</returns>
        public static bool IsMonday(this DateTime dateTime) {
            return dateTime.IsDay(DayOfWeek.Monday);
        }

        /// <summary>
        /// Determines whether the current <see cref="DateTime"/> is a <see cref="DayOfWeek.Tuesday"/>.
        /// </summary>
        /// <param name="dateTime">The given date to check.</param>
        /// <returns>True when <see cref="DayOfWeek.Tuesday"/>, false when not.</returns>
        public static bool IsTuesday(this DateTime dateTime) {
            return dateTime.IsDay(DayOfWeek.Tuesday);
        }

        /// <summary>
        /// Determines whether the current <see cref="DateTime"/> is a <see cref="DayOfWeek.Wednesday"/>.
        /// </summary>
        /// <param name="dateTime">The given date to check.</param>
        /// <returns>True when <see cref="DayOfWeek.Wednesday"/>, false when not.</returns>
        public static bool IsWednesday(this DateTime dateTime) {
            return dateTime.IsDay(DayOfWeek.Wednesday);
        }

        /// <summary>
        /// Determines whether the current <see cref="DateTime"/> is a <see cref="DayOfWeek.Thursday"/>.
        /// </summary>
        /// <param name="dateTime">The given date to check.</param>
        /// <returns>True when <see cref="DayOfWeek.Thursday"/>, false when not.</returns>
        public static bool IsThursday(this DateTime dateTime) {
            return dateTime.IsDay(DayOfWeek.Thursday);
        }

        /// <summary>
        /// Determines whether the current <see cref="DateTime"/> is a <see cref="DayOfWeek.Friday"/>.
        /// </summary>
        /// <param name="dateTime">The given date to check.</param>
        /// <returns>True when <see cref="DayOfWeek.Friday"/>, false when not.</returns>
        public static bool IsFriday(this DateTime dateTime) {
            return dateTime.IsDay(DayOfWeek.Friday);
        }

        /// <summary>
        /// Determines whether the current <see cref="DateTime"/> is a <see cref="DayOfWeek.Saturday"/>.
        /// </summary>
        /// <param name="dateTime">The given date to check.</param>
        /// <returns>True when <see cref="DayOfWeek.Saturday"/>, false when not.</returns>
        public static bool IsSaturday(this DateTime dateTime) {
            return dateTime.IsDay(DayOfWeek.Saturday);
        }

        /// <summary>
        /// Determines whether the current <see cref="DateTime"/> is a <see cref="DayOfWeek.Sunday"/>.
        /// </summary>
        /// <param name="dateTime">The given date to check.</param>
        /// <returns>True when <see cref="DayOfWeek.Sunday"/>, false when not.</returns>
        public static bool IsSunday(this DateTime dateTime) {
            return dateTime.IsDay(DayOfWeek.Sunday);
        }
        #endregion

        #region NextDay (Method Family)
        /// <summary>
        /// Holds a reference to the range of "DayOfWeek".
        /// </summary>
        private readonly static IRange<int> _dayOfWeekRange = new Int32Range(0, 6);

        /// <summary>
        /// Returns the next day for the current <see cref="DateTime"/>.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to return the next day for.</param>
        /// <returns>The next day for the current <see cref="DateTime"/>.</returns>
        public static DateTime NextDay(this DateTime dateTime) {
            return dateTime.AddDays(1);
        }

        /// <summary>
        /// Returns the previous day for the current <see cref="DateTime"/>.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to return the previous day for.</param>
        /// <returns>The previous day for the current <see cref="DateTime"/>.</returns>
        public static DateTime PreviousDay(this DateTime dateTime) {
            return dateTime.AddDays(-1);
        }

        /// <summary>
        /// Returns the next <paramref name="dayOfWeek"/> starting from the current <see cref="Datetime"/>.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> the calculation starts from.</param>
        /// <param name="dayOfWeek">The <see cref="DayOfWeek"/> to get.</param>
        /// <returns>The next <paramref name="dayOfWeek"/> starting from the current <see cref="Datetime"/>.</returns>
        public static DateTime NextDay(this DateTime dateTime, DayOfWeek dayOfWeek) {
            var addDaysModifier = CalculateDifferenceBetweenDayOfWeek(dateTime.DayOfWeek, dayOfWeek);
            if (addDaysModifier == 0) {
                addDaysModifier = 7;
            }

            return dateTime.AddDays(addDaysModifier);
        }

        /// <summary>
        /// Returns the previous <paramref name="dayOfWeek"/> starting from the current <see cref="Datetime"/>.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> the calculation starts from.</param>
        /// <param name="dayOfWeek">The <see cref="DayOfWeek"/> to get.</param>
        /// <returns>The previous <paramref name="dayOfWeek"/> starting from the current <see cref="Datetime"/>.</returns>
        public static DateTime PreviousDay(this DateTime dateTime, DayOfWeek dayOfWeek) {
            var addDaysModifier = CalculateDifferenceBetweenDayOfWeek(dayOfWeek, dateTime.DayOfWeek) * -1;
            if (addDaysModifier == 0) {
                addDaysModifier = -7;
            }

            return dateTime.AddDays(addDaysModifier);
        }

        /// <summary>
        /// Calculates the difference between two <see cref="DayOfWeek"/>.
        /// </summary>
        /// <remarks>
        /// Props to Tim Schmelter and mbeckish @[http://stackoverflow.com/questions/9219083/get-difference-in-days-between-two-weekdays]
        /// </remarks>
        /// <param name="start">Starting <see cref="DayOfWeek"/>.</param>
        /// <param name="end">Ending <see cref="DayOfWeek"/>.</param>
        /// <returns>The difference between two <see cref="DayOfWeek"/>s.</returns>
        private static int CalculateDifferenceBetweenDayOfWeek(DayOfWeek start, DayOfWeek end) {
            return (7 + (end - start)) % 7;
        }
        #endregion
    }
}
