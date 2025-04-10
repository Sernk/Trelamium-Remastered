using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Items; 

namespace TrelamiumRemastered.Content.Items.Armor.PostMoonlord
{
    [AutoloadEquip(EquipType.Body)]

    public class OmnichromeChestguard : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Omni-chrome Chestguard");
            //Tooltip.SetDefault("Increases life regen greatly"
            //    + "\nIncreases maximum health by 100");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 10;
            Item.defense = 45;
            Item.value = Terraria.Item.buyPrice(0, 30, 75, 0);
        }

        public override void UpdateEquip(Player player)
        {
            player.statLifeMax2 += 100;
            player.lifeRegen += 15;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.FragmentStardust, 10);
            recipe.AddIngredient(ModContent.ItemType<SublunarFragmentation>(), 8);
            recipe.AddIngredient(ModContent.ItemType<EmptyRune>(), 3);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine rarity in tooltips)
            {
                if (rarity.Mod == "Terraria" && rarity.Name == "ItemName")
                {
                    rarity.OverrideColor = new Color(230, 150, 0);
                }
            }
        }
    }
}