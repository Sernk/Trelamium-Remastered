using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class HeavyRifle : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Heavy Rifle");
            // Tooltip.SetDefault("Fires a spread of bullets");
        }
        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.crit = 4;
            Item.rare = 3;
            Item.width = 56;
            Item.height = 22;
            Item.useAnimation = 28;
            Item.useTime = 28;
            Item.useStyle = 5;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 12f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 7, 50, 0);
            Item.UseSound = SoundID.Item36;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Bullet;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int numberProjectiles = 4 + Main.rand.Next(2);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(30));
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Musket);
            recipe.AddIngredient(ItemID.Shotgun);
            recipe.AddIngredient(ItemID.ExplosivePowder, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.TheUndertaker);
            recipe1.AddIngredient(ItemID.Shotgun);
            recipe1.AddIngredient(ItemID.ExplosivePowder, 10);
            recipe1.AddTile(TileID.MythrilAnvil);
            recipe1.Register();
        }
    }
}