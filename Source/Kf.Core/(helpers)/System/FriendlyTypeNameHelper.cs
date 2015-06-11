using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Xtl.Shared.Helpers.Types
{
    public class FriendlyTypeNameHelper
    {
        private static readonly Lazy<IDictionary<int, string>> _friendlyNameCacheSingleton = new Lazy<IDictionary<int, string>>(() => {
            return new ConcurrentDictionary<int, string>();
        }, isThreadSafe: true);

        protected IDictionary<int, string> FriendlyNameCache { get { return _friendlyNameCacheSingleton.Value; } }

        /// <summary>
        /// Determines whether the cache is being used or not.
        /// </summary>
        public bool UseFriendlyNameCache { get; }

        /// <summary>
        /// Creates a new <see cref="TypeHelper"/>.
        /// </summary>
        /// <param name="useFriendlyNameCache">Determines whether to use the caching or not. Default is true.</param>
        public FriendlyTypeNameHelper(bool useFriendlyNameCache = true) {
            UseFriendlyNameCache = useFriendlyNameCache;
        }

        /// <summary>
        /// Generates a type for the key.
        /// </summary>
        /// <param name="type">The type to generate a key for.</param>        
        protected virtual int GenerateTypeKey(Type type) {
            return type.GetHashCode();
        }

        /// <summary>
        /// Gets (generates) a friendly name for the given type.
        /// </summary>
        /// <param name="type">The type to get a friendly name for.</param>        
        public string GetFriendlyName(Type type) {
            var typeInfo = type.GetTypeInfo();

            if (!typeInfo.IsGenericType) {
                return type.Name;
            }

            if (!UseFriendlyNameCache) {
                return BuildFriendlyName(typeInfo);
            } else {
                var key = GenerateTypeKey(type);
                if (!FriendlyNameCache.ContainsKey(key)) {
                    FriendlyNameCache[key] = BuildFriendlyName(typeInfo);
                }

                return FriendlyNameCache[key];
            }
        }

        protected string BuildFriendlyName(Type type) {
            var typeInfo = type.GetTypeInfo();
            return BuildFriendlyName(typeInfo);
        }
        protected virtual string BuildFriendlyName(TypeInfo typeInfo) {
            if (!typeInfo.IsGenericType) {
                return typeInfo.Name;
            }

            var friendlyName = new StringBuilder();

            if (typeInfo.Name.IndexOf('`') > 0) {
                friendlyName.Append(typeInfo.Name.Remove(typeInfo.Name.IndexOf('`')));
            } else {
                friendlyName.Append(typeInfo.Name);
            }

            var genericTypeArguments = String.Join<string>(", ", typeInfo.GenericTypeArguments.Select(t => GetFriendlyName(t)));
            friendlyName.Append($"<{genericTypeArguments}>");

            return friendlyName.ToString();
        }
    }
}