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
    public class GenasisBoltProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Genesis Bolt");
        }

        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 300;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
        }

        public override void AI()
        {
            int num3;
            for (int num334 = 0; num334 < 3; num334 = num3 + 1)
            {
                int num335 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 173, Projectile.velocity.X, Projectile.velocity.Y, 50, default(Color), 1.2f);
                Main.dust[num335].position = (Main.dust[num335].position + Projectile.Center) / 2f;
                Main.dust[num335].noGravity = true;
                Dust dust3 = Main.dust[num335];
                dust3.velocity *= 0.5f;
                num3 = num334;
            }
            for (int num336 = 0; num336 < 2; num336 = num3 + 1)
            {
                int num337 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 173, Projectile.velocity.X, Projectile.velocity.Y, 50, default(Color), 0.4f);
                if (num336 == 0)
                {
                    Main.dust[num337].position = (Main.dust[num337].position + Projectile.Center * 5f) / 6f;
                }
                else if (num336 == 1)
                {
                    Main.dust[num337].position = (Main.dust[num337].position + (Projectile.Center + Projectile.velocity / 2f) * 5f) / 6f;
                }
                Dust dust3 = Main.dust[num337];
                dust3.velocity *= 0.1f;
                Main.dust[num337].noGravity = true;
                Main.dust[num337].fadeIn = 1f;
                num3 = num336;
            }
            return;
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item110, Projectile.position);
            int num570 = Main.rand.Next(4, 10);
            int num3;
            if (Main.myPlayer == Projectile.owner)
            {
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
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.oldPosition.X + (float)(Projectile.width / 2), Projectile.oldPosition.Y + (float)(Projectile.height / 2), vector12.X, vector12.Y, ModContent.ProjectileType<GenasisBolt1Projectile>(), (int)((double)Projectile.damage * 0.8), Projectile.knockBack * 0.8f, Projectile.owner, 0f, 0f);
                    num3 = num253;
                }
            }
            for (int num571 = 0; num571 < num570; num571 = num3 + 1)
            {
                int num572 = Dust.NewDust(Projectile.Center, 0, 0, 173, 0f, 0f, 100, default(Color), 1f);
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