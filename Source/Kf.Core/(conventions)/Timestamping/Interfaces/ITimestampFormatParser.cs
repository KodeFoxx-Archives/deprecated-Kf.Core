using System;

namespace Kf.Core.Conventions.Timestamping.Interfaces
{
    public interface ITimestampFormatParser
    {
        DateTime TryParseToDateTime(string timestamp);
    }
}
