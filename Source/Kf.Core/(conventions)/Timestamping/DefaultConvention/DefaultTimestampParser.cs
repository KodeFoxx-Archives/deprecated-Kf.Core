using System;
using Kf.Core.Conventions.Timestamping.Interfaces;

namespace Kf.Core.Conventions.Timestamping.DefaultConvention
{
    public sealed class DefaultTimestampParser : TimestampParser
    {
        public DefaultTimestampParser() 
            : base(new DefaultTimestampFormatDeterminer()) { }

        protected override DateTime CreateDateTimeFromExtendedTimestamp(string timestamp) {
            var splitted = timestamp.Split('.');
            var datePart = splitted[0];
            var timePart = splitted[1];
            var millisecondPart = splitted[2];

            var dateTime = CreateDateTimeFromLongTimestamp(String.Concat(datePart, ".", timePart));
            var milliseconds = Int32.Parse(millisecondPart);

            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, milliseconds);
        }

        protected override DateTime CreateDateTimeFromLongTimestamp(string timestamp) {
            var splitted = timestamp.Split('.');
            var datePart = splitted[0];
            var timePart = splitted[1];

            var date = CreateDateTimeFromShortTimestamp(datePart);
            var hours = Int32.Parse(timePart.Substring(0, 2));
            var minutes = Int32.Parse(timePart.Substring(2, 2));
            var seconds = Int32.Parse(timePart.Substring(4, 2));

            return new DateTime(date.Year, date.Month, date.Day, hours, minutes, seconds);
        }

        protected override DateTime CreateDateTimeFromShortTimestamp(string timestamp) {
            var year = Int32.Parse(timestamp.Substring(0, 4));
            var month = Int32.Parse(timestamp.Substring(4, 2));
            var day = Int32.Parse(timestamp.Substring(6, 2));

            return new DateTime(year, month, day).Date;
        }
    }
}
