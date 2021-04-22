using System;
using System.Collections;
using System.Collections.Generic;

namespace ModularEffectLib.Core
{
    public class ItemEffectCollection : IEnumerable<ItemEffect>
    {
        public ItemEffect this[EffectIdentifier id]
        {
            get {
                if (!inner.TryGetValue(id, out ItemEffect effect))
                    throw new Exception("ItemEffectCollection does not contain " + id.ToString());

                return effect;
            }
        }
        private Dictionary<EffectIdentifier, ItemEffect> inner;

        public IEnumerator<ItemEffect> GetEnumerator() => inner.Values.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => inner.GetEnumerator();
    }
}
