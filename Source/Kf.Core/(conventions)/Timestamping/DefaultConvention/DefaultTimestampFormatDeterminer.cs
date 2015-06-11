using Kf.Core.Conventions.Timestamping.Exceptions;
using Kf.Core.Conventions.Timestamping.Interfaces;

namespace Kf.Core.Conventions.Timestamping.DefaultConvention
{
    public sealed class DefaultTimestampFormatDeterminer : TimestampFormatDeterminer
    {
        public override TimestampFormat DetermineFormat(string timestamp) {
            var length = timestamp.Length;
            switch (length) {
                case 8:
                    return TimestampFormat.Short;
                case 15:
                    return TimestampFormat.Long;
                case 19:
                    return TimestampFormat.Extended;
                default:
                    throw new UnknownTimestampFormatException($"Unable to determine the format of given timestamp '{timestamp}'.");
            }
        }
    }
}
