using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Projectiles.Dusts
{
    public class RadiantBoltProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Radiant Bolt");
        }

        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 300;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
        }

        public override void AI()
        {
            int num111 = Projectile.frameCounter;
            for (int num368 = 0; num368 < 3; num368 = num111 + 1)
            {
                float num369 = Projectile.velocity.X / 3f * (float)num368;
                float num370 = Projectile.velocity.Y / 3f * (float)num368;
                int num371 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 214, 0f, 0f, 0, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 1f);
                Main.dust[num371].position.X = Projectile.Center.X - num369;
                Main.dust[num371].position.Y = Projectile.Center.Y - num370;
                Dust dust3 = Main.dust[num371];
                dust3.velocity *= 0f;
                Main.dust[num371].scale = 0.5f;
                num111 = num368;
            }
        }
    }
}