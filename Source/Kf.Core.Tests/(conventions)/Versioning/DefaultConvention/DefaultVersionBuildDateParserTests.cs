using System;
using Kf.Core.Conventions.Versioning.DefaultConvention;
using Xunit;

namespace Kf.Core.Tests._conventions_.Versioning.DefaultConvention
{
    public class DefaultVersionBuildDateParserTests
    {
        [Fact]
        public void CanInterpretBuildDateFromVersion() {
            var version = new Version(1, 0, 5639, 24736);
            var sut = new DefaultVersionBuildDateParser();
            var expected = new DateTime(2015, 6, 10).Date;
            var actual = sut.TryParseBuildDate(version).Date;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanInterpretBuildDateAndTimeFromVersion() {
            var version = new Version(1, 0, 5639, 24889);
            var sut = new DefaultVersionBuildDateParser();
            var expected = new DateTime(2015, 6, 10, 13, 49, 38);
            var actual = sut.TryParseBuildDate(version);

            Assert.Equal(expected, actual);
        }
    }
}
