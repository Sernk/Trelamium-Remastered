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
    public class GalathrowerProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Cosmic Stardust");
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 175;
            Projectile.extraUpdates = 2;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<GalaticTorment>(), 300, true);
        }
        public override void AI()
        {
            Lighting.AddLight(Projectile.Center, ((255 - Projectile.alpha) * 0.15f) / 255f, ((255 - Projectile.alpha) * 0.45f) / 255f, ((255 - Projectile.alpha) * 0.05f) / 255f);   //this is the light colors
            if (Projectile.timeLeft > 125)
            {
                Projectile.timeLeft = 125;
            }
            if (Projectile.ai[0] > 12f)
            {
                    int dust = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 27, Projectile.velocity.X * 1.2f, Projectile.velocity.Y * 1.2f, 130, default(Color), 3.75f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 2.5f;
                    int dust2 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 100, Projectile.velocity.X * 1.2f, Projectile.velocity.Y * 1.2f, 130, default(Color), 1.5f);
            }
            else
            {
                Projectile.ai[0] += 1f;
            }
            return;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.Kill();
            return false;
        }
    }
}