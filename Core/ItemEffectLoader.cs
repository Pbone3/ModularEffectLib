using ModularEffectLib.Items;
using System.Collections.Generic;
using System.Threading;
using Terraria;
using Terraria.ModLoader;

namespace ModularEffectLib.Core
{
    public class ItemEffectLoader
    {
        public Dictionary<EffectIdentifier, ItemEffect> LoadedEffects = new Dictionary<EffectIdentifier, ItemEffect>();
        public Dictionary<int, HashSet<EffectIdentifier>> CachedRealEffects = new Dictionary<int, HashSet<EffectIdentifier>>();

        internal List<ModItem> ItemsToLoad = new List<ModItem>();
        internal Dictionary<int, HashSet<EffectIdentifier>> cachedMyEffects = new Dictionary<int, HashSet<EffectIdentifier>>();

        internal void Load()
        {
            LoadingHelper.SetLoadStage("Registering ItemEffects...");
            string lastModName = "";

            //ItemsToLoad.Add(ModContent.GetModItem(ModContent.ItemType<Terraria.ModLoader.Default.AprilFools>()));

            for (int i = 0; i < ItemsToLoad.Count; i++)
            {
                ModItem item = ItemsToLoad[i];

                if (item.mod.Name != lastModName)
                {
                    lastModName = item.mod.Name;
                    LoadingHelper.SubProgress(lastModName);
                }

                if (item is ModularEffectItem mItem)
                {
                    mItem.RegisterItemEffects();
                }

                LoadingHelper.Progress((float)i / ItemsToLoad.Count);
            }

            ItemsToLoad.Clear();
        }

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

        public void CacheRealEffects(ModItem item, HashSet<EffectIdentifier> effects)
        {
            CachedRealEffects.Add((item.mod.Name, item.Name).GetHashCode(), effects);
        }

        internal void cacheMyEffects(ModItem item, HashSet<EffectIdentifier> effects)
        {
            cachedMyEffects.Add((item.mod.Name, item.Name).GetHashCode(), effects);
        }
    }
}
