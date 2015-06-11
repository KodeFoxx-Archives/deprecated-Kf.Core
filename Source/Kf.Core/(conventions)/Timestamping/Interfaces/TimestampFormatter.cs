using System;
using Kf.Core.Conventions.Timestamping.Exceptions;

namespace Kf.Core.Conventions.Timestamping.Interfaces
{
    public abstract class TimestampFormatter : ITimestampFormatter
    {
        public abstract string CreateExtendedTimestamp(DateTime dateTime);
        public abstract string CreateLongTimestamp(DateTime dateTime);
        public abstract string CreateShortTimestamp(DateTime dateTime);

        public string CreateTimestamp(DateTime dateTime, TimestampFormat timestampFormat) {
            switch (timestampFormat) {
                case TimestampFormat.Short:
                    return CreateShortTimestamp(dateTime);
                case TimestampFormat.Long:
                    return CreateLongTimestamp(dateTime);
                case TimestampFormat.Extended:
                    return CreateExtendedTimestamp(dateTime);
                default:
                    throw new UnknownTimestampFormatException(timestampFormat);
            }
        }
    }
}
