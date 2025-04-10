using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Projectiles
{
    public class DreamSnatcherProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Dream Snatcher");
        }

        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 62;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.timeLeft = 200;
            Projectile.penetrate = 1;
        }
        public override void AI()
        {
            int num768 = Utils.SelectRandom<int>(Main.rand, new int[]
            {
                21, //Dust Switch
                27
            });
            Vector2 center5 = Projectile.Center;
            Vector2 vector73 = new Vector2(-16f, 16f);
            float num769 = 1f;
            vector73 += new Vector2(-16f, 16f);
            vector73 = vector73.RotatedBy((double)Projectile.rotation, default(Vector2));
            int num770 = 4;
            int num771 = Dust.NewDust(center5 + vector73 + Vector2.One * -(float)num770, num770 * 2, num770 * 2, num768, 0f, 0f, 100, default(Color), num769);
            Dust dust3 = Main.dust[num771];
            dust3.velocity *= 0.1f;
            if (Main.rand.Next(6) != 0)
            {
                Main.dust[num771].noGravity = true;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.CursedInferno, 60);
        }
        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            Vector2 usePos = Projectile.position;
            Vector2 rotVector = (Projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
            usePos += rotVector * 16f;
            for (int i = 0; i < 20; i++)
            {
                Dust dust = Dust.NewDustDirect(usePos, Projectile.width, Projectile.height, 27);
                dust.position = (dust.position + Projectile.Center) / 2f;
                dust.velocity += rotVector * 2f;
                dust.velocity *= 0.5f;
                dust.noGravity = true;
                usePos -= rotVector * 8f;
            }
        }
    }
}