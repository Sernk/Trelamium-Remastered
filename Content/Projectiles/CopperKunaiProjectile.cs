using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Projectiles
{
    public class CopperKunaiProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Copper Kunai");
        }

        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 38;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.timeLeft = 200;
            Projectile.penetrate = 1;
        }
        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            Vector2 usePos = Projectile.position;
            Vector2 rotVector = (Projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
            usePos += rotVector * 16f;
            for (int i = 0; i < 20; i++)
            {
                Dust dust = Dust.NewDustDirect(usePos, Projectile.width, Projectile.height, 9);
                dust.position = (dust.position + Projectile.Center) / 2f;
                dust.velocity += rotVector * 2f;
                dust.velocity *= 0.5f;
                dust.noGravity = true;
                usePos -= rotVector * 8f;
            }
        }
    }
}