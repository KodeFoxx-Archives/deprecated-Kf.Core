using System;
using Kf.Core.Conventions.Timestamping;
using Kf.Core.Conventions.Timestamping.DefaultConvention;
using Kf.Core.Conventions.Timestamping.Exceptions;
using Xunit;

namespace Kf.Core.Tests._conventions_.Timestamping.DefaultConvention
{
    public class DefaultTimestampFormatterTests
    {
        private DateTime _testDateTimeObject = new DateTime(1985, 10, 11, 8, 7, 35, 85);

        [Fact]
        public void CanCreateShortTimeStamp() {
            var sut = new DefaultTimestampFormatter();
            var expected = "19851011";
            var actual = sut.CreateTimestamp(_testDateTimeObject, TimestampFormat.Short);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanCreateLongTimeStamp() {
            var sut = new DefaultTimestampFormatter();
            var expected = "19851011.080735";
            var actual = sut.CreateTimestamp(_testDateTimeObject, TimestampFormat.Long);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanCreateExtendedTimeStamp() {
            var sut = new DefaultTimestampFormatter();
            var expected = "19851011.080735.085";
            var actual = sut.CreateTimestamp(_testDateTimeObject, TimestampFormat.Extended);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThrowsUnknownTimestampFormatException() {
            Assert.Throws<UnknownTimestampFormatException>(() => {
                var sut = new DefaultTimestampFormatter();
                var actual = sut.CreateTimestamp(_testDateTimeObject, (TimestampFormat)(-1));
            });
        }
    }
}
