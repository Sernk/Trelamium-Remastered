using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Buffs;

namespace TrelamiumRemastered.Content.Projectiles.Boss.Permafrost
{
    public class PermaburnBoltProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Permaburn Bolt");
            Main.projFrames[Projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            Projectile.penetrate = 1;
            Projectile.aiStyle = 1;
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.timeLeft = 400;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.hostile = true;
            Projectile.tileCollide = false;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<PermafrostBuff>(), 400, true);
        }
        public override void AI()
        {
            int num60 = Dust.NewDust(Projectile.Center, 0, 0, 113, 0f, 0f, 100, default(Color), 1f);
            Main.dust[num60].noLight = true;
            Main.dust[num60].noGravity = true;
            Main.dust[num60].velocity = Projectile.velocity;
            Dust dust3 = Main.dust[num60];
            dust3.position -= Vector2.One * 4f;
            Main.dust[num60].scale = 0.8f;
            int num = Projectile.frameCounter + 1;
            Projectile.frameCounter = num;
            if (num >= 9)
            {
                Projectile.frameCounter = 0;
                num = Projectile.frame + 1;
                Projectile.frame = num;
                if (num >= 5)
                {
                    Projectile.frame = 0;
                }
            }
            if (Projectile.ai[1] == 0f)
            {
                Projectile.ai[1] = 1f;
                if (Main.rand.Next(2) == 0)
                {
                    SoundEngine.PlaySound(SoundID.Item124, Projectile.position);
                }
                else
                {
                    SoundEngine.PlaySound(SoundID.Item125, Projectile.position);
                }
                Vector2 value14 = Vector2.Normalize(Projectile.velocity);
                int num78 = Main.rand.Next(5, 10);
                int num001;
                for (int num79 = 0; num79 < num78; num79 = num001 + 1)
                {
                    int num80 = Dust.NewDust(Projectile.Center, 0, 0, 229, 0f, 0f, 100, default(Color), 1f);
                    Dust dust9 = Main.dust[num80];
                    dust9.velocity.Y = dust9.velocity.Y - 1f;
                    Dust dust4 = Main.dust[num80];
                    dust4.velocity += value14 * 2f;
                    dust4 = Main.dust[num80];
                    dust4.position -= Vector2.One * 4f;
                    Main.dust[num80].noGravity = true;
                    num001 = num79;
                }
            }
            float num101 = (float)Math.Sqrt((double)(Projectile.velocity.X * Projectile.velocity.X + Projectile.velocity.Y * Projectile.velocity.Y));
            if (Projectile.alpha > 0)
            {
                Projectile.alpha -= (int)((byte)((double)num101 * 0.9));
            }
            if (Projectile.alpha < 0)
            {
                Projectile.alpha = 0;
            }
        }

        public override void OnKill(int timeLeft)
        {
            int num288 = Main.rand.Next(5, 10);
            int num3;
            for (int num289 = 0; num289 < num288; num289 = num3 + 1)
            {
                int num290 = Dust.NewDust(Projectile.Center, 0, 0, 229, 0f, 0f, 100, default(Color), 0.5f);
                Dust dust = Main.dust[num290];
                dust.velocity *= 1.6f;
                Dust dust27 = Main.dust[num290];
                dust27.velocity.Y = dust27.velocity.Y - 1f;
                dust = Main.dust[num290];
                dust.position -= Vector2.One * 4f;
                Main.dust[num290].position = Vector2.Lerp(Main.dust[num290].position, Projectile.Center, 0.5f);
                Main.dust[num290].noGravity = true;
                num3 = num289;
            }
        }
    }
}