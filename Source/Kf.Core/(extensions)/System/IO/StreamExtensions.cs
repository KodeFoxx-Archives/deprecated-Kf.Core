using System.IO;
using Kf.Core.IO;

namespace Kf
{
    /// <summary>
    /// Holds extension methods for use with <see cref="Stream"/> objects.
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        /// Gets the size as a <see cref="SizeInfo"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> object to get the size for.</param>
        /// <returns>A <see cref="SizeInfo"/> object representing the <see cref="Stream"/>'s size.</returns>
        public static SizeInfo GetSizeInfo(this Stream stream) {
            return SizeInfo.FromStream(stream);
        }
    }
}
