namespace Kf.Core.Conventions.Timestamping.Interfaces
{
    public abstract class TimestampFormatDeterminer : ITimestampFormatDeterminer
    {
        public abstract TimestampFormat DetermineFormat(string timestamp);        
    }
}
