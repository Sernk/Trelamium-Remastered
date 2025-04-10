using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Items;

namespace TrelamiumRemastered.Content.Items.Accessories.PreHardmode
{
    public class MurkySludgeContainer : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Murky Sludge Container");
            //Tooltip.SetDefault("Increases jump height"
            //+ "\nIncreases damage reduction by 10%"
            //+"\nIncreases movement speed by 10%");
        }

        public override void SetDefaults()
        {
            Item.height = 12;
            Item.width = 22;
            Item.rare = 3;
            Item.accessory = true;
            Item.value = Terraria.Item.buyPrice(0, 0, 25, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.jumpBoost = true;
            player.endurance += 0.10f;
            player.moveSpeed += 0.10f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BlueSludgeContainer>());
            recipe.AddIngredient(ModContent.ItemType<MurkyGel>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}