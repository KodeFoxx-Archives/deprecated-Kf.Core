using System;

namespace Kf.Core.Conventions.Timestamping.Interfaces
{
    public interface ITimestampParser
    {
        DateTime TryParseDateTime(string timestamp);
    }
}
