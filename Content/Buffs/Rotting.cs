using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Buffs
{
	public class Rotting : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Rotting");
			// Description.SetDefault("You are slowy rotting away");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
            BuffID.Sets.LongerExpertDebuff[Type] = true;
        }

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<TrelamiumModPlayer>().rottingDebuff = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<TrelamiumModGlobalNPC>().rottingDebuff = true;
		}
	}
}
