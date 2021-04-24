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
        public virtual HashSet<EffectIdentifier> InheritEffects { get; }
        public HashSet<EffectIdentifier> MyEffects;
        public HashSet<EffectIdentifier> RealEffects;

        public override bool Autoload(ref string name)
        {
            RegisterItemEffects();
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
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            base.UpdateAccessory(player, hideVisual);

            ModularEffectLib.Loader.UpdateAccessory(RealEffects, player, hideVisual, item);
        }
    }
}
