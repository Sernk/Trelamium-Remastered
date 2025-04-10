using Terraria;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Minions;

namespace TrelamiumRemastered.Content.Buffs
{
    public class SurgeElementalMinionBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Surge Elemental");
            // Description.SetDefault("The surge elemental will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            TrelamiumModPlayer modPlayer = player.GetModPlayer<TrelamiumModPlayer>();
            if (player.ownedProjectileCounts[ModContent.ProjectileType<SurgeElementalMinionProjectile>()] > 0)
            {
                modPlayer.surgeElemental = true;
            }
            if (!modPlayer.surgeElemental)
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