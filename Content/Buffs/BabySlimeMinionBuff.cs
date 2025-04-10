using Terraria;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Minions;

namespace TrelamiumRemastered.Content.Buffs
{
    public class BabySlimeMinionBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Murky Slime");
            // Description.SetDefault("The murky slimes will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            TrelamiumModPlayer modPlayer = player.GetModPlayer<TrelamiumModPlayer>();
            if (player.ownedProjectileCounts[ModContent.ProjectileType<BabySlimeMinionProjectile>()] > 0)
            {
                modPlayer.babySlime = true;
            }
            if (!modPlayer.babySlime)
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