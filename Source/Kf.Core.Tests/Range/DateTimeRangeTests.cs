using System;
using Kf.Core.Range;
using Xunit;

namespace Kf.Core.Tests.Range
{
    public class DateTimeRangeTests
    {
        [Fact]
        public void IsInRange_Implements_IRange_Interface() {
            // Arrange            
            var range = new DateTimeRange();
            var expected = typeof(IRange<DateTime>);

            // Act            
            var actual = range.GetType().GetInterface(expected.Name, true);

            // Assert
            Assert.Equal<Type>(expected, actual);
        }

        [Fact]
        public void IsInRange_Ctor_Captures_Correct_Values() {
            // Arrange
            var minimum = DateTime.MinValue;
            var maximum = DateTime.MaxValue;

            // Act
            var actual = new DateTimeRange();

            // Assert
            Assert.Equal<DateTime>(minimum, actual.Minimum);
            Assert.Equal<DateTime>(maximum, actual.Maximum);
        }

        [Fact]
        public void IsInRange_With_Value_In_Range_Returns_True() {
            // Arrange
            var expected = true;
            IRange<DateTime> range = new DateTimeRange(new DateTime(1985, 10, 11), new DateTime(1986, 10, 11));

            // Act
            var actual = range.IsInRange(new DateTime(1986, 10, 1));

            // Assert
            Assert.Equal<bool>(expected, actual);
        }

        [Fact]
        public void IsInRange_With_Value_In_Range_On_Edge_With_Minimum_Excluded_Returns_True() {
            // Arrange
            var expected = true;
            IRange<DateTime> range = new DateTimeRange(new DateTime(1985, 10, 11), new DateTime(1986, 10, 11));

            // Act
            var actual = range.IsInRange(new DateTime(1985, 10, 12), isMinimumIncluded: false);

            // Assert
            Assert.Equal<bool>(expected, actual);
        }

        [Fact]
        public void IsInRange_With_Value_In_Range_On_Edge_With_Maximum_Excluded_Returns_True() {
            // Arrange
            var expected = true;
            IRange<DateTime> range = new DateTimeRange(new DateTime(1985, 10, 11), new DateTime(1986, 10, 11));

            // Act
            var actual = range.IsInRange(new DateTime(1986, 10, 10), isMaximumIncluded: false);

            // Assert
            Assert.Equal<bool>(expected, actual);
        }

        [Fact]
        public void IsInRange_With_Value_In_Range_On_Edge_Returns_True() {
            // Arrange
            var expected = true;
            IRange<DateTime> range = new DateTimeRange(new DateTime(1985, 10, 11), new DateTime(1986, 10, 11));

            // Act
            var actual = range.IsInRange(new DateTime(1985, 10, 11));

            // Assert
            Assert.Equal<bool>(expected, actual);
        }

        [Fact]
        public void IsInRange_With_Value_Not_In_Range_Returns_False() {
            // Arrange
            var expected = false;
            IRange<DateTime> range = new DateTimeRange(new DateTime(1985, 10, 11), new DateTime(1986, 10, 11));

            // Act
            var actual = range.IsInRange(new DateTime(1986, 11, 11));

            // Assert
            Assert.Equal<bool>(expected, actual);
        }

        [Fact]
        public void IsInRange_With_Value_Not_In_Range_On_Edge_With_Minimum_Excluded_Returns_False() {
            // Arrange
            var expected = false;
            IRange<DateTime> range = new DateTimeRange(new DateTime(1985, 10, 11), new DateTime(1986, 10, 11));

            // Act
            var actual = range.IsInRange(new DateTime(1985, 10, 11), isMinimumIncluded: false);

            // Assert
            Assert.Equal<bool>(expected, actual);
        }

        [Fact]
        public void IsInRange_With_Value_Not_In_Range_On_Edge_With_Maximum_Excluded_Returns_False() {
            // Arrange
            var expected = false;
            IRange<DateTime> range = new DateTimeRange(new DateTime(1985, 10, 11), new DateTime(1986, 10, 11));

            // Act
            var actual = range.IsInRange(new DateTime(1986, 10, 11), isMaximumIncluded: false);

            // Assert
            Assert.Equal<bool>(expected, actual);
        }

        [Fact]
        public void IsInRange_With_Value_Not_In_Range_On_Edge_Returns_False() {
            // Arrange
            var expected = false;
            IRange<DateTime> range = new DateTimeRange(new DateTime(1985, 10, 11), new DateTime(1986, 10, 11));

            // Act
            var actual = range.IsInRange(new DateTime(1985, 10, 9));

            // Assert
            Assert.Equal<bool>(expected, actual);
        }
    }
}
