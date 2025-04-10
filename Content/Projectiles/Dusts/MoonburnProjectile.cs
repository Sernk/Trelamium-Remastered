using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Projectiles.Dusts
{
    public class MoonburnProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Moonburn");
        }

        public override void SetDefaults()
        {
            Projectile.aiStyle = 1;
            Projectile.width = 30;
            Projectile.height = 30;
            AIType = 348;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 1;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 3;
            Projectile.timeLeft = 90;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Daybreak, 300, true);
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
                    int num104 = Dust.NewDust(Projectile.Center, 0, 0, 127, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[num104].scale = 1.5f;
                    Main.dust[num104].noGravity = true;
                    Main.dust[num104].position = Projectile.Center + vector12;
                    Main.dust[num104].velocity = Projectile.velocity * 0f + vector12.SafeNormalize(Vector2.UnitY) * 1f;
                    int num = num103;
                    num103 = num + 1;
                }
            }
        }
        public override void OnKill(int timeLeft)
        {
            Vector2 vel = new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-10, -8));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, vel, ModContent.ProjectileType<MoonburnCombustionProjectile>(), Projectile.damage, Projectile.knockBack, Projectile.owner, 0, 1);
        }
    }
}