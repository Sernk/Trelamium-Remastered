using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Accessories.PreHardmode
{
    public class ContagiousSludgeContainer : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Contagatious Sludge Container");
            //Tooltip.SetDefault("Increases jump height"
            //+ "\nIncreases life regeneration by 5");
        }

        public override void SetDefaults()
        {
            Item.height = 12;
            Item.width = 22;
            Item.rare = 0;
            Item.accessory = true;
            Item.value = Terraria.Item.buyPrice(0, 0, 25, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.jumpBoost = true;
            player.lifeRegen += 5;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BlueSludgeContainer>());
            recipe.AddIngredient(ItemID.TissueSample, 14);
            recipe.AddTile(114);
            recipe.Register();
        }
    }
}