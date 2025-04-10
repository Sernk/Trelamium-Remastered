using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Items;

namespace TrelamiumRemastered.Content.Items.Armor.PreHardmode
{
    [AutoloadEquip(EquipType.Legs)]

    public class CarnageGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Carnage Greaves");
            // Tooltip.SetDefault("Increases movement speed by 5%");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 3;
            Item.defense = 4;
            Item.value = Terraria.Item.buyPrice(0, 0, 50, 0);
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.05f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DripplingStone>(), 12);
            recipe.AddIngredient(ModContent.ItemType<DecayedTooth>(), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}