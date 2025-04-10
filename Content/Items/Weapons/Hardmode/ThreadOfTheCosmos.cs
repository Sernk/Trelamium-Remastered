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
    public class ThreadOfTheCosmos : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Thread of the Cosmos");
            // Tooltip.SetDefault("Fires a burst of arrows");
        }
        public override void SetDefaults()
        {
            Item.damage = 55;
            Item.crit = 4;
            Item.rare = 9;
            Item.width = 22;
            Item.height = 54;
            Item.useAnimation = 28;
            Item.useTime = 28;
            Item.useStyle = 5;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 18f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 8, 50, 0);
            Item.UseSound = SoundID.Item5;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Arrow;
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
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<GalaticCore>(), 16);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}