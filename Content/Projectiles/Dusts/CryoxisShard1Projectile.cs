using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Projectiles.Dusts
{
    public class CryoxisShard1Projectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Cryoxis Shard");
        }

        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 200;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(Mod.Find<ModBuff>("Permafrost").Type, 300, true);
        }
        public override void AI()
        {
            int num3;
            Projectile.ai[1] += 1f;
            float num338 = (60f - Projectile.ai[1]) / 60f;
            if (Projectile.ai[1] > 40f)
            {
                Projectile.Kill();
            }
            Projectile.velocity.Y = Projectile.velocity.Y + 0.2f;
            if (Projectile.velocity.Y > 18f)
            {
                Projectile.velocity.Y = 18f;
            }
            Projectile.velocity.X = Projectile.velocity.X * 0.98f;
            for (int num339 = 0; num339 < 2; num339 = num3 + 1)
            {
                int num340 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 113, Projectile.velocity.X, Projectile.velocity.Y, 50, default(Color), 1.1f);
                Main.dust[num340].position = (Main.dust[num340].position + Projectile.Center) / 2f;
                Main.dust[num340].noGravity = true;
                Dust dust3 = Main.dust[num340];
                dust3.velocity *= 0.3f;
                dust3 = Main.dust[num340];
                dust3.scale *= num338;
                num3 = num339;
            }
            for (int num341 = 0; num341 < 1; num341 = num3 + 1)
            {
                int num342 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 113, Projectile.velocity.X, Projectile.velocity.Y, 50, default(Color), 0.6f);
                Main.dust[num342].position = (Main.dust[num342].position + Projectile.Center * 5f) / 6f;
                Dust dust3 = Main.dust[num342];
                dust3.velocity *= 0.1f;
                Main.dust[num342].noGravity = true;
                Main.dust[num342].fadeIn = 0.9f * num338;
                dust3 = Main.dust[num342];
                dust3.scale *= num338;
                num3 = num341;
            }
            return;
        }

        public override void OnKill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item110, Projectile.position);
            int num570 = Main.rand.Next(4, 10);
            int num3;
            for (int num571 = 0; num571 < num570; num571 = num3 + 1)
            {
                int num572 = Dust.NewDust(Projectile.Center, 0, 0, 113, 0f, 0f, 100, default(Color), 1f);
                Dust dust = Main.dust[num572];
                dust.velocity *= 1.6f;
                Dust dust56 = Main.dust[num572];
                dust56.velocity.Y = dust56.velocity.Y - 1f;
                dust = Main.dust[num572];
                dust.velocity += -Projectile.velocity * (Main.rand.NextFloat() * 2f - 1f) * 0.5f;
                Main.dust[num572].scale = 2f;
                Main.dust[num572].fadeIn = 0.5f;
                Main.dust[num572].noGravity = true;
                num3 = num571;
            }
        }
    }
}