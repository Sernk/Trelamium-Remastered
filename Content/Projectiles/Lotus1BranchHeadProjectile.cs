using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Projectiles
{
    public class Lotus1BranchHeadProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Lotus Overgrowth");
        }

        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.alpha = 255;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Magic;
        }

        public override void AI()
        {
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 1.57f;
            if (Projectile.ai[0] == 0f)

            {
                if (Projectile.ai[1] == 0f && Projectile.alpha == 255 && Main.rand.Next(2) == 0)
                {
                    int num3 = Projectile.type;
                    Projectile.type = num3 + 1;
                    Projectile.netUpdate = true;
                }
                Projectile.alpha -= 25;
                if (Projectile.alpha <= 0)
                {
                    Projectile.alpha = 0;
                    Projectile.ai[0] = 1f;
                    if (Projectile.ai[1] == 0f)
                    {
                        Projectile.ai[1] += 1f;
                        Projectile.position += Projectile.velocity * 1f;
                    }
                }
            }
            else
            {
                if (Projectile.alpha < 170 && Projectile.alpha + 5 >= 170)
                {
                    int num3;
                    for (int num54 = 0; num54 < 8; num54 = num3 + 1)
                    {
                        int num55 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 7, Projectile.velocity.X * 0.025f, Projectile.velocity.Y * 0.025f, 200, default(Color), 1.3f);
                        Main.dust[num55].noGravity = true;
                        Dust dust3 = Main.dust[num55];
                        dust3.velocity *= 0.5f;
                        num3 = num54;
                    }
                }
                Projectile.alpha += 3;
                if (Projectile.alpha >= 255)
                {
                    Projectile.Kill();
                    return;
                }
            }
        }
    }
}