using System;
using Xunit;

namespace Kf.Core.Tests._extensions_.System
{
    public class DateTimeExtensionsTests
    {
        #region IsDay (Method Family)
        [Fact]
        public void IsDayReturnsTrueWhenDateIsCorrectDay() {
            var sut = new DateTime(1985, 10, 11);
            var expected = DayOfWeek.Friday;
            Assert.True(sut.IsDay(expected));
        }

        [Fact]
        public void IsDayReturnsFalseWhenDateIsCorrectDay() {
            var sut = new DateTime(1985, 10, 11);
            var expected = DayOfWeek.Saturday;
            Assert.False(sut.IsDay(expected));
        }

        [Fact]
        public void IsWeekendReturnsTrueWhenSaturday() {
            var sut = new DateTime(1985, 10, 12);
            Assert.True(sut.IsWeekend());
        }

        [Fact]
        public void IsWeekendReturnsTrueWhenSunday() {
            var sut = new DateTime(1985, 10, 13);            
            Assert.True(sut.IsWeekend());
        }

        [Fact]
        public void IsWeekendReturnsFalseWhenMonday() {
            var sut = new DateTime(1985, 10, 14);
            Assert.False(sut.IsWeekend());
        }

        [Fact]
        public void IsWeekendReturnsFalseWhenTuesday() {
            var sut = new DateTime(1985, 10, 15);
            Assert.False(sut.IsWeekend());
        }

        [Fact]
        public void IsWeekendReturnsFalseWhenWednesday() {
            var sut = new DateTime(1985, 10, 16);
            Assert.False(sut.IsWeekend());
        }

        [Fact]
        public void IsWeekendReturnsFalseWhenThursday() {
            var sut = new DateTime(1985, 10, 17);
            Assert.False(sut.IsWeekend());
        }

        [Fact]
        public void IsWeekendReturnsFalseWhenFriday() {
            var sut = new DateTime(1985, 10, 18);
            Assert.False(sut.IsWeekend());
        }

        [Fact]
        public void IsDayInReturnsTrueWhenDateMatchesGivenDaysOfWeek() {
            var daysToMatch = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Wednesday };
            var sut = new DateTime(1985, 10, 16);
            Assert.True(sut.IsDayIn(daysToMatch));
        }

        [Fact]
        public void IsDayInReturnsFalseWhenDateDoesntMatchGivenDaysOfWeek() {
            var daysToMatch = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Wednesday };
            var sut = new DateTime(1985, 10, 15);
            Assert.False(sut.IsDayIn(daysToMatch));
        }
        #endregion

        #region NextDay (Method Family)
        [Fact]
        public void NextDayReturnsNextDay() {
            var sut = new DateTime(1985, 10, 11, 15, 16, 17);
            var expected = sut.AddDays(1);
            Assert.Equal(expected, sut.NextDay());
        }

        [Fact]
        public void PreviousDayReturnsPreviousDay() {
            var sut = new DateTime(1985, 10, 11, 15, 16, 17);
            var expected = sut.AddDays(-1);
            Assert.Equal(expected, sut.PreviousDay());
        }

        [Fact]
        public void NextDayWithGivenDayOfWeekReturnsNextDay() {
            var sut = new DateTime(1985, 10, 11, 15, 16, 17);
            var expected = new DateTime(1985, 10, 14, 15, 16, 17);
            Assert.Equal(expected, sut.NextDay(DayOfWeek.Monday));
        }

        [Fact]
        public void NextDayWithGivenCurrentDayOfWeekReturnsNextDay() {
            var sut = new DateTime(1985, 10, 11, 15, 16, 17);
            var expected = new DateTime(1985, 10, 18, 15, 16, 17);
            Assert.Equal(expected, sut.NextDay(DayOfWeek.Friday));
        }

        [Fact]
        public void PreviousDayWithGivenDayOfWeekReturnsPreviousDay() {
            var sut = new DateTime(1985, 10, 11, 15, 16, 17);
            var expected = new DateTime(1985, 10, 7, 15, 16, 17);
            Assert.Equal(expected, sut.PreviousDay(DayOfWeek.Monday));
        }

        [Fact]
        public void PreviousDayWithGivenCurrentDayOfWeekReturnsPreviousDay() {
            var sut = new DateTime(1985, 10, 11, 15, 16, 17);
            var expected = new DateTime(1985, 10, 4, 15, 16, 17);
            Assert.Equal(expected, sut.PreviousDay(DayOfWeek.Friday));
        }
        #endregion
    }
}
