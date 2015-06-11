using System;

namespace Kf.Core.Conventions.Versioning.Interfaces
{
    public interface IVersionBuildDateParser
    {
        DateTime TryParseBuildDate(Version version);
    }
}
