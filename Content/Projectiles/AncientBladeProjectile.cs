using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Projectiles
{
    public class AncientBladeProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ancient Warblade");
        }

        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.alpha = 255;
            Projectile.timeLeft = 600;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.ignoreWater = true;
        }

        public override void AI()
        {
            DelegateMethods.v3_1 = new Vector3(0.6f, 1f, 1f) * 0.2f;
            Utils.PlotTileLine(Projectile.Center, Projectile.Center + Projectile.velocity * 10f, 8f, DelegateMethods.CastLightOpen);
            if (Projectile.alpha > 0)
            {
                SoundEngine.PlaySound(SoundID.Item9, Projectile.Center);
                Projectile.alpha = 0;
                Projectile.scale = 1.1f;
                Projectile.frame = Main.rand.Next(14);
                float num102 = 16f;
                int num103 = 0;
                while ((float)num103 < num102)
                {
                    Vector2 vector12 = Vector2.UnitX * 0f;
                    vector12 += -Vector2.UnitY.RotatedBy((double)((float)num103 * (6.28318548f / num102)), default(Vector2)) * new Vector2(1f, 4f);
                    vector12 = vector12.RotatedBy((double)Projectile.velocity.ToRotation(), default(Vector2));
                    int num104 = Dust.NewDust(Projectile.Center, 0, 0, 268, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[num104].scale = 1.5f;
                    Main.dust[num104].noGravity = true;
                    Main.dust[num104].position = Projectile.Center + vector12;
                    Main.dust[num104].velocity = Projectile.velocity * 0f + vector12.SafeNormalize(Vector2.UnitY) * 1f;
                    int num = num103;
                    num103 = num + 1;
                }
            }
            Projectile.rotation = Projectile.velocity.ToRotation() + 0.7853982f;
        }

        public override void OnKill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            int num570 = Main.rand.Next(4, 10);
            int num3;
            for (int num571 = 0; num571 < num570; num571 = num3 + 1)
            {
                int num572 = Dust.NewDust(Projectile.Center, 0, 0, 268, 0f, 0f, 100, default(Color), 1f);
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
        public new Color GetAlpha(Color newColor)
        {
            Color? color = ProjectileLoader.GetAlpha(Projectile, newColor);
            if (color.HasValue)
            {
                return color.Value;
            }
            return new Color(150, 255, 255, 0) * Projectile.Opacity;
        }
    }
}