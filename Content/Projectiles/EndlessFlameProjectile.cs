using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Buffs;

namespace TrelamiumRemastered.Content.Projectiles
{
    public class EndlessFlameProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Endless Flame");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 3;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.aiStyle = 1;
            Projectile.width = 14;
            Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.alpha = 255;
            Projectile.penetrate = 1;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 1;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<Hellfire>(), 300, true);
        }
        public override void AI()
        {
            DelegateMethods.v3_1 = new Vector3(0.6f, 1f, 1f) * 0.2f;
            Utils.PlotTileLine(Projectile.Center, Projectile.Center + Projectile.velocity * 10f, 8f, DelegateMethods.CastLightOpen);
            if (Projectile.alpha > 0)
            {
                Projectile.alpha = 0;
                Projectile.scale = 1.1f;
                Projectile.frame = Main.rand.Next(5);
                float num102 = 16f;
                int num103 = 0;
                while ((float)num103 < num102)
                {
                    Vector2 vector12 = Vector2.UnitX * 0f;
                    vector12 += -Vector2.UnitY.RotatedBy((double)((float)num103 * (6.28318548f / num102)), default(Vector2)) * new Vector2(1f, 4f);
                    vector12 = vector12.RotatedBy((double)Projectile.velocity.ToRotation(), default(Vector2));
                    int num104 = Dust.NewDust(Projectile.Center, 0, 0, 75, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[num104].scale = 1.5f;
                    Main.dust[num104].noGravity = true;
                    Main.dust[num104].position = Projectile.Center + vector12;
                    Main.dust[num104].velocity = Projectile.velocity * 0f + vector12.SafeNormalize(Vector2.UnitY) * 1f;
                    int num = num103;
                    num103 = num + 1;
                }
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