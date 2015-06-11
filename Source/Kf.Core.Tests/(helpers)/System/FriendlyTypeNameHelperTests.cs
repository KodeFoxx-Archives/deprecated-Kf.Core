using System;
using System.Collections.Generic;
using Xtl.Shared.Helpers.Types;
using Xunit;

namespace Xtl.Shared.Helpers.Tests.Types
{
    public class FriendlyTypeNameHelperTests
    {
        [Fact]
        public void CtorDefaultCacheTrue() {
            Assert.True(new FriendlyTypeNameHelper().UseFriendlyNameCache);
        }

        [Fact]
        public void CanOverrideCtorDefaultCache() {
            Assert.False(new FriendlyTypeNameHelper(false).UseFriendlyNameCache);
        }

        [Fact]
        public void ReturnsTypeNameForSimpleType() {
            var expected = "DateTime";
            var sut = typeof(DateTime);
            var actual = new FriendlyTypeNameHelper().GetFriendlyName(sut);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReturnsTypeNameForGenericType() {
            var expected = "List<String>";
            var sut = typeof(List<string>);
            var actual = new FriendlyTypeNameHelper().GetFriendlyName(sut);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReturnsTypeNameForComplexGenericType() {
            var expected = "IDictionary<DateTime, List<String>>";
            var sut = typeof(IDictionary<DateTime, List<string>>);
            var actual = new FriendlyTypeNameHelper().GetFriendlyName(sut);

            Assert.Equal(expected, actual);
        }
    }
}