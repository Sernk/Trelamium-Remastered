using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Consumables
{
    public class LacedAlchohol : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Laced Alchohol");
            //Tooltip.SetDefault("It'll knock you out for a whole 24 hours");
        }
        public override void SetDefaults()
        {
            Item.rare = -12;
            Item.width = 16;
            Item.height = 14;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.buffType = BuffID.Obstructed;
            Item.buffTime = 1460;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 3;
            Item.UseSound = SoundID.Item3;
            Item.value = Terraria.Item.sellPrice(0, 0, 2, 0);
        }
        public override bool? UseItem(Player player)
        {
            Main.fastForwardTimeToDusk/* tModPorter Note: Removed. Suggestion: IsFastForwardingTime(), fastForwardTimeToDawn or fastForwardTimeToDusk */ = true;
            Main.sundialCooldown = 0;
            return true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Ale);
            recipe.AddIngredient(ItemID.StrangePlant1);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.Ale);
            recipe1.AddIngredient(ItemID.StrangePlant2);
            recipe1.AddTile(TileID.Bottles);
            recipe1.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.Ale);
            recipe2.AddIngredient(ItemID.StrangePlant3);
            recipe2.AddTile(TileID.Bottles);
            recipe2.Register();
        }
    }
}