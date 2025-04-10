using Terraria;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Minions;

namespace TrelamiumRemastered.Content.Buffs
{
    public class OspreyMinionBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Osprey Minion Buff");
            // Description.SetDefault("The osprey will fight for you");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            TrelamiumModPlayer modPlayer = player.GetModPlayer<TrelamiumModPlayer>();
            if (player.ownedProjectileCounts[ModContent.ProjectileType<OspreyMinionProjectile>()] > 0)
            {
                modPlayer.ospreyFalcon = true;
            }
            if (!modPlayer.ospreyFalcon)
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