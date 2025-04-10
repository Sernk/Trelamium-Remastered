using Terraria;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Mounts;

namespace TrelamiumRemastered.Content.Mounts.PreHardmode.Buffs
{
	public class KingSlimeCartBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Boss Cart - King Slime");
			// Description.SetDefault("Has a nice little cupholder in here.");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(ModContent.MountType<KingSlimeCart>(), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
