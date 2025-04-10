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
    [AutoloadEquip(EquipType.Body)]

    public class CarnagePlate : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Carnage Plate");
            // Tooltip.SetDefault("Increases life regeneration by 5%");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 3;
            Item.defense = 5;
            Item.value = Terraria.Item.buyPrice(0, 0, 65, 0);
        }

        public override void UpdateEquip(Player player)
        {
            player.lifeRegen += 5;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DripplingStone>(), 18);
            recipe.AddIngredient(ModContent.ItemType<DecayedTooth>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}