using System;

namespace Kf
{
    /// <summary>
    /// Provides extension mmethods to interact with <see cref="String"/> objects.
    /// </summary>
    public static class StringExtensions
    {
        #region Formatting
        /// <summary>
        /// Replaces the format item in the specified string with the string representation of a corresponding object in a specified array.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>The formatted string with string representations in place.</returns>
        /// <remarks>
        /// 1. The extensions method is not called 'Format', because this would clash with the static method 'Format' on the <see cref="String"/> class.
        /// 2. This is just a short-hand way to use the 'String.Format' method directly on a string instance.
        /// </remarks>
        public static string FormatWith(this string format, params object[] args) {
            return String.Format(format, args);
        }

        /// <summary>
        /// Replaces the format item in the specified string with the string representation of a corresponding object in a specified array.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="formatProvider">An object that specifies culture-specific formatting information.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>The formatted string with string representations in place.</returns>
        /// <remarks>
        /// 1. The extensions method is not called 'Format', because this would clash with the static method 'Format' on the <see cref="String"/> class.
        /// 2. This is just a short-hand way to use the 'String.Format' method directly on a string instance.
        /// </remarks>        
        public static string FormatWith(this string format, IFormatProvider formatProvider, params object[] args) {
            return String.Format(formatProvider, format, args);
        }
        #endregion
    }
}
