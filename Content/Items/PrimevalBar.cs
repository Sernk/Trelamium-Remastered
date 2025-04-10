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
    public class PrimevalBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Primeval Bar");
            //Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.rare = 3;
            Item.width = 30;
            Item.height = 24;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.sellPrice(0, 0, 2, 50);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AncientFossil>(), 3);
            recipe.AddTile(ModContent.TileType<BlastFurnaceTile>());
            recipe.Register();
        }
    }
}