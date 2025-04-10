using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Accessories.PreHardmode
{
    public class ManaTalisman : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Mana Talisman");
            //Tooltip.SetDefault("Grants immunity to knockback"
            //    + "\nDecreases mana usage by 10%");
        }

        public override void SetDefaults()
        {
            Item.height = 12;
            Item.width = 22;
            Item.rare = 1;
            Item.accessory = true;
            Item.value = Terraria.Item.buyPrice(0, 1, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaCost -= 0.10f;
            player.noKnockback = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<MagicCharm>());
            recipe.AddIngredient(ItemID.CobaltShield);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}