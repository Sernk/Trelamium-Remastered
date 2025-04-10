using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Buffs
{
	public class GalaticTorment : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Galatic Torment");
			/* Description.SetDefault("Cosmic energy burns from inside and out"
                + "\nDMG: 20"
                + "\nSpeed: Average"); */
            Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<TrelamiumModPlayer>().galaticTorment = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<TrelamiumModGlobalNPC>().galaticTorment = true;
		}
	}
}
