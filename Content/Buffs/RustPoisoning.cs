using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.NPCs;
using TrelamiumRemastered;

namespace TrelamiumRemastered.Content.Buffs
{
	public class RustPoisoning : ModBuff
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Rust Poisoning");
			//Description.SetDefault("Slowy dying");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
            BuffID.Sets.LongerExpertDebuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<TrelamiumModPlayer>().rustPoisoning = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<TrelamiumModGlobalNPC>().rustPoisoning = true;
		}
	}
}
