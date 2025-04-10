using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Projectiles.Dusts
{
    public class PegasusOathProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Pegasus Oathblade");
        }

        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 300;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
        }

        public override void AI()
        {
            //float num29 = 5f;
            //float num30 = 250f;
            //float scaleFactor = 6f;
            Vector2 value7 = new Vector2(8f, 10f);
            float num31 = 1.2f;
            Vector3 rgb = new Vector3(0.7f, 0.1f, 0.5f);
            int num32 = 4 * Projectile.MaxUpdates;
            int num33 = Utils.SelectRandom<int>(Main.rand, new int[]
            {
                    169,
                    169,
                    169,
                    169,
                    169
            });
            int num34 = 169;
            int num;
            Lighting.AddLight(Projectile.Center, rgb);
            Projectile.rotation = Projectile.velocity.ToRotation();
            Projectile.localAI[0] += 1f;
            if (Projectile.localAI[0] == 48f)
            {
                Projectile.localAI[0] = 0f;
            }

            if (Projectile.alpha == 0)
            {
                for (int num41 = 0; num41 < 2; num41 = num + 1)
                {
                    Vector2 value8 = Vector2.UnitX * -30f;
                    value8 = -Vector2.UnitY.RotatedBy((double)(Projectile.localAI[0] * 0.1308997f + (float)num41 * 3.14159274f), default(Vector2)) * value7 - Projectile.rotation.ToRotationVector2() * 10f;
                    int num42 = Dust.NewDust(Projectile.Center, 0, 0, num34, 0f, 0f, 160, default(Color), 1f);
                    Main.dust[num42].scale = num31;
                    Main.dust[num42].noGravity = true;
                    Main.dust[num42].position = Projectile.Center + value8 + Projectile.velocity * 2f;
                    Main.dust[num42].velocity = Vector2.Normalize(Projectile.Center + Projectile.velocity * 2f * 8f - Main.dust[num42].position) * 2f + Projectile.velocity * 2f;
                    num = num41;
                }
            }
            if (Main.rand.Next(12) == 0)
            {
                for (int num43 = 0; num43 < 1; num43 = num + 1)
                {
                    Vector2 value9 = -Vector2.UnitX.RotatedByRandom(0.19634954631328583).RotatedBy((double)Projectile.velocity.ToRotation(), default(Vector2));
                    int num44 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 169, 0f, 0f, 100, default(Color), 1f);
                    Dust dust3 = Main.dust[num44];
                    dust3.velocity *= 0.1f;
                    Main.dust[num44].position = Projectile.Center + value9 * (float)Projectile.width / 2f + Projectile.velocity * 2f;
                    Main.dust[num44].fadeIn = 0.9f;
                    num = num43;
                }
            }
            if (Main.rand.Next(64) == 0)
            {
                for (int num45 = 0; num45 < 1; num45 = num + 1)
                {
                    Vector2 value10 = -Vector2.UnitX.RotatedByRandom(0.39269909262657166).RotatedBy((double)Projectile.velocity.ToRotation(), default(Vector2));
                    int num46 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 169, 0f, 0f, 155, default(Color), 0.8f);
                    Dust dust3 = Main.dust[num46];
                    dust3.velocity *= 0.3f;
                    Main.dust[num46].position = Projectile.Center + value10 * (float)Projectile.width / 2f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[num46].fadeIn = 1.4f;
                    }
                    num = num45;
                }
            }
            if (Main.rand.Next(4) == 0)
            {
                for (int num47 = 0; num47 < 2; num47 = num + 1)
                {
                    Vector2 value11 = -Vector2.UnitX.RotatedByRandom(0.78539818525314331).RotatedBy((double)Projectile.velocity.ToRotation(), default(Vector2));
                    int num48 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, num33, 0f, 0f, 0, default(Color), 1.2f);
                    Dust dust3 = Main.dust[num48];
                    dust3.velocity *= 0.3f;
                    Main.dust[num48].noGravity = true;
                    Main.dust[num48].position = Projectile.Center + value11 * (float)Projectile.width / 2f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[num48].fadeIn = 1.4f;
                    }
                    num = num47;
                }
            }
            if (Main.rand.Next(3) == 0)
            {
                Vector2 value13 = -Vector2.UnitX.RotatedByRandom(0.19634954631328583).RotatedBy((double)Projectile.velocity.ToRotation(), default(Vector2));
                int num50 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, num34, 0f, 0f, 100, default(Color), 1f);
                Dust dust3 = Main.dust[num50];
                dust3.velocity *= 0.3f;
                Main.dust[num50].position = Projectile.Center + value13 * (float)Projectile.width / 2f;
                Main.dust[num50].fadeIn = 1.2f;
                Main.dust[num50].scale = 1.5f;
                Main.dust[num50].noGravity = true;
            }
        }
    }
}