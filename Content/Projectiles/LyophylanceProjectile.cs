using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Projectiles
{
    public class LyophylanceProjectile : ModProjectile
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
                if (Main.myPlayer == Projectile.owner) //body only
                {
                    int num52 = Projectile.type;
                    num52 = 151;
                    if (Projectile.ai[1] >= 10f)
                    {
                        num52 = 152;
                    }
                    int num53 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + Projectile.velocity.X + (float)(Projectile.width / 2), Projectile.position.Y + Projectile.velocity.Y + (float)(Projectile.height / 2), Projectile.velocity.X, Projectile.velocity.Y, num52, Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0f);
                    Main.projectile[num53].damage = Projectile.damage;
                    Main.projectile[num53].ai[1] = Projectile.ai[1] + 1f;
                    NetMessage.SendData(27, -1, -1, null, num53, 0f, 0f, 0f, 0, 0, 0);
                    return;
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