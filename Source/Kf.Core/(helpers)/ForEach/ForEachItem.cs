namespace Kf.Core.Helpers.ForEach
{
    public sealed class ForEachItem<TValue, TIndex>
    {
        /// <summary>
        /// Gets the value associated with the index.
        /// </summary>
        public TValue Value { get; }

        /// <summary>
        /// Gets the index assigned to this item of the foreach.
        /// </summary>
        public TIndex Index { get; }

        /// <summary>
        /// Creates a new <see cref="ForEachItem"/>.
        /// </summary>
        /// <param name="value">The value associated with the index.</param>
        /// <param name="index">The index.</param>
        public ForEachItem(TValue value, TIndex index) {
            Value = value;
            Index = index;
        }
    }
}
