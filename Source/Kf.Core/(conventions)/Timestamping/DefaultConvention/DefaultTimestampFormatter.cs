using System;
using Kf.Core.Conventions.Timestamping.Interfaces;

namespace Kf.Core.Conventions.Timestamping.DefaultConvention
{
    public sealed class DefaultTimestampFormatter : TimestampFormatter
    {
        public override string CreateExtendedTimestamp(DateTime dateTime) {
            return String.Concat(CreateLongTimestamp(dateTime), dateTime.ToString(".fff"));
        }

        public override string CreateLongTimestamp(DateTime dateTime) {
            return String.Concat(CreateShortTimestamp(dateTime), dateTime.ToString(".HHmmss"));
        }

        public override string CreateShortTimestamp(DateTime dateTime) {
            return dateTime.ToString("yyyyMMdd");
        }
    }
}
