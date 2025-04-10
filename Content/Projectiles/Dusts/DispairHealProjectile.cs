using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Projectiles.Dusts
{
    public class DispairHealProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Dispair Siphon");
        }

        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 240;
            Projectile.extraUpdates = 100;
            Projectile.ignoreWater = true;
        }
        public override void AI()
        {
            int num492 = (int)Projectile.ai[0];
            float num493 = 4f;
            Vector2 vector39 = new Vector2(Projectile.position.X + (float)Projectile.width * 0.5f, Projectile.position.Y + (float)Projectile.height * 0.5f);
            float num494 = Main.player[num492].Center.X - vector39.X;
            float num495 = Main.player[num492].Center.Y - vector39.Y;
            float num496 = (float)Math.Sqrt((double)(num494 * num494 + num495 * num495));
            if (num496 < 50f && Projectile.position.X < Main.player[num492].position.X + (float)Main.player[num492].width && Projectile.position.X + (float)Projectile.width > Main.player[num492].position.X && Projectile.position.Y < Main.player[num492].position.Y + (float)Main.player[num492].height && Projectile.position.Y + (float)Projectile.height > Main.player[num492].position.Y)
            {
                if (Projectile.owner == Main.myPlayer && !Main.player[Main.myPlayer].moonLeech)
                {
                    int num497 = Main.rand.Next(1, 5);
                    Main.player[num492].HealEffect(num497, false);
                    Player player = Main.player[num492];
                    player.statLife += num497;
                    if (Main.player[num492].statLife > Main.player[num492].statLifeMax2)
                    {
                        Main.player[num492].statLife = Main.player[num492].statLifeMax2;
                    }
                    NetMessage.SendData(66, -1, -1, null, num492, (float)num497, 0f, 0f, 0, 0, 0);
                }
                Projectile.Kill();
            }
            num496 = num493 / num496;
            num494 *= num496;
            num495 *= num496;
            Projectile.velocity.X = (Projectile.velocity.X * 15f + num494) / 16f;
            Projectile.velocity.Y = (Projectile.velocity.Y * 15f + num495) / 16f;          
        }
    }
}