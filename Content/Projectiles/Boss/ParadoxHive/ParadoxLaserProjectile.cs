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
    public class ParadoxLaserProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Paradox Laser");
        }

        public override void SetDefaults()
        {
            Projectile.penetrate = -1;
            Projectile.width = 5;
            Projectile.height = 42;
            Projectile.timeLeft = 500;
            Projectile.aiStyle = 1;
            AIType = ProjectileID.PinkLaser;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.hostile = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 2;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<Desolation>(), 300, true);
        }
        public override void AI()
        {
            int DustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y + 1f), Projectile.width + 2, Projectile.height + 2, 235, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 74, default(Color), 2);
            Main.dust[DustIndex].scale = 0.5f;
        }
    }
}