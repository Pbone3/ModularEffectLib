using ModularEffectLib.Core;
using Terraria.ModLoader;

namespace ModularEffectLib
{
	public class ModularEffectLib : Mod
	{
		public static ModularEffectLib Instance => ModContent.GetInstance<ModularEffectLib>();
		public static ItemEffectLoader Loader => Instance.loader;
		public ItemEffectLoader loader = new ItemEffectLoader();
	}
}