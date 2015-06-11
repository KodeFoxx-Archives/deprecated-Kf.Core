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
        #endregion
    }
}
