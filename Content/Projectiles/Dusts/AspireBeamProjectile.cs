using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Projectiles.Dusts
{
    public class AspireBeamProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Cadence Beam");
        }

        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 50;
            Projectile.extraUpdates = 100;
            Projectile.ignoreWater = true;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0f, 0f, ModContent.ProjectileType<AspireHealProjectile>(), Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0f);
        }
        public override void AI()
        {
            int num3;
            for (int num452 = 0; num452 < 4; num452 = num3 + 1)
            {
                Vector2 vector36 = Projectile.position;
                vector36 -= Projectile.velocity * ((float)num452 * 0.25f);
                Projectile.alpha = 255;
                int num453 = Dust.NewDust(vector36, 1, 1, 71, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num453].position = vector36;
                Main.dust[num453].scale = (float)Main.rand.Next(80, 81) * 0.012f;
                Dust dust3 = Main.dust[num453];
                dust3.velocity *= 0f;
                dust3.noGravity = true;
                num3 = num452;
            }
            return;

        }
    }
}

