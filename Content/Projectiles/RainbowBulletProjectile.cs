using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Projectiles
{
    public class RainbowBulletProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Rainbow Bullet");
        }

        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 12;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 300;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 1;
            AIType = ProjectileID.Bullet;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 5; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 264, 0f, 0f, 0, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 1f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 8f;
                dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 264, 0f, 0f, 0, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 1f);
                Main.dust[dustIndex].velocity *= 8f;
                Main.dust[dustIndex].noGravity = true;
            }
            Projectile.position.X = Projectile.position.X + (float)(Projectile.width / 2);
            Projectile.position.Y = Projectile.position.Y + (float)(Projectile.height / 2);
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.position.X = Projectile.position.X - (float)(Projectile.width / 2);
            Projectile.position.Y = Projectile.position.Y - (float)(Projectile.height / 2);
        }   

        public override void AI()
        {
            int num;
            for (int num368 = 0; num368 < 3; num368 = num + 1)
            {
                float num369 = Projectile.velocity.X / 2f * (float)num368;
                float num370 = Projectile.velocity.Y / 2f * (float)num368;
                int num371 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 264, 0f, 0f, 0, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 1f);
                Main.dust[num371].position.X = Projectile.Center.X - num369;
                Main.dust[num371].position.Y = Projectile.Center.Y - num370;
                Main.dust[num371].noGravity = true;
                Dust dust3 = Main.dust[num371];
                dust3.velocity *= 0f;
                Main.dust[num371].scale = 0.5f;
                num = num368;
            }
        }
    }
}