namespace Kf.Core.Conventions.Timestamping.Interfaces
{
    public interface ITimestampInterpreter
    {        
        TimestampFormat DetermineFormat(string timestamp);
    }
}
