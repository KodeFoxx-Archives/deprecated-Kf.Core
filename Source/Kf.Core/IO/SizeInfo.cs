using System;
using System.IO;

namespace Kf.Core.IO
{
    /// <summary>
    /// Represents file size information.
    /// </summary>
    /// <remarks>
    /// CONVERSTION TABLE
    /// -- NAME --------- SYMBOL -------- DECIMAL ----------- #BYTES ---------- EQUALS
    ///    Bit            b               n/a                 0.125             n/a
    ///    Nibble         Nibble          n/a                 0.5               4b
    ///    Byte           B               n/a                 1                 2Nibble
    ///    Kilobyte       KB              10^3                1024              1024B
    ///    Megabyte       MB              10^6                1048576           1024KB
    ///    Gigabyte       GB              10^9                1073741824        1024MB
    ///    Terabyte       TB              10^12               1099511627776     1024GB    
    /// </remarks>
    public class SizeInfo
    {
        #region Constants
        private const long BYTES_IN_KILOBYTE = 1024;
        private const long BYTES_IN_MEGABYTE = 1048576;
        private const long BYTES_IN_GIGABYTE = 1073741824;
        private const long BYTES_IN_TERABYTE = 1099511627776;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the size in Bytes (B).
        /// </summary>
        public long Bytes { get { return (long)_bytes; } }
        private readonly double _bytes;

        /// <summary>
        /// Gets the size in KiloBytes (KB).
        /// </summary>
        public double KiloBytes { get { return _kiloBytes; } }
        private readonly double _kiloBytes;

        /// <summary>
        /// Gets the size in MegaBytes (MB).
        /// </summary>
        public double MegaBytes { get { return _megaBytes; } }
        private readonly double _megaBytes;

        /// <summary>
        /// Gets the size in GigaBytes (GB).
        /// </summary>
        public double GigaBytes { get { return _gigaBytes; } }
        private readonly double _gigaBytes;

        /// <summary>
        /// Gets the size in TeraBytes (TB).
        /// </summary>
        public double TeraBytes { get { return _teraBytes; } }
        private readonly double _teraBytes;
        #endregion

        #region Construction
        /// <summary>
        /// Creates a new <see cref="SizeInfo"/> object.
        /// </summary>
        /// <param name="bytes">The file size in bytes.</param>
        public SizeInfo(long bytes) {
            _bytes = bytes;
            _kiloBytes = _bytes / BYTES_IN_KILOBYTE;
            _megaBytes = _bytes / BYTES_IN_MEGABYTE;
            _gigaBytes = _bytes / BYTES_IN_GIGABYTE;
            _teraBytes = _bytes / BYTES_IN_TERABYTE;
        }

        /// <summary>
        /// Creates a new <see cref="SizeInfo"/> object.
        /// </summary>
        /// <param name="memoryStream">The <see cref="MemoryStream"/> object to get the filesize for.</param>
        /// <exception cref="System.ObjectDisposedException"></exception>
        public SizeInfo(MemoryStream memoryStream)
            : this(memoryStream.Length) {
        }

        /// <summary>
        /// Creates a new <see cref="SizeInfo"/> object.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> object to get the filesize for.</param>
        /// <exception cref="System.ObjectDisposedException"></exception>
        public SizeInfo(Stream stream)
            : this(stream.Length) {
        }

        /// <summary>
        /// Creates a new <see cref="SizeInfo"/> object based on the given <see cref="KiloBytes"/>.
        /// </summary>
        /// <param name="kiloBytes">The size in KB.</param>
        /// <returns>A <see cref="FileSizeInfo"/> object.</returns>
        public static SizeInfo FromKiloBytes(double kiloBytes) {
            return new SizeInfo(Convert.ToInt64(Math.Round(kiloBytes * (double)1024, 0)));
        }

        /// <summary>
        /// Creates a new <see cref="SizeInfo"/> object based on the given <see cref="MegaBytes"/>.
        /// </summary>
        /// <param name="megaBytes">The size in MB.</param>
        /// <returns>A <see cref="FileSizeInfo"/> object.</returns>
        public static SizeInfo FromMegaBytes(double megaBytes) {
            return new SizeInfo(Convert.ToInt64(Math.Round(megaBytes * (double)1024 * (double)1024, 0)));
        }

        /// <summary>
        /// Creates a new <see cref="SizeInfo"/> object based on the given <see cref="GigaBytes"/>.
        /// </summary>
        /// <param name="gigaBytes">The size in GB.</param>
        /// <returns>A <see cref="FileSizeInfo"/> object.</returns>
        public static SizeInfo FromGigaBytes(double gigaBytes) {
            return new SizeInfo(Convert.ToInt64(Math.Round(gigaBytes * (double)1024 * (double)1024 * (double)1024, 0)));
        }

        /// <summary>
        /// Creates a new <see cref="SizeInfo"/> object based on a given <see cref="MemoryStream"/>.
        /// </summary>
        /// <param name="memoryStream">The <see cref="MemoryStream"/> object to get the filesize for.</param>
        /// <exception cref="System.ObjectDisposedException"></exception>
        /// <returns>A <see cref="FileSizeInfo"/> object.</returns>
        public static SizeInfo FromMemoryStream(MemoryStream memoryStream) {
            return new SizeInfo(memoryStream);
        }

        /// <summary>
        /// Creates a new <see cref="SizeInfo"/> object based on a given <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> object to get the filesize for.</param>
        /// <exception cref="System.ObjectDisposedException"></exception>
        /// <returns>A <see cref="FileSizeInfo"/> object.</returns>
        public static SizeInfo FromStream(Stream stream) {
            return new SizeInfo(stream);
        }
        #endregion
    }
}
