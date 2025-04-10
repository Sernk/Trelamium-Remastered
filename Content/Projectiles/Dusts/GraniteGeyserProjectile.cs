using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Buffs;

namespace TrelamiumRemastered.Content.Projectiles.Dusts
{
    public class GraniteGeyserProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Granite Energy Geyser");
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 200;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.tileCollide = false;
            Projectile.penetrate = 20;
            Projectile.alpha = 255;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 60;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<GraniteOverload>(), 300, true);
        }
        public override void AI()
        {
            Projectile.velocity.X = (float)Projectile.direction * 1E-06f;
            Projectile.velocity.Y = (float)Projectile.direction * 1E-06f;
            float num840 = (float)(Projectile.width * Projectile.height) * 0.0045f;
            int num841 = 1;
            while ((float)num841 < num840)
            {
                int num842 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 240, 0f, 0f, 100, default(Color), 1f);
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 206, 0f, 0f, 100, default(Color), 1f);
                Main.dust[num842].noGravity = true;
                Dust dust3 = Main.dust[num842];
                dust3.velocity *= 0.5f;
                Dust dust101 = Main.dust[num842];
                dust101.velocity.Y = dust101.velocity.Y - 0.5f;
                Main.dust[num842].scale = 1.4f;
                Dust dust102 = Main.dust[num842];
                dust102.position.X = dust102.position.X + 6f;
                Dust dust103 = Main.dust[num842];
                dust103.position.Y = dust103.position.Y - 2f;
                int num3 = num841;
                num841 = num3 + 1;
            }
            return;
        }
    }
}