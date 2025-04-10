using Terraria;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Mounts;

namespace TrelamiumRemastered.Content.Mounts.PreHardmode.Buffs
{
	public class FleshCartBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Boss Cart - Wall of Flesh");
			// Description.SetDefault("Has a nice little cupholder in here.");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(ModContent.MountType<FleshCart>(), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
