using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Kf.Core.Conventions;

namespace Kf
{
    /// <summary>
    /// Provides extension methods to interact with <see cref="Object"/>s.
    /// </summary>
    public static class ObjectExtensions
    {
        #region Debugging
        /// <summary>
        /// Wrapper method for <see cref="GetType().ToFriendlyName()"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="object">The object to get the type from as a string.</param>
        /// <returns>Returns a string that represents the type of the current object.</returns>        
        public static string ToFriendlyNameOfType<TObject>(this TObject @object) {
            var type = @object.GetType();
            return type.ToFriendlyName();
        }

        /// <summary>
        /// Returns a <see cref="String"/> representation of the given object for debugging purposes.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="object">The object to be represented as a debug string.</param>        
        /// <returns>Returns a <see cref="String"/> representation of the given object for debugging purposes.</returns>
        public static string ToDebugString<TObject>(this TObject @object, bool includeBaseType = false) {
            var objectType = typeof(TObject);
            var objectTypeInfo = objectType.GetTypeInfo();
            var properties = objectTypeInfo.DeclaredProperties.ToList();
            if (includeBaseType && objectTypeInfo.BaseType != null) {
                properties.AddRange(objectTypeInfo.BaseType.GetTypeInfo().DeclaredProperties.ToList());
            }
            var propertyStrings = new List<string>();
            var toFriendlyStringTypes = new List<Type>();

            var debugString = new StringBuilder();
            try {
                debugString.Append($"[{objectType.ToFriendlyName()}");

                foreach (var property in properties) {
                    try {
                        var value = property.GetValue(@object);

                        if (value is ICollection) {
                            value = value.GetType().ToFriendlyName();
                        }

                        propertyStrings.Add($"{property.Name}='{value}'");
                    } catch (Exception ex) {
                        propertyStrings.Add($"{property.Name}='ex!{ex.GetType().ToFriendlyName()}'");
                    }
                }
            } catch (Exception ex) {
                propertyStrings.Add(StringConventions.FMT_EXCEPTION.FormatWith(ex.GetType().ToFriendlyName()));
            }

            if (propertyStrings.Count > 0) {
                debugString.Append(": ");
            }
            debugString.Append(propertyStrings.Flatten("; ", String.Empty, String.Empty));
            debugString.Append("]");

            return debugString.ToString();
        }
        #endregion
    }
}
