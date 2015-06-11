using System;
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

        /// <summary>
        /// Construct to do a manipulation on each item in an enumerable and continue working on it afterwards.
        /// </summary>
        /// <typeparam name="TIn">The type of items in the enumerable</typeparam>
        /// <typeparam name="TOut">The type of items the algorithm needs to return</typeparam>
        /// <param name="enumerable">The enumerable to apply the foreach to.</param>
        /// <param name="algorithm">The algorithm to execute on each item in the enumerable</param>
        /// <returns>The <see cref="IEnumerable{TOut}"/> with the manipulations done.</returns>
        public static IEnumerable<TOut> ForEach<TIn, TOut>(this IEnumerable<TIn> enumerable, Func<TIn,TOut> algorithm) {
            foreach (var item in enumerable) {
                yield return algorithm(item);
            }
        }
    }
}
