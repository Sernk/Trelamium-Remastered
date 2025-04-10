using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class StormGenasis : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Storm Genesis");
            // Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.damage = 35;
            Item.crit = 4;
            Item.rare = 3;
            Item.width = 54;
            Item.height = 54;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 1;
            Item.knockBack = 3.5f;
            Item.shootSpeed = 20f;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.value = Terraria.Item.buyPrice(0, 15, 0, 0);
            Item.UseSound = SoundID.Item1;
            Item.shoot = ProjectileID.CrystalStorm;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 3 + Main.rand.Next(3);
            float rotation = MathHelper.ToRadians(45);
            position += Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 45f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, 26, knockback, player.whoAmI);
            }
            return false;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BladeOfWaves>());
            recipe.AddIngredient(ModContent.ItemType<MagmaStriker>());
            recipe.AddIngredient(ModContent.ItemType<AlluviumBlade>());
            recipe.AddIngredient(ModContent.ItemType<ZephyrBlade>());
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }
}