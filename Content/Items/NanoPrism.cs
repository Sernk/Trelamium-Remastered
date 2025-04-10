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
    public class NanoPrism : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Nano Prism");
            //Tooltip.SetDefault("'This speed these things contain is unbelievably dangerous'");
        }
        public override void SetDefaults()
        {
            Item.rare = 7;
            Item.width = 14;
            Item.height = 28;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.sellPrice(0, 0, 8, 75);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SoundPrism>());
            recipe.AddIngredient(ItemID.ChlorophyteOre, 2);
            recipe.AddTile(ModContent.TileType<SoundConversatorTile>());
            recipe.Register();
        }
    }
}