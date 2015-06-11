using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kf
{
    /// <summary>
    /// Provides extension methods to interact with <see cref="IEnumerable"/> of <see cref="String"/> objects.
    /// </summary>
    public static class IEnumerableOfStringExtensions
    {
        #region Flatten
        /// <summary>
        /// Flattens an <see cref="IEnumerable"/> of <see cref="String"/>s with a given seperator.
        /// You can provide optional prefixes and suffixes for each <see cref="String"/> in the <see cref="IEnumerable"/>.
        /// </summary>
        /// <param name="strings">The <see cref="IEnumerable"/> of <see cref="String"/>s to flatten.</param>
        /// <param name="seperator">The seperator used after each <see cref="String"/>.</param>
        /// <param name="prefix">Optional prefix, to be placed before each string. Defaults to an empty string.</param>
        /// <param name="suffix">Optional suffix, to be placed after each string. Not that the suffix will place right after the <see cref="String"/> element, and then the <paramref name="seperator"/> will be placed. Defaults to an empty string.</param>
        /// <returns>A <see cref="String"/> with all the elements from the <see cref="IEnumerable"/>.</returns>
        public static string Flatten(this IEnumerable<string> strings, string seperator, string prefix = "", string suffix = "") {
            // If the collection is null, or if it contains zero elements, then return an empty string.
            if (strings == null || !strings.Any()) {
                return String.Empty;
            }

            // Build the flattened string.
            var flattenedString = new StringBuilder();

            foreach (var @string in strings) {
                flattenedString.Append($"{prefix}{@string}{suffix}{seperator}");
            }
            flattenedString.Remove(flattenedString.Length - seperator.Length, seperator.Length);

            // Return the flattened string
            return flattenedString.ToString();
        }

        /// <summary>
        /// Flattens an <see cref="IEnumerable"/> of <see cref="String"/>s with a given seperator.
        /// You can provide optional prefixes and suffixes for each <see cref="String"/> in the <see cref="IEnumerable"/>.
        /// </summary>
        /// <param name="strings">The <see cref="IEnumerable"/> of <see cref="String"/>s to flatten.</param>
        /// <param name="seperator">The seperator used after each <see cref="String"/>.</param>
        /// <param name="prefix">Optional prefix, to be placed before each string. Defaults to an empty string.</param>
        /// <param name="suffix">Optional suffix, to be placed after each string. Not that the suffix will place right after the <see cref="String"/> element, and then the <paramref name="seperator"/> will be placed. Defaults to an empty string.</param>        
        /// <param name="head">The string to be used at the beginning of the flattened string. Defaults to an empty string.</param>        
        /// <param name="tail">The string to be used at the end of the flattened string. Defaults to an empty string.</param>
        /// <returns>A <see cref="String"/> with all the elements from the <see cref="IEnumerable"/>.</returns>
        public static string Flatten(this IEnumerable<string> strings, string seperator, string prefix = "", string suffix = "", string head = "", string tail = "") {            
            return $"{head}{strings.Flatten(seperator, prefix, suffix)}{tail}";            
        }
        #endregion
    }
}
