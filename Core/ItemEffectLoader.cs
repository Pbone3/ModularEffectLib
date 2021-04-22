using System.Collections.Generic;
using Terraria;

namespace ModularEffectLib.Core
{
    public class ItemEffectLoader
    {
        #region Events

        #endregion

        public Dictionary<EffectIdentifier, ItemEffect> LoadedEffects;

        public void RegisterEffect(EffectIdentifier id, ItemEffect effect)
        {
            LoadedEffects.Add(id, effect);
        }
    }
}
