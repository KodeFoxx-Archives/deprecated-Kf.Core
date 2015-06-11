namespace Kf.Core.Conventions.Timestamping.Interfaces
{
    public interface ITimestampFormatDeterminer
    {        
        TimestampFormat DetermineFormat(string timestamp);
    }
}
