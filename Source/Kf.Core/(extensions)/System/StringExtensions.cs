using System;
using System.Text.RegularExpressions;

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

        #region Manipulation
        /// <summary>
        /// Removes all multiple whitespace characters, and replaces them with only one whitespace character.
        /// </summary>
        /// <param name="string">The string to remove multiple whitespaces from.</param>
        /// <returns>The given string with multiple whitespace between other characters removed, and replaced with only one whitespace character.</returns>
        public static string RemoveMultipleWhitespaces(this string @string) {
            if (@string == null) {
                return @string;
            }

            var cleanedString =
                Regex
                .Replace(@string, @"(\s)\s+", "$1");

            return cleanedString.Trim();
        }

        /// <summary>
        /// Reverses the given string.
        /// </summary>
        /// <param name="string">The string to be reversed.</param>
        /// <returns>The given string, with all it's characters in reversed order.</returns>
        public static string Reverse(this string @string) {
            if (@string == null) {
                return @string;
            }

            var characters = @string.ToCharArray();
            Array.Reverse(characters);

            return new String(characters);
        }
        #endregion

        #region Substring
        /// <summary>
        /// Gets the first x-<paramref name="amount"/> of characters from the given string.
        /// If the given string's length is smaller than the requested <see cref="amount"/> the full string is returned.
        /// If the given <paramref name="amount"/> is negative, an empty string will be returned.
        /// </summary>
        /// <param name="string">The string from which to extract the first x-<paramref name="amount"/> of characters.</param>
        /// <param name="amount">The amount of characters to return.</param>
        /// <returns>The first x-<paramref name="amount"/> of characters from the given string.</returns>
        public static string GetFirst(this string @string, int amount) {
            if (@string == null) {
                return @string;
            }

            if (amount < 0) {
                return String.Empty;
            }

            if (amount >= @string.Length) {
                return @string;
            } else {
                return @string.Substring(0, amount);
            }

        }

        /// <summary>
        /// Gets the last x-<paramref name="amount"/> of characters from the given string.
        /// If the given string's length is smaller than the requested <see cref="amount"/> the full string is returned.
        /// If the given <paramref name="amount"/> is negative, an empty string will be returned.
        /// </summary>
        /// <param name="string">The string from which to extract the last x-<paramref name="amount"/> of characters.</param>
        /// <param name="amount">The amount of characters to return.</param>
        /// <returns>The last x-<paramref name="amount"/> of characters from the given string.</returns>
        public static string GetLast(this string @string, int amount) {
            if (@string == null) {
                return @string;
            }

            if (amount < 0) {
                return String.Empty;
            }

            if (amount >= @string.Length) {
                return @string;
            } else {
                return @string.Substring(@string.Length - amount);
            }
        }

        /// <summary>
        /// A method that wraps Substring() so that it doesn't throw errors when amounts exceed.
        /// </summary>
        /// <param name="string"></param>
        /// <param name="startIndex">The zero-based starting chracter position of a substring in this instance.</param>
        /// <param name="length">The number of characters in the substring.</param>
        /// <returns></returns>
        public static string SubstringSafe(this string @string, int startIndex, int? length = null) {
            if (@string == null) {
                return @string;
            }

            // 01. Normalise input parameters
            if (startIndex < 0) {
                startIndex = 0;
            }

            if (startIndex > @string.Length) {
                startIndex = @string.Length;
            }

            if (length != null && length.Value > @string.Length) {
                length = @string.Length;
            }

            if (length != null && length.Value < 0) {
                length = 0;
            }

            // 02. After normalisation, 
            // -> make sure startindex + length is not greater than string's length
            if (length != null && (length.Value + startIndex) > @string.Length) {
                var overflow = (length.Value + startIndex) - @string.Length;
                length = length - overflow;
                if (length < 0) {
                    length = 0;
                }
            }

            // 03. Return value
            if (length == null) {
                return @string.Substring(startIndex);
            } else {
                return @string.Substring(startIndex, length.Value);
            }
        }
        #endregion
    }
}
