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
    public class BabySlimeMinionProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 6;
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
            // DisplayName.SetDefault("Baby Slime");
        }

        public override void SetDefaults()
        {
            AIType = 266;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.alpha = 75;
            Projectile.aiStyle = 26;
            Projectile.penetrate = -1;
            Projectile.timeLeft = Projectile.timeLeft * 5;
            Projectile.minionSlots = 0.5f;
            Projectile.minion = true;
            Projectile.friendly = true;
            Projectile.netImportant = true;
            Projectile.tileCollide = false;
        }
        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            fallThrough = false;
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
        public override bool MinionContactDamage()
        {
            return true;
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            bool minionCheck = Projectile.type == ModContent.ProjectileType<BabySlimeMinionProjectile>();
            player.AddBuff(ModContent.BuffType<BabySlimeMinionBuff>(), 3600);
            TrelamiumModPlayer modPlayer = player.GetModPlayer<TrelamiumModPlayer>();
            if (minionCheck)
            {
                if (player.dead)
                {
                    modPlayer.babySlime = false;
                }
                if (modPlayer.babySlime)
                {
                    Projectile.timeLeft = 2;
                }
            }
        }
    }
}