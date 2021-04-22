using ModularEffectLib.Core;
using System;
using System.Linq;
using Terraria.ModLoader;

namespace ModularEffectLib.Items
{
    public abstract class ModularEffectItem : ModItem
    {
        public override bool Autoload(ref string name)
        {
            RegisterItemEffects();
            return base.Autoload(ref name);
        }

        public void RegisterItemEffects()
        {
            Type type = GetType();
            Type[] nestedTypes = type.GetNestedTypes();
            Type[] effects = nestedTypes.Where(t => t.BaseType == typeof(ItemEffect)).ToArray();
            Type query;

            for (int i = 0; i < effects.Length; i++)
            {
                query = effects[i];
                ItemEffect singleton = (ItemEffect)Activator.CreateInstance(query);

                EffectIdentifier id = new EffectIdentifier(mod.Name, Name, query.Name);

                ModularEffectLib.Loader.RegisterEffect(id, singleton);
            }
        }
    }
}
