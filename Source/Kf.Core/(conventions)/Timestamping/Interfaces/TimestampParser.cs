using System;
using Kf.Core.Conventions.Timestamping.DefaultConvention;
using Kf.Core.Conventions.Timestamping.Exceptions;

namespace Kf.Core.Conventions.Timestamping.Interfaces
{
    public abstract class TimestampParser : ITimestampParser
    {
        protected ITimestampFormatDeterminer FormatDeterminer { get; }

        public TimestampParser(ITimestampFormatDeterminer timestampFormatDeterminer) {
            if(timestampFormatDeterminer == null) {
                timestampFormatDeterminer = new DefaultTimestampFormatDeterminer();
            }

            FormatDeterminer = timestampFormatDeterminer;
        }

        public virtual DateTime TryParseDateTime(string timestamp) {
            var timestampFormat = FormatDeterminer.DetermineFormat(timestamp);

            switch (timestampFormat) {
                case TimestampFormat.Short:
                    return CreateDateTimeFromShortTimestamp(timestamp);
                case TimestampFormat.Long:
                    return CreateDateTimeFromLongTimestamp(timestamp);
                case TimestampFormat.Extended:
                    return CreateDateTimeFromExtendedTimestamp(timestamp);
                default:
                    throw new UnknownTimestampFormatException(timestampFormat);
            }
        }

        protected abstract DateTime CreateDateTimeFromShortTimestamp(string timestamp);
        protected abstract DateTime CreateDateTimeFromLongTimestamp(string timestamp);
        protected abstract DateTime CreateDateTimeFromExtendedTimestamp(string timestamp);
    }
}
