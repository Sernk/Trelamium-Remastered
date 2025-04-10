using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Buffs
{
	public class SolarGodsTerror : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Solar God's Terror");
			// Description.SetDefault("You are ded boi");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
            BuffID.Sets.LongerExpertDebuff[Type] = true;
        }

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<TrelamiumModPlayer>().solarGodBuff = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<TrelamiumModGlobalNPC>().solarGodBuff = true;
		}
	}
}
