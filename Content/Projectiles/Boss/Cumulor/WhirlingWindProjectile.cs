using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Projectiles.Boss.Cumulor
{
    public class WhirlingWindProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Whirling Wind");
            Main.projFrames[Projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            Projectile.penetrate = 1;
            Projectile.aiStyle = 1;
            Projectile.width = 44;
            Projectile.height = 44;
            Projectile.timeLeft = 90;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.hostile = true;
            Projectile.tileCollide = true;
        }
        public override void AI()
        {
            for (int i = 0; i < 80; i++)
            {
                float num21 = Projectile.velocity.X / 2f;
                float num22 = Projectile.velocity.Y / 2f;
                int num23 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 172, 0f, 0f, 0, default(Color), 1.5f);
                Main.dust[num23].position.X = Projectile.Center.X - num21;
                Main.dust[num23].position.Y = Projectile.Center.Y - num22;
                Dust dust3 = Main.dust[num23];
                dust3.velocity *= 0f;
                Main.dust[num23].scale = 1.2f;
                Main.dust[num23].noGravity = true;
            }
        }
        public override void OnKill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            int num570 = Main.rand.Next(4, 10);
            int num3;
            int num252 = Main.rand.Next(3, 6);
            for (int num253 = 0; num253 < num252; num253 = num3 + 1)
            {
                Vector2 vector12 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                while (vector12.X == 0f && vector12.Y == 0f)
                {
                    vector12 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                }
                vector12.Normalize();
                vector12 *= (float)Main.rand.Next(70, 101) * 0.1f;
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.oldPosition.X + (float)(Projectile.width / 2), Projectile.oldPosition.Y + (float)(Projectile.height / 2), vector12.X, vector12.Y, ModContent.ProjectileType<AureoleCloudProjectile>(), (int)((double)Projectile.damage * 0.8), Projectile.knockBack * 0.8f, Projectile.owner, 0f, 0f);
                num3 = num253;
            }

            for (int num571 = 0; num571 < num570; num571 = num3 + 1)
            {
                int num572 = Dust.NewDust(Projectile.Center, 0, 0, 172, 0f, 0f, 100, default(Color), 1f);
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