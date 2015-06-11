using System.Collections.Generic;

namespace Kf.Core.Helpers.ForEach
{
    /// <summary>
    /// Helper class for the "foreach" construct.
    /// </summary>
    public class ForEachHelper
    {
        public static IEnumerable<ForEachItem<TValue, int>> Index<TValue>(IEnumerable<TValue> enumerable) {
            var index = 0;

            foreach (var value in enumerable) {
                yield return new ForEachItem<TValue, int>(value, index++);
            }
        }
    }
}
