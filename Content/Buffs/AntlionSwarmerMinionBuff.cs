using Terraria;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Minions;

namespace TrelamiumRemastered.Content.Buffs
{
    public class AntlionSwarmerMinionBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Antlion Swarmer");
            // Description.SetDefault("The antlion swarmer will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            TrelamiumModPlayer modPlayer = player.GetModPlayer<TrelamiumModPlayer>();
            if (player.ownedProjectileCounts[ModContent.ProjectileType<AntlionSwarmerMinionProjectile>()] > 0)
            {
                modPlayer.antlionSwarmer = true;
            }
            if (!modPlayer.antlionSwarmer)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
            {
                player.buffTime[buffIndex] = 18000;
            }
        }
    }
}