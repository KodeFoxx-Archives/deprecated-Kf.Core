using Kf.Core.IO;
using Xunit;

namespace Kf.Core.Tests.IO
{
    public class SizeInfoTests
    {
        static long _bytes = 6316621824; // 6024MB
        static SizeInfo _sut = new SizeInfo(_bytes);

        [Fact]
        public void Can_Convert_To_KiloBytes() {
            // Arrange
            var expected = 6168576;

            // Act            
            // Assert
            Assert.Equal(expected, _sut.KiloBytes);
        }

        [Fact]
        public void Can_Convert_To_MegaBytes() {
            // Arrange
            var expected = 6024d;

            // Act            
            // Assert
            Assert.Equal(expected, _sut.MegaBytes);
        }

        [Fact]
        public void Can_Convert_To_GigaBytes() {
            // Arrange
            var expected = 5.8828125d;

            // Act            
            // Assert
            Assert.Equal(expected, _sut.GigaBytes);
        }

        [Fact]
        public void Can_Convert_To_TeraBytes() {
            // Arrange
            var expected = 0.00574493408203125d;

            // Act            
            // Assert
            Assert.Equal(expected, _sut.TeraBytes);
        }

        [Fact]
        public void Can_Create_From_GigaBytes() {
            // Arrange
            var expected = 27165668147;
            var gigaBytes = 25.30d;

            // Act
            var sut = SizeInfo.FromGigaBytes(gigaBytes);

            // Assert
            Assert.Equal(expected, sut.Bytes);
        }

        [Fact]
        public void Can_Create_From_MegaBytes() {
            // Arrange
            var expected = 26528973;
            var megaBytes = 25.30d;

            // Act
            var sut = SizeInfo.FromMegaBytes(megaBytes);

            // Assert
            Assert.Equal(expected, sut.Bytes);
        }

        [Fact]
        public void Can_Create_From_KiloBytes() {
            // Arrange
            var expected = 26528973;
            var kiloBytes = 25907.2d;

            // Act
            var sut = SizeInfo.FromKiloBytes(kiloBytes);

            // Assert
            Assert.Equal(expected, sut.Bytes);
        }
    }
}
