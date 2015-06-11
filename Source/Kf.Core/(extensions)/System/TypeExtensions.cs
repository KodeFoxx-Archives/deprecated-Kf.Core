using System;
using Xtl.Shared.Helpers.Types;

namespace Kf
{
    /// <summary>
    /// Provides extensions methods to interact with <see cref="Type"/> objects.
    /// </summary>
    public static class TypeExtensions
    {
        #region Friendly Name        
        /// <summary>
        /// Returns the friendly name of a <see cref="Type"/>.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to return a friendly name for.</param>
        /// <returns>The friendly name of a <see cref="Type"/>.</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="type"/> is null.</exception>
        public static string ToFriendlyName(this Type type) {
            if (type == null) {
                throw new ArgumentNullException(nameof(type));
            }

            return new FriendlyTypeNameHelper()
                .GetFriendlyName(type);
        }
        #endregion Friendly Name
    }
}
