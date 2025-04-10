using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Projectiles
{
    public class MeteorProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Meteor");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.aiStyle = 1;
            Projectile.width = 32;
            Projectile.height = 34;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 1;
        }
        public override void AI()
        {
            Projectile.rotation += Projectile.velocity.X * 2f;
            Vector2 position = Projectile.Center + Vector2.Normalize(Projectile.velocity) * 10f;
            Dust dust37 = Main.dust[Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6, 0f, 0f, 0, default(Color), 1f)];
            dust37.position = position;
            dust37.velocity = Projectile.velocity.RotatedBy(1.5707963705062866, default(Vector2)) * 0.33f + Projectile.velocity / 4f;
            Dust dust3 = dust37;
            dust3.position += Projectile.velocity.RotatedBy(1.5707963705062866, default(Vector2));
            dust37.fadeIn = 0.5f;
            dust37.noGravity = true;
            dust37 = Main.dust[Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6, 0f, 0f, 0, default(Color), 1f)];
            dust37.position = position;
            dust37.velocity = Projectile.velocity.RotatedBy(-1.5707963705062866, default(Vector2)) * 0.33f + Projectile.velocity / 4f;
            dust3 = dust37;
            dust3.position += Projectile.velocity.RotatedBy(-1.5707963705062866, default(Vector2));
            dust37.fadeIn = 0.5f;
            dust37.noGravity = true;
            int num;
            for (int num190 = 0; num190 < 1; num190 = num + 1)
            {
                int num191 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 0, default(Color), 1f);
                dust3 = Main.dust[num191];
                dust3.velocity *= 0.5f;
                dust3 = Main.dust[num191];
                dust3.scale *= 1.3f;
                Main.dust[num191].fadeIn = 1f;
                Main.dust[num191].noGravity = true;
                num = num190;
            }
        }

        public override void OnKill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            int num570 = Main.rand.Next(4, 10);
            int num3;
            for (int num571 = 0; num571 < num570; num571 = num3 + 1)
            {
                int num572 = Dust.NewDust(Projectile.Center, 0, 0, 6, 0f, 0f, 100, default(Color), 1f);
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