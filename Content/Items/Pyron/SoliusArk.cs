using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Dusts;

namespace TrelamiumRemastered.Content.Items.Pyron
{
    public class SoliusArk : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Solius Ark");
            // Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.damage = 45;
            Item.crit = 4;
            Item.rare = 3;
            Item.width = 60;
            Item.height = 50;
            Item.useAnimation = 14;
            Item.useTime = 14;
            Item.useStyle = 1;
            Item.knockBack = 3.5f;
            Item.shootSpeed = 18.5f;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.value = Terraria.Item.buyPrice(0, 10, 0, 0);
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<MagmaFlareProjectile>();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int numberProjectiles = 3 + Main.rand.Next(2);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(30));
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
    }
}