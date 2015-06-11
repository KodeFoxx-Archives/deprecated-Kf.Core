using System;
using Kf.Core.Range;
using Xunit;

namespace Kf.Core.Tests.Range
{
    public class TimeSpanRangeTests
    {
        [Fact]
        public void IsInRange_Implements_IRange_Interface() {
            // Arrange            
            var range = new TimeSpanRange();
            var expected = typeof(IRange<TimeSpan>);

            // Act            
            var actual = range.GetType().GetInterface(expected.Name, true);

            // Assert
            Assert.Equal<Type>(expected, actual);
        }

        [Fact]
        public void IsInRange_Ctor_Captures_Correct_Values() {
            // Arrange
            var minimum = TimeSpan.MinValue;
            var maximum = TimeSpan.MaxValue;

            // Act
            var actual = new TimeSpanRange();

            // Assert
            Assert.Equal<TimeSpan>(minimum, actual.Minimum);
            Assert.Equal<TimeSpan>(maximum, actual.Maximum);
        }

        [Fact]
        public void IsInRange_With_Value_In_Range_Returns_True() {
            // Arrange
            var expected = true;
            IRange<TimeSpan> range = new TimeSpanRange(TimeSpan.FromDays(5), TimeSpan.FromDays(28));

            // Act
            var actual = range.IsInRange(TimeSpan.FromDays(10));

            // Assert
            Assert.Equal<bool>(expected, actual);
        }

        [Fact]
        public void IsInRange_With_Value_In_Range_On_Edge_With_Minimum_Excluded_Returns_True() {
            // Arrange
            var expected = true;
            IRange<TimeSpan> range = new TimeSpanRange(TimeSpan.FromDays(5), TimeSpan.FromDays(28));

            // Act
            var actual = range.IsInRange(TimeSpan.FromDays(6), isMinimumIncluded: false);

            // Assert
            Assert.Equal<bool>(expected, actual);
        }

        [Fact]
        public void IsInRange_With_Value_In_Range_On_Edge_With_Maximum_Excluded_Returns_True() {
            // Arrange
            var expected = true;
            IRange<TimeSpan> range = new TimeSpanRange(TimeSpan.FromDays(5), TimeSpan.FromDays(28));

            // Act
            var actual = range.IsInRange(TimeSpan.FromDays(27), isMaximumIncluded: false);

            // Assert
            Assert.Equal<bool>(expected, actual);
        }

        [Fact]
        public void IsInRange_With_Value_In_Range_On_Edge_Returns_True() {
            // Arrange
            var expected = true;
            IRange<TimeSpan> range = new TimeSpanRange(TimeSpan.FromDays(5), TimeSpan.FromDays(28));

            // Act
            var actual = range.IsInRange(TimeSpan.FromDays(28));

            // Assert
            Assert.Equal<bool>(expected, actual);
        }

        [Fact]
        public void IsInRange_With_Value_Not_In_Range_On_Edge_Returns_True() {
            // Arrange
            var expected = false;
            IRange<TimeSpan> range = new TimeSpanRange(TimeSpan.FromDays(5), TimeSpan.FromDays(28));

            // Act
            var actual = range.IsInRange(TimeSpan.FromDays(28).Add(TimeSpan.FromMilliseconds(1)));

            // Assert
            Assert.Equal<bool>(expected, actual);
        }

        [Fact]
        public void IsInRange_With_Value_Not_In_Range_Returns_False() {
            // Arrange
            var expected = false;
            IRange<TimeSpan> range = new TimeSpanRange(TimeSpan.FromDays(5), TimeSpan.FromDays(28));

            // Act
            var actual = range.IsInRange(TimeSpan.FromDays(28).Add(TimeSpan.FromTicks(1)));

            // Assert
            Assert.Equal<bool>(expected, actual);
        }

        [Fact]
        public void IsInRange_With_Value_Not_In_Range_On_Edge_With_Minimum_Excluded_Returns_False() {
            // Arrange
            var expected = false;
            IRange<TimeSpan> range = new TimeSpanRange(TimeSpan.FromDays(5), TimeSpan.FromDays(28));

            // Act
            var actual = range.IsInRange(TimeSpan.FromDays(5), isMinimumIncluded: false);

            // Assert
            Assert.Equal<bool>(expected, actual);
        }

        [Fact]
        public void IsInRange_With_Value_Not_In_Range_On_Edge_With_Maximum_Excluded_Returns_False() {
            // Arrange
            var expected = false;
            IRange<TimeSpan> range = new TimeSpanRange(TimeSpan.FromDays(5), TimeSpan.FromDays(28));

            // Act
            var actual = range.IsInRange(TimeSpan.FromDays(28), isMaximumIncluded: false);

            // Assert
            Assert.Equal<bool>(expected, actual);
        }

        [Fact]
        public void IsInRange_With_Value_Not_In_Range_On_Edge_Returns_False() {
            // Arrange
            var expected = false;
            IRange<TimeSpan> range = new TimeSpanRange(TimeSpan.FromDays(5), TimeSpan.FromDays(28));

            // Act
            var actual = range.IsInRange(TimeSpan.FromSeconds(5));

            // Assert
            Assert.Equal<bool>(expected, actual);
        }
    }
}
