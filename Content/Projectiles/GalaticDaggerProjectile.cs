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
	public class GalaticDaggerProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Galatic Kunai");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 22;
			Projectile.height = 34;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.penetrate = 10;
			Projectile.timeLeft = 240;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.extraUpdates = 3;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
            //int num3 = 0;
            int num20 = 72;
            for (int i = 0; i < num20; i++)
            {
                Vector2 vector2 = Vector2.Normalize(Projectile.velocity) * new Vector2((float)Projectile.width / 2f, (float)Projectile.height) * 0.75f * 0.5f;
                vector2 = vector2.RotatedBy((double)((float)(i - (num20 / 2 - 1)) * 6.28318548f / (float)num20), default(Vector2)) + Projectile.Center;
                Vector2 vector3 = vector2 - Projectile.Center;
                int num21 = Dust.NewDust(vector2 + vector3, 0, 0, 235, vector3.X * 2f, vector3.Y * 2f, 100, default(Color), 1.4f);
                Main.dust[num21].noGravity = true;
                Main.dust[num21].noLight = true;
                Main.dust[num21].velocity = Vector2.Normalize(vector3) * 3f;
            }
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
				SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
			}
			return false;
		}

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item114, Projectile.position);
            //int num3 = 0;
            int num20 = 72;
            for (int i = 0; i < num20; i++)
            {
                Vector2 vector2 = Vector2.Normalize(Projectile.velocity) * new Vector2((float)Projectile.width / 2f, (float)Projectile.height) * 0.75f * 0.5f;
                vector2 = vector2.RotatedBy((double)((float)(i - (num20 / 2 - 1)) * 6.28318548f / (float)num20), default(Vector2)) + Projectile.Center;
                Vector2 vector3 = vector2 - Projectile.Center;
                int num21 = Dust.NewDust(vector2 + vector3, 0, 0, 27, vector3.X * 2f, vector3.Y * 2f, 100, default(Color), 1.4f);
                num21 = Dust.NewDust(vector2 + vector3, 0, 0, 235, vector3.X * 2f, vector3.Y * 2f, 100, default(Color), 1.4f);
                Main.dust[num21].noGravity = true;
                Main.dust[num21].noLight = true;
                Main.dust[num21].velocity = Vector2.Normalize(vector3) * 3f;
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
