using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Projectiles.Dusts
{
    public class AbyssalSpireProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Abyssal Spire");
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = 20;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.alpha = 255;
            Projectile.netImportant = true;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 600;
        }
        public override void AI()
        {
            int num1 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 27, 0f, 0f, 100, default(Color), 1f);
            num1 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 195, 0f, 0f, 100, default(Color), 1f);
            Dust dust1 = Main.dust[num1];
            dust1.velocity *= 0f;
            Main.dust[num1].scale = 1f;
            Main.dust[num1].noGravity = true;
        }
    }
}