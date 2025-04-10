using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Buffs
{
	public class Moonburn : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Moonburn");
			// Description.SetDefault("The moon damages you");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
            BuffID.Sets.LongerExpertDebuff[Type] = true;
        }

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<TrelamiumModPlayer>().moonburn = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<TrelamiumModGlobalNPC>().moonburn = true;
		}
	}
}
