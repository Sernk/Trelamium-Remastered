using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Buffs
{
	public class RadiantEuphoria : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Radiant Euphoria");
			// Description.SetDefault("You filled with too much joy, you will eventually die from your joy");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
            BuffID.Sets.LongerExpertDebuff[Type] = true;
        }

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<TrelamiumModPlayer>().radiantEuphoria = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<TrelamiumModGlobalNPC>().radiantEuphoria = true;
		}
	}
}
