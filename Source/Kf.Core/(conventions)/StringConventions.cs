namespace Kf.Core.Conventions
{
    /// <summary>
    /// Holds common used strings.
    /// </summary>
    public static class StringConventions
    {
        /// <summary>
        /// Represents a null value.
        /// Value: (*null)
        /// </summary>
        public static readonly string FMT_NULL = "(*null)";

        /// <summary>
        /// Represents an exception value.
        /// Acceps a one argument formatting parameter.
        /// Value: (*ex!{0})
        /// </summary>
        public static readonly string FMT_EXCEPTION = "(*ex!{0})";
    }
}
