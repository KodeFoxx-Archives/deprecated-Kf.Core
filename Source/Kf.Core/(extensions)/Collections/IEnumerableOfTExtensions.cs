using System.Collections.Generic;
using Kf.Core.Helpers.ForEach;

namespace Kf
{
    public static class IEnumerableOfTExtensions
    {
        /// <summary>
        /// Creates a enumerable to cycle through indexes while using a foreach loop.
        /// Shortcut to <see cref="ForEachWrapper"/>'s "Index" method for collections.
        /// </summary>
        /// <param name="enumerable">The enumerable to apply the "foreach" wrapping to.</param>
        /// <returns>IEnumerable<ForEachWrapper<TValue, int>></returns>
        public static IEnumerable<ForEachItem<TValue, int>> Index<TValue>(this IEnumerable<TValue> enumerable) {
            return ForEachHelper.Index<TValue>(enumerable);
        }
    }
}
