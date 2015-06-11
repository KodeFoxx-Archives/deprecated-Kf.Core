using System.IO;
using Kf.Core.IO;

namespace Kf
{
    /// <summary>
    /// Holds extension methods for use with <see cref="MemoryStream"/> objects.
    /// </summary>
    public static class MemoryStreamExtensions
    {
        /// <summary>
        /// Gets the size as a <see cref="SizeInfo"/>.
        /// </summary>
        /// <param name="memoryStream">The <see cref="MemoryStream"/> object to get the size for.</param>
        /// <returns>A <see cref="SizeInfo"/> object representing the <see cref="MemoryStream"/>'s size.</returns>
        public static SizeInfo GetSizeInfo(this MemoryStream memoryStream) {
            return SizeInfo.FromMemoryStream(memoryStream);
        }
    }
}
