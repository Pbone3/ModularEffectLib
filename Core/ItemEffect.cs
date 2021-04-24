using Terraria;

namespace ModularEffectLib.Core
{
    public abstract class ItemEffect
    {
        public Toggle Toggle;

        public virtual void UpdateAccessory(Player player, bool hideVisual, Item effectOwner) { }
        public virtual void OnHit(CombatEntity victim, Player attacker, Item effectOwner) { }
        public virtual void OnHitBy(CombatEntity attacker, int damage, Player owner, Item effectOwner) { }
    }
}
