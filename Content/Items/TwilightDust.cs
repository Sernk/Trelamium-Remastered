using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items
{
    public class TwilightDust : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Twilight Dust");
            //Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.rare = 4;
            Item.width = 14;
            Item.height = 28;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.sellPrice(0, 0, 4, 75);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(10);
            recipe.AddIngredient(ItemID.PixieDust, 10);
            recipe.AddIngredient(ItemID.SoulofNight);
            recipe.AddTile(TileID.AlchemyTable);
            recipe.Register();
        }
    }
}