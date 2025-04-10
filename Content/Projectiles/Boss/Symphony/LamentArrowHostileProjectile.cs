using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Buffs;

namespace TrelamiumRemastered.Content.Projectiles.Boss.Symphony
{
    public class LamentArrowHostileProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Lament Arrow");
        }

        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 48;
            Projectile.aiStyle = 1;
            Projectile.hostile = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 5;
            Projectile.timeLeft = 250;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!Main.expertMode)
            {
                target.AddBuff(ModContent.BuffType<SirensLament>(), 180, true);
            }
            if (Main.expertMode)
            {
                target.AddBuff(ModContent.BuffType<SirensLament>(), 220, true);
            }
        }

        public override void OnKill(int timeLeft)
        {
            int num272 = Main.rand.Next(5, 10);
            int num3;
            for (int num273 = 0; num273 < num272; num273 = num3 + 1)
            {
                int num274 = Dust.NewDust(Projectile.Center, 0, 0, 172, 0f, 0f, 100, default(Color), 0.5f);
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