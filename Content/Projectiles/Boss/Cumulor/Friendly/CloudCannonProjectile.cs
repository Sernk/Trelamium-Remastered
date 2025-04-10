using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Projectiles.Boss.Cumulor.Friendly
{
    public class CloudCannonProjectile : ModProjectile
    {
        //public override void SetStaticDefaults()
        //{
        //    DisplayName.SetDefault("Aerial Strider");
        //}

        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 5;
            Projectile.aiStyle = 92;
            AIType = 511;
            Projectile.timeLeft = 75;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.penetrate--;
            if (Projectile.penetrate <= 0)
            {
                Projectile.Kill();
            }
            else
            {
                if (Projectile.velocity.X != oldVelocity.X)
                {
                    Projectile.velocity.X = -oldVelocity.X;
                }
                if (Projectile.velocity.Y != oldVelocity.Y)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }
            }
            return false;
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.NPCDeath33, Projectile.position);
            int num570 = Main.rand.Next(4, 10);
            int num3;
            if (Main.myPlayer == Projectile.owner)
            {
                int num252 = 4;
                for (int num253 = 0; num253 < num252; num253 = num3 + 1)
                {
                    Vector2 vector12 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                    while (vector12.X == 0f && vector12.Y == 0f)
                    {
                        vector12 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                    }
                    vector12.Normalize();
                    vector12 *= (float)Main.rand.Next(70, 101) * 0.1f;
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.oldPosition.X + (float)(Projectile.width / 2), Projectile.oldPosition.Y + (float)(Projectile.height / 2), vector12.X, vector12.Y, ModContent.ProjectileType<CloudCannonSplitProjectile>(), (int)((double)Projectile.damage * 0.8), Projectile.knockBack * 0.8f, Projectile.owner, 0f, 0f);
                    num3 = num253;
                }
            }
            for (int num571 = 0; num571 < num570; num571 = num3 + 1)
            {
                int num572 = Dust.NewDust(Projectile.Center, 0, 0, 31, 0f, 0f, 100, default(Color), 1f);
                Dust dust = Main.dust[num572];
                dust.velocity *= 1.6f;
                Dust dust56 = Main.dust[num572];
                dust56.velocity.Y = dust56.velocity.Y - 1f;
                dust = Main.dust[num572];
                dust.velocity += -Projectile.velocity * (Main.rand.NextFloat() * 2f - 1f) * 0.5f;
                Main.dust[num572].scale = 2f;
                Main.dust[num572].fadeIn = 0.5f;
                Main.dust[num572].noGravity = true;
                num3 = num571;
            }
        }
    }
}