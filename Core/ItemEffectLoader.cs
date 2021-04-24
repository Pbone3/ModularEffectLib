using System.Collections.Generic;
using Terraria;

namespace ModularEffectLib.Core
{
    public class ItemEffectLoader
    {
        public Dictionary<EffectIdentifier, ItemEffect> LoadedEffects;

        public void UpdateAccessory(HashSet<EffectIdentifier> effects, Player player, bool hideVisual, Item effectOwner)
        {
            foreach (EffectIdentifier id in effects)
            {
                LoadedEffects[id].UpdateAccessory(player, hideVisual, effectOwner);
            }
        }

        public void RegisterEffect(EffectIdentifier id, ItemEffect effect)
        {
            LoadedEffects.Add(id, effect);
        }
    }
}
