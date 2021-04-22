namespace ModularEffectLib.Core
{
    /// <summary>
    /// Unique identifier used for Effects
    /// </summary>
    public struct EffectIdentifier
    {
        /// <summary>
        /// Name of the mod that adds this effect
        /// </summary>
        public string Mod;
        /// <summary>
        /// Name of the item the effect belongs to
        /// </summary>
        public string Item;
        /// <summary>
        /// The effects internal name
        /// </summary>
        public string Name;

        public EffectIdentifier(string mod, string item, string name)
        {
            Mod = mod;
            Item = item;
            Name = name;
        }

        public override string ToString() => $"{Mod}:{Item}:{Name}";
        public override int GetHashCode() => ToString().GetHashCode();
        public override bool Equals(object obj) => obj is EffectIdentifier other && other == this;

        public static bool operator ==(EffectIdentifier leftHand, EffectIdentifier rightHand) =>
            leftHand.Mod == rightHand.Mod &&
            leftHand.Item == rightHand.Item &&
            leftHand.Name == rightHand.Name;

        public static bool operator !=(EffectIdentifier leftHand, EffectIdentifier rightHand) => !(leftHand == rightHand);
    }
}
