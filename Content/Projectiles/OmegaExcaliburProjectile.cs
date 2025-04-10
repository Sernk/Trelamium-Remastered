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
    public class OmegaExcaliburProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Omega Excalibur");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 3;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.width = 22;
            Projectile.height = 34;
            Projectile.aiStyle = 27;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 240;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 1;
            AIType = ProjectileID.LightBeam;
        }
        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item110, Projectile.position);
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
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.oldPosition.X + (float)(Projectile.width / 2), Projectile.oldPosition.Y + (float)(Projectile.height / 2), vector12.X, vector12.Y, ModContent.ProjectileType<MeteorProjectile>(), (int)((double)Projectile.damage * 0.8), Projectile.knockBack * 0.8f, Projectile.owner, 0f, 0f);
                    num3 = num253;
                }
            }
            for (int num571 = 0; num571 < num570; num571 = num3 + 1)
            {
                int num572 = Dust.NewDust(Projectile.Center, 0, 0, 169, 0f, 0f, 100, default(Color), 1f);
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