using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Accessories.PreHardmode
{
    public class MagicCharm : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Mana Charm");
            //Tooltip.SetDefault("Increases maximum mana by 40"
            //   + "\nIncreases magic conserveration by 5%");
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
            player.statManaMax2 += 40;
            player.manaCost -= 0.5f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Chain, 2);
            recipe.AddIngredient(ItemID.ManaCrystal, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}