using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Buffs;

namespace TrelamiumRemastered.Content.Projectiles
{
    public class VenusVolcanArrowProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Volcan Acid Arrow");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 36;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 300;
            Projectile.hide = true;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<VolcanAcid>(), 300, true);
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
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            Vector2 usePos = Projectile.position;
            Vector2 rotVector = (Projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
            usePos += rotVector * 16f;
            for (int i = 0; i < 20; i++)
            {
                Dust dust = Dust.NewDustDirect(usePos, Projectile.width, Projectile.height, 74);
                dust.position = (dust.position + Projectile.Center) / 2f;
                dust.velocity += rotVector * 2f;
                dust.velocity *= 0.5f;
                dust.noGravity = true;
                usePos -= rotVector * 8f;
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
                    Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, 74,
                        Projectile.velocity.X * .2f, Projectile.velocity.Y * .2f, 200, Scale: 1.2f);
                    dust.velocity += Projectile.velocity * 0.3f;
                    dust.velocity *= 0.2f;
                }
                if (Main.rand.Next(4) == 0)
                {
                    Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, 74,
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
        public override bool PreDraw(ref Color lightColor)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;
            Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
    }
}