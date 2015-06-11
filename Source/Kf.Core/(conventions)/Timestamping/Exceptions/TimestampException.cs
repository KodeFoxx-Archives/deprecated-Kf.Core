using System;
namespace Kf.Core.Conventions.Timestamping.Exceptions
{
    public class TimestampException : Exception
    {
        public TimestampException(string message) : base(message) { }
        public TimestampException(string message, Exception innerException) : base(message, innerException) { }
    }
}
