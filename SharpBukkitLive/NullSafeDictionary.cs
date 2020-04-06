using System;
using System.Collections.Generic;
using System.Text;

namespace SharpBukkitLive
{
    public class NullSafeDictionary<TKey, TValue> : Dictionary<TKey, TValue> where TValue : class
    {
        public new TValue this[TKey key]
        {
            get
            {
                if (!ContainsKey(key))
                    return null;
                else
                    return base[key];
            }
            set
            {
                if (!ContainsKey(key))
                    Add(key, value);
                else
                    base[key] = value;
            }
        }
    }
}
