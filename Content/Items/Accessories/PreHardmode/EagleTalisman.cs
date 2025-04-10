using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Accessories.PreHardmode
{
    public class EagleTalisman : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Eagle Talisman");
            //Tooltip.SetDefault("Increases jump height & grants immunity to fall damage"
            //   + "\nIncreases magic damage & conserveration by 10%"
            //   + "\nGetting struck increases movement speed greatly");
        }

        public override void SetDefaults()
        {
            Item.height = 12;
            Item.width = 22;
            Item.rare = 3;
            Item.accessory = true;
            Item.value = Terraria.Item.buyPrice(0, 1, 0, 0);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.jumpBoost = true;
            player.noFallDmg = true;
            player.manaCost -= 10f;
            if (player.immune)
            {
                player.moveSpeed += 30f;
            }
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Feather, 20);
            recipe.AddIngredient(ItemID.Chain, 8);
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}