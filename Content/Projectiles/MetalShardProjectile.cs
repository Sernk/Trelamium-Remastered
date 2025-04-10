using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Projectiles
{
    public class MetalShardProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Metal Fragmentation");
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 3;
            Projectile.hide = true;
        }
        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)
        {
            if (Projectile.ai[0] == 1f)
            {
                int npcIndex = (int)Projectile.ai[1];
                if (npcIndex >= 0 && npcIndex < 200 && Main.npc[npcIndex].active)
                {
                    if (Main.npc[npcIndex].behindTiles)
                        behindNPCsAndTiles.Add(index);
                    else
                        behindNPCs.Add(index);
                    return;
                }
            }
            behindProjectiles.Add(index);
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            width = height = 10;
            return true;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
            {
                targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
            }
            return projHitbox.Intersects(targetHitbox);
        }

        public override void OnKill(int timeLeft)
        {
            int num570 = Main.rand.Next(4, 10);
            int num3;
            for (int num571 = 0; num571 < num570; num571 = num3 + 1)
            {
                int num572 = Dust.NewDust(Projectile.Center, 0, 0, 175, 0f, 0f, 100, default(Color), 1f);
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

        public bool isStickingToTarget
        {
            get { return Projectile.ai[0] == 1f; }
            set { Projectile.ai[0] = value ? 1f : 0f; }
        }
        public float targetWhoAmI
        {
            get { return Projectile.ai[1]; }
            set { Projectile.ai[1] = value; }
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            isStickingToTarget = true;
            targetWhoAmI = (float)target.whoAmI;
            Projectile.velocity =
                (target.Center - Projectile.Center) * 0.75f;
            Projectile.netUpdate = true;
            Projectile.damage = 0;
            int maxStickingJavelins = 6;
            Point[] stickingJavelins = new Point[maxStickingJavelins];
            int javelinIndex = 0;
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile currentProjectile = Main.projectile[i];
                if (i != Projectile.whoAmI
                    && currentProjectile.active
                    && currentProjectile.owner == Main.myPlayer
                    && currentProjectile.type == Projectile.type
                    && currentProjectile.ai[0] == 1f
                    && currentProjectile.ai[1] == (float)target.whoAmI
                )
                {
                    stickingJavelins[javelinIndex++] =
                        new Point(i, currentProjectile.timeLeft);
                    if (javelinIndex >= stickingJavelins.Length
                    )
                    {
                        break;
                    }
                }
            }
            if (javelinIndex >= stickingJavelins.Length)
            {
                int oldJavelinIndex = 0;
                for (int i = 1; i < stickingJavelins.Length; i++)
                {
                    if (stickingJavelins[i].Y < stickingJavelins[oldJavelinIndex].Y)
                    {
                        oldJavelinIndex = i;
                    }
                }
                Main.projectile[stickingJavelins[oldJavelinIndex].X].Kill();
            }
        }
        private const float maxTicks = 45f;
        private const int alphaReduction = 25;
        public override void AI()
        {
            if (Projectile.alpha > 0)
            {
                Projectile.alpha -= alphaReduction;
            }
            if (Projectile.alpha < 0)
            {
                Projectile.alpha = 0;
            }
            if (!isStickingToTarget)
            {
                targetWhoAmI += 1f;
                if (targetWhoAmI >= maxTicks)
                {
                    float velXmult = 0.98f;
                    float
                        velYmult = 0.35f;
                    targetWhoAmI = maxTicks;
                    Projectile.velocity.X = Projectile.velocity.X * velXmult;
                    Projectile.velocity.Y = Projectile.velocity.Y + velYmult;
                }
                Projectile.rotation =
                    Projectile.velocity.ToRotation() +
                    MathHelper.ToRadians(
                        90f);
                if (Main.rand.Next(3) == 0)
                {
                    Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, 175,
                        Projectile.velocity.X * .2f, Projectile.velocity.Y * .2f, 200, Scale: 1.2f);
                    dust.velocity += Projectile.velocity * 0.3f;
                    dust.velocity *= 0.2f;
                }
                if (Main.rand.Next(4) == 0)
                {
                    Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, 175,
                        0, 0, 254, Scale: 0.3f);
                    dust.velocity += Projectile.velocity * 0.5f;
                    dust.velocity *= 0.5f;
                }
            }
            if (isStickingToTarget)
            {
                Projectile.ignoreWater = true;
                Projectile.tileCollide = false;
                int aiFactor = 15;
                bool killProj = false;
                bool hitEffect = false;
                Projectile.localAI[0] += 1f;
                hitEffect = Projectile.localAI[0] % 30f == 0f;
                int projTargetIndex = (int)targetWhoAmI;
                if (Projectile.localAI[0] >= (float)(60 * aiFactor)
                    || (projTargetIndex < 0 || projTargetIndex >= 200))
                {
                    killProj = true;
                }
                else if (Main.npc[projTargetIndex].active && !Main.npc[projTargetIndex].dontTakeDamage)
                {
                    Projectile.Center = Main.npc[projTargetIndex].Center - Projectile.velocity * 2f;
                    Projectile.gfxOffY = Main.npc[projTargetIndex].gfxOffY;
                    if (hitEffect)
                    {
                        Main.npc[projTargetIndex].HitEffect(0, 1.0);
                    }
                }
                else
                {
                    killProj = true;
                }

                if (killProj)
                {
                    Projectile.Kill();
                }
            }
        }
    }
}