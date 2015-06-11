using System;
using Kf.Core.Conventions.Timestamping.DefaultConvention;
using Xunit;

namespace Kf.Core.Tests._conventions_.Timestamping.DefaultConvention
{
    public class DefaultTimestampParserTests
    {
        [Fact]
        public void CanParseShortTimestamp() {
            var sut = new DefaultTimestampParser();
            var shortTimestamp = "19851011";
            var expected = new DateTime(1985, 10, 11);
            var actual = sut.TryParseToDateTime(shortTimestamp);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanParseLongTimestamp() {
            var sut = new DefaultTimestampParser();
            var longTimestamp = "19851011.151559";
            var expected = new DateTime(1985, 10, 11, 15, 15, 59);
            var actual = sut.TryParseToDateTime(longTimestamp);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanParseExtendedTimestamp() {
            var sut = new DefaultTimestampParser();
            var extendedTimestamp = "19851011.151617.002";
            var expected = new DateTime(1985, 10, 11, 15, 16, 17, 2);
            var actual = sut.TryParseToDateTime(extendedTimestamp);

            Assert.Equal(expected, actual);
        }
    }
}
