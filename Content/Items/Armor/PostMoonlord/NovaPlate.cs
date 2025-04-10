using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Armor.PostMoonlord
{
    [AutoloadEquip(EquipType.Body)]

    public class NovaPlate : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Nova Plate");
            //Tooltip.SetDefault("Increases maximum life by 100");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 10;
            Item.defense = 28;
            Item.value = Terraria.Item.buyPrice(0, 7, 65, 0);
        }

        public override void UpdateEquip(Player player)
        {
            player.statLifeMax2 += 100;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.FragmentSolar, 18);
            recipe.AddIngredient(ItemID.FragmentNebula, 18);
            recipe.AddIngredient(ItemID.FragmentStardust, 18);
            recipe.AddIngredient(ItemID.FragmentVortex, 18);
            recipe.AddIngredient(ItemID.LunarBar, 12);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine rarity in tooltips)
            {
                if (rarity.Mod == "Terraria" && rarity.Name == "ItemName")
                {
                    rarity.OverrideColor = new Color(81, 255, 240);
                }
            }
        }
    }
}