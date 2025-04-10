using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Accessories.PreHardmode
{
    public class FlamingSludgeContainer : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Flaming Sludge Container");
            //Tooltip.SetDefault("Increases jump height"
            //+ "\nGrants immunity to 'On Fire! and Burning'");
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
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.Burning] = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BlueSludgeContainer>());
            recipe.AddIngredient(ItemID.Hellstone, 30);
            recipe.AddTile(TileID.Hellforge);
            recipe.Register();
        }
    }
}