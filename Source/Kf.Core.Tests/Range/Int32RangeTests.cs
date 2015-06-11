using System;
using Kf.Core.Range;
using Xunit;

namespace Kf.Core.Tests.Range
{
    public class Int32RangeTests
    {
        [Fact]
        public void IsInRange_Implements_IRange_Interface() {
            // Arrange            
            var range = new Int32Range();
            var expected = typeof(IRange<int>);

            // Act            
            var actual = range.GetType().GetInterface(expected.Name, true);

            // Assert
            Assert.Equal<Type>(expected, actual);
        }

        [Fact]
        public void IsInRange_Ctor_Captures_Correct_Values() {
            // Arrange
            var minimum = Int32.MinValue;
            var maximum = Int32.MaxValue;

            // Act
            var actual = new Int32Range();

            // Assert
            Assert.Equal<int>(minimum, actual.Minimum);
            Assert.Equal<int>(maximum, actual.Maximum);
        }

        [Fact]
        public void IsInRange_With_Value_In_Range_Returns_True() {
            // Arrange
            var expected = true;
            IRange<int> range = new Int32Range(0, 100);

            // Act
            var actual = range.IsInRange(10);

            // Assert
            Assert.Equal<bool>(expected, actual);
        }

        [Fact]
        public void IsInRange_With_Value_In_Range_On_Edge_With_Minimum_Excluded_Returns_True() {
            // Arrange
            var expected = true;
            IRange<int> range = new Int32Range(0, 100);

            // Act
            var actual = range.IsInRange(1, isMinimumIncluded: false);

            // Assert
            Assert.Equal<bool>(expected, actual);
        }

        [Fact]
        public void IsInRange_With_Value_In_Range_On_Edge_With_Maximum_Excluded_Returns_True() {
            // Arrange
            var expected = true;
            IRange<int> range = new Int32Range(0, 100);

            // Act
            var actual = range.IsInRange(99, isMaximumIncluded: false);

            // Assert
            Assert.Equal<bool>(expected, actual);
        }

        [Fact]
        public void IsInRange_With_Value_In_Range_On_Edge_Returns_True() {
            // Arrange
            var expected = true;
            IRange<int> range = new Int32Range(0, 100);

            // Act
            var actual = range.IsInRange(0);

            // Assert
            Assert.Equal<bool>(expected, actual);
        }

        [Fact]
        public void IsInRange_With_Value_Not_In_Range_Returns_False() {
            // Arrange
            var expected = false;
            IRange<int> range = new Int32Range(0, 100);

            // Act
            var actual = range.IsInRange(-5);

            // Assert
            Assert.Equal<bool>(expected, actual);
        }

        [Fact]
        public void IsInRange_With_Value_Not_In_Range_On_Edge_With_Minimum_Excluded_Returns_False() {
            // Arrange
            var expected = false;
            IRange<int> range = new Int32Range(0, 100);

            // Act
            var actual = range.IsInRange(0, isMinimumIncluded: false);

            // Assert
            Assert.Equal<bool>(expected, actual);
        }

        [Fact]
        public void IsInRange_With_Value_Not_In_Range_On_Edge_With_Maximum_Excluded_Returns_False() {
            // Arrange
            var expected = false;
            IRange<int> range = new Int32Range(0, 100);

            // Act
            var actual = range.IsInRange(100, isMaximumIncluded: false);

            // Assert
            Assert.Equal<bool>(expected, actual);
        }

        [Fact]
        public void IsInRange_With_Value_Not_In_Range_On_Edge_Returns_False() {
            // Arrange
            var expected = false;
            IRange<int> range = new Int32Range(0, 100);

            // Act
            var actual = range.IsInRange(-1);

            // Assert
            Assert.Equal<bool>(expected, actual);
        }
    }
}
