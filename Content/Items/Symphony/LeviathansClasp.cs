using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Tiles.Stations;
using TrelamiumRemastered.Content.Projectiles;

namespace TrelamiumRemastered.Content.Items.Symphony
{
    public class LeviathansClasp : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Leviathan's Clasp");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 36;
            Item.crit = 4;
            Item.rare = 6;
            Item.width = 48;
            Item.height = 48;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 5;
            Item.knockBack = 6f;
            Item.shootSpeed = 3f;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.value = Terraria.Item.buyPrice(0, 5, 0, 0);
            Item.shoot = ModContent.ProjectileType<LeviathansClaspProjectile>();
            Item.UseSound = SoundID.Item1;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DepthStone>(), 12);
            recipe.AddTile(ModContent.TileType<AquaticForgeTile>());
            recipe.Register();
        }
    }
}