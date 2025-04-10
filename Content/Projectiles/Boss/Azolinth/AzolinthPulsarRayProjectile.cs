using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Projectiles.Boss.Azolinth
{
    public class AzolinthPulsarRayProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Pulsar Ray");
        }

        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.hostile = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 300;
            Projectile.extraUpdates = 100;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
        }

        public override void AI()
        {
            int num3;
            for (int num452 = 0; num452 < 4; num452 = num3 + 1)
            {
                Vector2 vector36 = Projectile.position;
                vector36 -= Projectile.velocity * ((float)num452 * 0.25f);
                Projectile.alpha = 255;
                int num453 = Dust.NewDust(vector36, 1, 1, 229, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num453].position = vector36;
                Main.dust[num453].scale = (float)Main.rand.Next(120, 121) * 0.025f;
                Dust dust3 = Main.dust[num453];
                dust3.velocity *= 0f;
                dust3.noGravity = true;
                num3 = num452;
            }
            return;
        }
    }
}