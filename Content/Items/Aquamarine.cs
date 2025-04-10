using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Tiles.Stations;

namespace TrelamiumRemastered.Content.Items
{
    public class Aquamarine : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Aquamarine");
        }
        public override void SetDefaults()
        {
            Item.rare = 4;
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.sellPrice(0, 0, 3, 75);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<GoldenPearl>());
            recipe.AddIngredient(ModContent.ItemType<SeaEssence>(), 2);
            recipe.AddTile(ModContent.TileType<AquaticForgeTile>());
            recipe.Register();
        }
    }
}