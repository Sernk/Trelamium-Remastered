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
    [AutoloadEquip(EquipType.Legs)]

    public class OmnichromeCuisses : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Omni-chrome Cuisse");
            //Tooltip.SetDefault("Increases movement speed by 30%"
            //    + "\nWhen under 40% of your maximum health, movement speed is increased tremendously");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 10;
            Item.defense = 25;
            Item.value = Terraria.Item.buyPrice(0, 30, 50, 0);
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.30f;
            if (player.statLife <= (player.statManaMax2 * 0.40f))
            {
                player.moveSpeed += 0.75f;
            }
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.FragmentStardust, 6);
            recipe.AddIngredient(ModContent.ItemType<SublunarFragmentation>(), 4);
            recipe.AddIngredient(ModContent.ItemType<EmptyRune>(), 2);
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