namespace Kf.Core.Conventions.Timestamping.Exceptions
{
    public sealed class UnknownTimestampFormatException : TimestampException
    {
        public UnknownTimestampFormatException(TimestampFormat timestampFormat) :
            base($"No format defined with name '{timestampFormat.ToString()}'.") {
        }

        public UnknownTimestampFormatException(string message) :
            base(message) {
        }
    }
}
