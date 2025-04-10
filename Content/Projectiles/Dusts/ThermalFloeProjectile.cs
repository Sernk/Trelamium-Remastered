using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Buffs;

namespace TrelamiumRemastered.Content.Projectiles.Dusts
{
    public class ThermalFloeProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Thermal Floe");
        }

        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 8;
            Projectile.timeLeft = 200;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<PermafrostBuff>(), 300, true);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.penetrate--;
            if (Projectile.penetrate <= 0)
            {
                Projectile.Kill();
            }
            else
            {
                if (Projectile.velocity.X != oldVelocity.X)
                {
                    Projectile.velocity.X = -oldVelocity.X;
                }
                if (Projectile.velocity.Y != oldVelocity.Y)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }
                SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            }
            return false;
        }
        public override void AI()
        {
            if (Projectile.alpha > 0)
            {
                Projectile.alpha -= 50;
            }
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) - 1.57f;
            int num111 = Projectile.frameCounter;
            for (int num368 = 0; num368 < 3; num368 = num111 + 1)
            {
                float num369 = Projectile.velocity.X / 3f * (float)num368;
                float num370 = Projectile.velocity.Y / 3f * (float)num368;
                int num371 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 113, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num371].position.X = Projectile.Center.X - num369;
                Main.dust[num371].position.Y = Projectile.Center.Y - num370;
                Dust dust3 = Main.dust[num371];
                dust3.velocity *= 0f;
                Main.dust[num371].scale = 0.5f;
                num111 = num368;
            }
            
            if (Projectile.velocity.X > 0f)
            {
                Projectile.spriteDirection = 1;
            }
            else if (Projectile.velocity.X < 0f)
            {
                Projectile.spriteDirection = -1;
            }
            Projectile.rotation = Projectile.velocity.X * 0.1f;
            int num3 = Projectile.frameCounter;
            Projectile.frameCounter = num3 + 1;
            if (Projectile.frameCounter >= 3)
            {
                num3 = Projectile.frame;
                Projectile.frame = num3 + 1;
                Projectile.frameCounter = 0;
            }
            if (Projectile.frame >= 3)
            {
                Projectile.frame = 0;
            }

            float num372 = Projectile.position.X;
            float num373 = Projectile.position.Y;
            float num374 = 100000f;
            bool flag10 = false;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] > 30f)

            {
                Projectile.ai[0] = 30f;
                int num112;
                for (int num375 = 0; num375 < 200; num375 = num112 + 1)
                {
                    if (Main.npc[num375].CanBeChasedBy(Projectile, false) && (!Main.npc[num375].wet || Projectile.type == 307))
                    {
                        float num376 = Main.npc[num375].position.X + (float)(Main.npc[num375].width / 2);
                        float num377 = Main.npc[num375].position.Y + (float)(Main.npc[num375].height / 2);
                        float num378 = Math.Abs(Projectile.position.X + (float)(Projectile.width / 2) - num376) + Math.Abs(Projectile.position.Y + (float)(Projectile.height / 2) - num377);
                        if (num378 < 800f && num378 < num374 && Collision.CanHit(Projectile.position, Projectile.width, Projectile.height, Main.npc[num375].position, Main.npc[num375].width, Main.npc[num375].height))
                        {
                            num374 = num378;
                            num372 = num376;
                            num373 = num377;
                            flag10 = true;
                        }
                    }
                    num112 = num375;
                }

                if (!flag10)
                {
                    num372 = Projectile.position.X + (float)(Projectile.width / 2) + Projectile.velocity.X * 100f;
                    num373 = Projectile.position.Y + (float)(Projectile.height / 2) + Projectile.velocity.Y * 100f;
                }           
                float num379 = 9f;
                float num380 = 0.2f;
                Vector2 vector29 = new Vector2(Projectile.position.X + (float)Projectile.width * 0.5f, Projectile.position.Y + (float)Projectile.height * 0.5f);
                float num381 = num372 - vector29.X;
                float num382 = num373 - vector29.Y;
                float num383 = (float)Math.Sqrt((double)(num381 * num381 + num382 * num382));
                num383 = num379 / num383;
                num381 *= num383;
                num382 *= num383;
                if (Projectile.velocity.X < num381)

                {
                    Projectile.velocity.X = Projectile.velocity.X + num380;
                    if (Projectile.velocity.X < 0f && num381 > 0f)
                    {
                        Projectile.velocity.X = Projectile.velocity.X + num380 * 2f;
                    }
                }
                else if (Projectile.velocity.X > num381)

                {
                    Projectile.velocity.X = Projectile.velocity.X - num380;
                    if (Projectile.velocity.X > 0f && num381 < 0f)
                    {
                        Projectile.velocity.X = Projectile.velocity.X - num380 * 2f;
                    }
                }
                if (Projectile.velocity.Y < num382)

                {
                    Projectile.velocity.Y = Projectile.velocity.Y + num380;
                    if (Projectile.velocity.Y < 0f && num382 > 0f)
                    {
                        Projectile.velocity.Y = Projectile.velocity.Y + num380 * 2f;
                        return;
                    }
                }
                else if (Projectile.velocity.Y > num382)

                {
                    Projectile.velocity.Y = Projectile.velocity.Y - num380;
                    if (Projectile.velocity.Y > 0f && num382 < 0f)
                    {
                        Projectile.velocity.Y = Projectile.velocity.Y - num380 * 2f;
                        return;
                    }
                }
            }
        }
    }
}