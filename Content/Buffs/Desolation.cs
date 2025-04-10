using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Buffs
{
	public class Desolation : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Desolation");
			// Description.SetDefault("Feel the pain of true loneliness");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<TrelamiumModPlayer>().desolation = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<TrelamiumModGlobalNPC>().desolation = true;
		}
	}
}
