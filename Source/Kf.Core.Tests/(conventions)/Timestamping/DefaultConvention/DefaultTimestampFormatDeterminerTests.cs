using Kf.Core.Conventions.Timestamping;
using Kf.Core.Conventions.Timestamping.DefaultConvention;
using Kf.Core.Conventions.Timestamping.Exceptions;
using Xunit;

namespace Kf.Core.Tests._conventions_.Timestamping.DefaultConvention
{
    public class DefaultTimestampFormatDeterminerTests
    {
        [Fact]
        public void CanDetermineShortTimestamp() {
            var sut = new DefaultTimestampFormatDeterminer();
            var shortTimestamp = "19851011";
            var expected = TimestampFormat.Short;
            var actual = sut.DetermineFormat(shortTimestamp);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanDetermineLongTimestamp() {
            var sut = new DefaultTimestampFormatDeterminer();
            var longTimestamp = "19851011.230608";
            var expected = TimestampFormat.Long;
            var actual = sut.DetermineFormat(longTimestamp);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanDetermineExtendedTimestamp() {
            var sut = new DefaultTimestampFormatDeterminer();
            var extendedTimestamp = "19851011.151559.057";
            var expected = TimestampFormat.Extended;
            var actual = sut.DetermineFormat(extendedTimestamp);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThrowsUnknownTimestampFormatExceptionOnUnknownFormat() {
            Assert.Throws<UnknownTimestampFormatException>(() => {
                var sut = new DefaultTimestampFormatDeterminer();
                var actual = sut.DetermineFormat("");
            });
        }
    }
}
