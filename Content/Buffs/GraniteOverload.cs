using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Buffs
{
	public class GraniteOverload : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Granite Overload");
			// Description.SetDefault("Granite energy has overloaded your body");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type]= true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<TrelamiumModPlayer>().graniteOverload = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<TrelamiumModGlobalNPC>().graniteOverload = true;
		}
	}
}
