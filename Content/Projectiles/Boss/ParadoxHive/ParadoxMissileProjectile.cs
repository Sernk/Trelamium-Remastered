using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Buffs;

namespace TrelamiumRemastered.Content.Projectiles.Boss.ParadoxHive
{
    public class ParadoxMissileProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Paradox Missile");
        }

        public override void SetDefaults()
        {
            Projectile.penetrate = -1;
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.timeLeft = 500;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.hostile = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 1;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<Desolation>(), 200, true);
        }
        public override void AI()
        {
            if (Projectile.ai[1] == 0)
            {
                Projectile.timeLeft = 500 + Main.rand.Next(35);
                Projectile.ai[1] = 1;
            }
            if (Projectile.alpha < 170)
            {
                for (int index1 = 0; index1 < 1; ++index1)
                {
                    float x = Projectile.position.X - Projectile.velocity.X / 18f * (float)index1;
                    float y = Projectile.position.Y - Projectile.velocity.Y / 18f * (float)index1;
                    int index2 = Dust.NewDust(new Vector2(x, y), 1, 1, 235, 0.0f, 0.0f, 0, new Color(), 1f);
                    Main.dust[index2].scale = 2f;
                    Main.dust[index2].noGravity = true;
                }
            }

            if (Projectile.alpha > 70)
            {
                Projectile.alpha -= 15;
                if (Projectile.alpha < 70)
                {
                    Projectile.alpha = 70;
                }
            }
            if (Projectile.localAI[0] == 0f)
            {
                AdjustMagnitude(ref Projectile.velocity);
                Projectile.localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero;
            float distance = 800f;
            bool target = false;
            for (int k = 0; k < 200; k++)
            {
                if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
                {
                    Vector2 newMove = Main.npc[k].Center - Projectile.Center;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (distanceTo < distance)
                    {
                        move = newMove;
                        distance = distanceTo;
                        target = true;
                    }
                }
            }
            if (target)
            {
                AdjustMagnitude(ref move);
                Projectile.velocity = (20 * Projectile.velocity + move) / 18f;
                AdjustMagnitude(ref Projectile.velocity);
            }
        }
        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 6f)
            {
                vector *= 6f / magnitude;
            }
        }
    }
}