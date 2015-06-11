using System;
using System.Collections.Generic;
using Xunit;

namespace Kf.Core.Tests._extensions_.System
{
    public class TypeExtensionsTests
    {
        [Fact]
        public void ReturnsTypeNameForSimpleType() {
            var expected = "DateTime";
            var sut = typeof(DateTime);
            var actual = sut.ToFriendlyName();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReturnsTypeNameForGenericType() {
            var expected = "List<String>";
            var sut = typeof(List<string>);
            var actual = sut.ToFriendlyName();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReturnsTypeNameForComplexGenericType() {
            var expected = "IDictionary<DateTime, List<String>>";
            var sut = typeof(IDictionary<DateTime, List<string>>);
            var actual = sut.ToFriendlyName();

            Assert.Equal(expected, actual);
        }
    }
}
