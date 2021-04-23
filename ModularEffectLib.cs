using ModularEffectLib.Core;
using Terraria.ModLoader;

namespace ModularEffectLib
{
	public class ModularEffectLib : Mod
	{
		public static ModularEffectLib Instance => ModContent.GetInstance<ModularEffectLib>();
		public static ItemEffectLoader Loader => Instance.loader;

		private ItemEffectLoader loader = new ItemEffectLoader();
	}
}