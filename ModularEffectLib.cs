using ModularEffectLib.Core;
using Terraria.ModLoader;

namespace ModularEffectLib
{
	public class ModularEffectLib : Mod
	{
		public static ModularEffectLib Instance => ModContent.GetInstance<ModularEffectLib>();
		public static ItemEffectLoader Loader => Instance.loader;

        private ItemEffectLoader loader = new ItemEffectLoader();

        public override void Load()
        {
            base.Load();
            LoadingHelper.Load();
        }

        public override void PostSetupContent()
        {
            base.PostSetupContent();
            loader.Load();
            LoadingHelper.Unload(); // Unload it already because I only need it during load

        public override void Unload()
        {
            base.Unload();
            loader = null;
        }
    }
}