using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items
{
    public class AlluviumBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Alluvium Bar");
            //Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.rare = 7;
            Item.width = 30;
            Item.height = 24;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.sellPrice(0, 0, 2, 50);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AlluviumChunk>(), 5);       
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
        }
    }
}