using System;

namespace Kf.Core.Conventions.Timestamping.Interfaces
{
    public interface ITimestampFormatter
    {
        string CreateShortTimestamp(DateTime dateTime);
        string CreateLongTimestamp(DateTime dateTime);
        string CreateExtendedTimestamp(DateTime dateTime);
        string CreateTimestamp(DateTime dateTime, TimestampFormat timestampFormat);
    }
}
