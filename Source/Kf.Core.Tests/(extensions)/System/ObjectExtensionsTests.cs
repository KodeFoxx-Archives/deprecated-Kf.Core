using System;
using System.Collections.Generic;
using Kf.Core.Range;
using Xunit;

namespace Kf.Core.Tests._extensions_.System
{
    class ObjectExtensionsTests
    {
        #region Debugging
        [Fact]
        public void ToFriendlyNameOfType_Returns_Correct_Value() {
            // Arrange
            var sut = new List<IEnumerable<Tuple<string, object, Tuple<DateTime, List<int>>>>>();
            var expected = "List<IEnumerable<Tuple<String, Object, Tuple<DateTime, List<Int32>>>>>";

            // Act
            var actual = sut.ToFriendlyNameOfType();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToDebugString_Returns_Correct_Value() {
            // Arrange
            var sut = new DateTimeRange(2014, 01, 01, 2015, 01, 01);
            var expected = "[DateTimeRange: Minimum='1/01/2014 0:00:00'; Maximum='1/01/2015 0:00:00']";

            // Act
            var actual = sut.ToDebugString(true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToDebugString_With_IncludeBaseType_Returns_Correct_Value() {
            // Arrange
            var sut = new DateTimeRange(2014, 01, 01, 2015, 01, 01);
            var expected = "[DateTimeRange]";

            // Act
            var actual = sut.ToDebugString();

            // Assert
            Assert.Equal(expected, actual);
        }

        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            private string InternalId { get; set; }

            private IRange<DateTime> Contract { get; set; }

            public Person() {
                FirstName = "John";
                LastName = "Doe";
                InternalId = "JDOE@DOMAIN";
                Contract = new DateTimeRange(2009, 05, 05);
            }
        }

        [Fact]
        public void ToDebugString_With_Complex_Binding_Flags_Returns_Correct_Value() {
            // Arrange
            var sut = new Person();
            var expected = "[Person: Rules='List<IValidationRule<Person>>'; FirstName='John'; LastName='Doe'; InternalId='JDOE@DOMAIN'; Contract='[ImmutableRange<DateTime>: Minimum='5/05/2009 0:00:00'; Maximum='31/12/9999 23:59:59']'; IsValid='True']";

            // Act
            var actual = sut.ToDebugString();

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion
    }
}
