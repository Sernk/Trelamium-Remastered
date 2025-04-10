using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Buffs
{
	public class Hellfire : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Hellfire");
			/* Description.SetDefault("Cursed Hellfire burns from the inside and out"
                + "\nDMG: 4"
                + "\nSpeed: Average"); */
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
            BuffID.Sets.LongerExpertDebuff[Type] = true;
        }

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<TrelamiumModPlayer>().hellfire = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<TrelamiumModGlobalNPC>().hellfire = true;
		}
	}
}
