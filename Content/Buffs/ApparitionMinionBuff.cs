using Terraria;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Minions;

namespace TrelamiumRemastered.Content.Buffs
{
    public class ApparitionMinionBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Shadowflame Apparition");
            // Description.SetDefault("The shadowflame apparition will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            TrelamiumModPlayer modPlayer = player.GetModPlayer<TrelamiumModPlayer>();
            if (player.ownedProjectileCounts[ModContent.ProjectileType<ShadowflameApparitionProjectile>()] > 0)
            {
                modPlayer.shadowflameApparition = true;
            }
            if (!modPlayer.shadowflameApparition)
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