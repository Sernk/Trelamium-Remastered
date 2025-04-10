using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TrelamiumRemastered.Content.Projectiles
{
    public class FungalMushroomBoss : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 22;
            Projectile.height = 24;
            Projectile.aiStyle = 1;
            Projectile.friendly = false;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 240;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 1;
            AIType = ProjectileID.Bullet;
        }
        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.NPCHit8, Projectile.position);
            int num570 = Main.rand.Next(4, 10);
            int num3;
            for (int num571 = 0; num571 < num570; num571 = num3 + 1)
            {
                int num572 = Dust.NewDust(Projectile.Center, 0, 0, 17, 0f, 0f, 100, default(Color), 1f);
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
    }
}