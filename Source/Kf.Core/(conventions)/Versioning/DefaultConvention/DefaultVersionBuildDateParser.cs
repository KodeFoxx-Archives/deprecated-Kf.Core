using System;
using Kf.Core.Conventions.Versioning.Interfaces;

namespace Kf.Core.Conventions.Versioning.DefaultConvention
{
    public sealed class DefaultVersionBuildDateParser : IVersionBuildDateParser
    {
        public DateTime TryParseBuildDate(Version version) {
            /*            
                When using [assembly: AssemblyVersion("1.0.*")], this results in:
                => Build Number, third part: Days since 1.1.2000
                => Revision, fourth part: Seconds since midnight divided by two
            */
            var daysToAdd = version.Build;
            var secondsToAdd = version.Revision * 2;
            if (secondsToAdd >= 86400) {
                secondsToAdd -= 1;
            }

            var buildDate =
                new DateTime(2000, 1, 1)
                .Date
                .AddDays(daysToAdd)
                .AddSeconds(secondsToAdd);

            return buildDate;
        }
    }
}
