using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Projectiles
{
    public class MonolithProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Monolith");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 3;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.extraUpdates = 0;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.penetrate = -1;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 12f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 205f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 18f;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            //target.AddBuff(Mod.Find<ModBuff>("Carnage").Type, 300, true);
        }       
    
        public override void PostAI()
        {
            if (Main.rand.Next(5) == 0)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 5);
                dust.noGravity = true;
                dust.scale = 1.25f;
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