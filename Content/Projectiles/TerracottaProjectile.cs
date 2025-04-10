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
    public class TerracottaProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Terracotta");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 3;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            Projectile.extraUpdates = 0;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.penetrate = -1;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 14.75f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 205f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 13f;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.player[Projectile.owner];
            int numberProjectiles = 1;
            for (int index = 0; index < numberProjectiles; ++index)
            {
                int type = ModContent.ProjectileType<EarthenClusterProjectile>();
                Vector2 vector2_1 = new Vector2((float)((double)player.position.X + (double)player.width * 0.5 + (double)(Main.rand.Next(201) * -player.direction) + ((double)Main.mouseX + (double)Main.screenPosition.X - (double)player.position.X)), (float)((double)player.position.Y + (double)player.height * 0.5 - 600.0));   //this defines the projectile width, direction and position
                vector2_1.X = (float)(((double)vector2_1.X + (double)player.Center.X) / 2.0) + (float)Main.rand.Next(-200, 201);
                vector2_1.Y -= (float)(100 * index);
                float num12 = (float)Main.mouseX + Main.screenPosition.X - vector2_1.X;
                float num13 = (float)Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
                if ((double)num13 < 0.0) num13 *= -1f;
                if ((double)num13 < 20.0) num13 = 20f;
                float num14 = (float)Math.Sqrt((double)num12 * (double)num12 + (double)num13 * (double)num13);
                float num15 = Projectile.velocity.X / num14;
                float num16 = num12 * num15;
                float num17 = num13 * num15;
                float SpeedX = num16 + (float)Main.rand.Next(-40, 41) * 0.02f;
                float SpeedY = num17 + (float)Main.rand.Next(-40, 41) * 0.02f;
                int ProIndex = Projectile.NewProjectile(Projectile.GetSource_FromThis(), vector2_1.X, vector2_1.Y, SpeedX, SpeedY, type, Projectile.damage, Projectile.knockBack, Main.myPlayer, 0.0f, (float)Main.rand.Next(5));
            }
        }
        public override void AI()
        {
            Projectile.localAI[1] += 1f;
            if (Projectile.localAI[1] > 8f)
            {
                Projectile.localAI[1] = 0f;
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