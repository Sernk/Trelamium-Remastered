using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Accessories.PreHardmode
{
    public class PurpleSludgeContainer : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Purple Sludge Container");
            //Tooltip.SetDefault("Increases jump height"
            //+ "\nIncreases maximum mana by 10");
        }

        public override void SetDefaults()
        {
            Item.height = 12;
            Item.width = 22;
            Item.rare = 1;
            Item.accessory = true;
            Item.value = Terraria.Item.buyPrice(0, 0, 25, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.jumpBoost = true;
            player.statManaMax2 += 10;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BlueSludgeContainer>());
            recipe.AddIngredient(ItemID.Gel, 50);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}