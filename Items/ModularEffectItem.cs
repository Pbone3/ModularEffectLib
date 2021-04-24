using ModularEffectLib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace ModularEffectLib.Items
{
    public abstract class ModularEffectItem : ModItem
    {
        /// <summary>
        /// Additional effects for this item to use
        /// </summary>
        public virtual HashSet<EffectIdentifier> InheritEffects { get; }
        /// <summary>
        /// A HashSet of the effects belonging to the item during load. Does not exist after load
        /// </summary>
        private HashSet<EffectIdentifier> MyEffects = new HashSet<EffectIdentifier>();
        /// <summary>
        /// Combination of the inherited effects and owned effects. Exists after load
        /// </summary>
        public HashSet<EffectIdentifier> RealEffects = new HashSet<EffectIdentifier>();

        public override bool Autoload(ref string name)
        {
            ModularEffectLib.Loader.ItemsToLoad.Add(this);
            return base.Autoload(ref name);
        }

        public void RegisterItemEffects()
        {
            Type type = GetType();
            Type[] nestedTypes = type.GetNestedTypes();
            Type[] effects = nestedTypes.Where(t => typeof(ItemEffect).IsAssignableFrom(t)).ToArray();
            Type query;

            for (int i = 0; i < effects.Length; i++)
            {
                query = effects[i];
                ItemEffect singleton = (ItemEffect)Activator.CreateInstance(query);
                EffectIdentifier id = new EffectIdentifier(mod.Name, Name, query.Name);

                ModularEffectLib.Loader.RegisterEffect(id, singleton);
                MyEffects.Add(id);
                RealEffects.Add(id);
            }

            RealEffects.UnionWith(InheritEffects);
            ModularEffectLib.Loader.CacheRealEffects(this, RealEffects);
            ModularEffectLib.Loader.cacheMyEffects(this, MyEffects);
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            RealEffects = ModularEffectLib.Loader.CachedRealEffects[(mod.Name, Name).GetHashCode()];
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            base.UpdateAccessory(player, hideVisual);

            ModularEffectLib.Loader.UpdateAccessory(RealEffects, player, hideVisual, item);
        }

        public HashSet<EffectIdentifier> GetEffects(params ModItem[] items) => default;
    }
}
