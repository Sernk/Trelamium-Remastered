using Terraria;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.NPCs;
using TrelamiumRemastered;

namespace TrelamiumRemastered.Content.Buffs
{
	public class PermafrostBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Permafrost");
   //         Description.SetDefault("Permafrost freezes from the inside and out"
   //             + "\nDMG: 1"
   //             + "\nSpeed: Rapid");
			//Main.debuff[Type] = true;
			//Main.pvpBuff[Type] = true;
			//Main.buffNoSave[Type] = true;
			//longerExpertDebuff = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<TrelamiumModPlayer>().permafrostDebuff = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<TrelamiumModGlobalNPC>().permafrostDebuff = true;
		}
	}
}
