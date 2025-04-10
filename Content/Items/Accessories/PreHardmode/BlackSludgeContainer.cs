using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Accessories.PreHardmode
{
    public class BlackSludgeContainer : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Black Sludge Container");
            //Tooltip.SetDefault("Increases jump height"
            //+ "\nIncreases damage reduction by 5%");
        }

        public override void SetDefaults()
        {
            Item.height = 12;
            Item.width = 22;
            Item.rare = 2;
            Item.accessory = true;
            Item.value = Terraria.Item.buyPrice(0, 0, 25, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance += 0.05f;
            player.jumpBoost = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BlueSludgeContainer>());
            recipe.AddIngredient(ItemID.Vertebrae, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ModContent.ItemType<BlueSludgeContainer>());
            recipe1.AddIngredient(ItemID.RottenChunk, 5);
            recipe1.AddTile(TileID.Anvils);
            recipe1.Register();
        }
    }
}