using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Buffs;

namespace TrelamiumRemastered.Content.Projectiles.Boss.Permafrost
{
    public class CryoxisBeamProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Cryoxis Beam");
        }

        public override void SetDefaults()
        {
            Projectile.penetrate = 1;
            Projectile.aiStyle = 1;
            Projectile.width = 2;
            Projectile.height = 100;
            Projectile.timeLeft = 300;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.hostile = true;
            Projectile.tileCollide = true;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<PermafrostBuff>(), 400, true);
            target.AddBuff(BuffID.Frozen, 400, true);
            int num60 = Dust.NewDust(Projectile.Center, 0, 0, 113, 0f, 0f, 100, default(Color), 1f);
            Main.dust[num60].noLight = true;
            Main.dust[num60].noGravity = true;
            Main.dust[num60].velocity = Projectile.velocity;
            Dust dust3 = Main.dust[num60];
            dust3.position -= Vector2.One * 4f;
            Main.dust[num60].scale = 0.8f;
        }
        public override void OnKill(int timeLeft)
        {
            int num272 = Main.rand.Next(5, 10);
            int num3;
            for (int num273 = 0; num273 < num272; num273 = num3 + 1)
            {
                int num274 = Dust.NewDust(Projectile.Center, 0, 0, 113, 0f, 0f, 100, default(Color), 0.5f);
                Dust dust = Main.dust[num274];
                dust.velocity *= 1.6f;
                Dust dust23 = Main.dust[num274];
                dust23.velocity.Y = dust23.velocity.Y - 1f;
                Main.dust[num274].position = Vector2.Lerp(Main.dust[num274].position, Projectile.Center, 0.5f);
                Main.dust[num274].noGravity = true;
                num3 = num273;
            }
        }
    }
}