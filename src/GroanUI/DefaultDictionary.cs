using System.Collections.Generic;

namespace GroanUI
{
    /// <summary>
    /// A standard dictionary but returns the default value supplied at construction
    /// when the indexer property indexes a value not contained in the dictionary
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class DefaultDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public DefaultDictionary(TValue dflt)
        {
            _default = dflt;
        }

        private TValue _default;

        public new TValue this[TKey i]
        {
            get
            {
                if (TryGetValue(i, out var value))
                {
                    return value;
                }

                return _default;
            }
        }
    }
}