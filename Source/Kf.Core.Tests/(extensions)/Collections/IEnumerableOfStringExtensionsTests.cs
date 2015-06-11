using System;
using System.Collections.Generic;
using Xunit;

namespace Kf.Core.Tests._extensions_.Collections
{
    public class IEnumerableOfStringExtensionsTests
    {
        [Fact]
        public void Flatten_Returns_Empty_String_When_Input_Is_Null() {
            // Arrange
            var expected = String.Empty;
            var input = (IEnumerable<string>)null;

            // Act
            var actual = input.Flatten(", ", "(", ")");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Flatten_Returns_Flattened_String_With_Seperator() {
            // Arrange
            var expected = "Monday, Tuesday.";
            var input = new string[] { "Monday", "Tuesday" };

            // Act
            var actual = input.Flatten(", ", "", "", "", ".");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Flatten_Returns_Flattened_String_With_PrefixSuffixHeadTail() {
            // Arrange
            var expected = "<days><day>Monday</day><day>Tuesday</day></days>";
            var input = new string[] { "Monday", "Tuesday" };

            // Act
            var actual = input.Flatten("", "<day>", "</day>", "<days>", "</days>");

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
