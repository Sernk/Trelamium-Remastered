using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Projectiles
{
    public class HadesTridentProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Trident of Hades");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.width = 22;
            Projectile.height = 34;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 300;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 1;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Burning, 300, true);
            target.AddBuff(BuffID.OnFire, 300, true);
            target.AddBuff(BuffID.Daybreak, 300, true);
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item74, Projectile.position);
            int num570 = Main.rand.Next(4, 10);
            int num3;
            if (Main.myPlayer == Projectile.owner)
            {
                int num252 = Main.rand.Next(3, 6);
                for (int num253 = 0; num253 < num252; num253 = num3 + 1)
                {
                    Vector2 vector12 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                    while (vector12.X == 0f && vector12.Y == 0f)
                    {
                        vector12 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                    }
                    vector12.Normalize();
                    vector12 *= (float)Main.rand.Next(70, 101) * 0.1f;
                    //Projectile.NewProjectile(Projectile.GetSource_FromThis(), projectile.oldPosition.X + (float)(projectile.width / 2), projectile.oldPosition.Y + (float)(projectile.height / 2), vector12.X, vector12.Y, ModContent.ProjectileType<PrevalenceFlareProjectile>(), (int)((double)projectile.damage * 0.8), projectile.knockBack * 0.8f, projectile.owner, 0f, 0f);
                    num3 = num253;
                }
            }
            for (int index = 0; index < 100; index++)
            {
                int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 3f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 5f;
                dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
                Main.dust[dustIndex].velocity *= 3f;
                Main.dust[dustIndex].noGravity = true;
            }
        }

        public override void AI()
        {
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 0.785f;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;
            Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
    }
}
