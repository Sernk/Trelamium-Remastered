using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Buffs;

namespace TrelamiumRemastered.Content.Projectiles.Minions
{
    public class ShadowflameApparitionProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 6;
            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
            // DisplayName.SetDefault("Shadowflame Apparition");
        }

        public override void SetDefaults()
        {
            Projectile.netImportant = true;
            Projectile.width = 24;
            Projectile.height = 32;
            Projectile.friendly = true;
            Projectile.minion = true;
            Projectile.minionSlots = 1;
            Projectile.aiStyle = 66;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 18000;
            AIType = 388;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.ShadowFlame, 300, true);
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            bool minionCheck = Projectile.type == ModContent.ProjectileType<ShadowflameApparitionProjectile>();
            player.AddBuff(ModContent.BuffType<ApparitionMinionBuff>(), 3600);
            TrelamiumModPlayer modPlayer = player.GetModPlayer<TrelamiumModPlayer>();
            if (minionCheck)
            {
                if (player.dead)
                {
                    modPlayer.shadowflameApparition = false;
                }
                if (modPlayer.shadowflameApparition)
                {
                    Projectile.timeLeft = 2;
                }
            }
            if (Main.rand.Next(5) == 0)
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height / 2, 21);
                Main.dust[dust].velocity.Y -= 1.2f;
            }
            Lighting.AddLight((int)(Projectile.Center.X / 16f), (int)(Projectile.Center.Y / 16f), 0.6f, 0.9f, 0.3f);
        }
        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            fallThrough = true;
            return true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.penetrate == 0)
            {
                Projectile.Kill();
            }
            return false;
        }
    }
}
