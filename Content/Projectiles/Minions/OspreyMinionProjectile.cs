using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Buffs;

namespace TrelamiumRemastered.Content.Projectiles.Minions
{
    public class OspreyMinionProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 6;
            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
            // DisplayName.SetDefault("Osprey");
        }

        public override void SetDefaults()
        {
            Projectile.netImportant = true;
            Projectile.width = 34;
            Projectile.height = 40;
            Projectile.friendly = true;
            Projectile.minion = true;
            Projectile.minionSlots = 1;
            Projectile.aiStyle = 54;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 18000;
            AIType = 317;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            bool minionCheck = Projectile.type == ModContent.ProjectileType<OspreyMinionProjectile>();
            player.AddBuff(ModContent.BuffType<OspreyMinionBuff>(), 3600);
            TrelamiumModPlayer modPlayer = player.GetModPlayer<TrelamiumModPlayer>();
            if (minionCheck)
            {
                if (player.dead)
                {
                    modPlayer.ospreyFalcon = false;
                }
                if (modPlayer.ospreyFalcon)
                {
                    Projectile.timeLeft = 2;
                }
            }
            Lighting.AddLight((int)(Projectile.Center.X / 16f), (int)(Projectile.Center.Y / 16f), 0.6f, 0.9f, 0.3f);
        }
        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            fallThrough = true;
            return true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.penetrate == 0)
            {
                Projectile.Kill();
            }
            return false;
        }
    }
}
