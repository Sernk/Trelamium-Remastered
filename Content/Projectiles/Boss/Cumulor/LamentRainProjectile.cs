using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Projectiles.Boss.Cumulor
{
    public class LamentRainProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Lamentful Tears");
        }

        public override void SetDefaults()
        {
            Projectile.penetrate = 1;
            Projectile.aiStyle = 1;
            Projectile.width = 12;
            Projectile.height = 20;
            Projectile.timeLeft = 90;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.hostile = true;
            Projectile.tileCollide = true;
        }
        public override void OnKill(int timeLeft)
        {
            int num272 = Main.rand.Next(5, 10);
            int num3;
            for (int num273 = 0; num273 < num272; num273 = num3 + 1)
            {
                int num274 = Dust.NewDust(Projectile.Center, 0, 0, 33, 0f, 0f, 100, default(Color), 0.5f);
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