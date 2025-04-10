using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Armor.PostMoonlord
{
    [AutoloadEquip(EquipType.Legs)]

    public class NovaCuisses : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Nova Cuisse");
            //Tooltip.SetDefault("Increases damage by 25%");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 10;
            Item.defense = 22;
            Item.value = Terraria.Item.buyPrice(0, 7, 50, 0);
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Melee) += 0.25f;
            player.GetDamage(DamageClass.Magic) += 0.25f;
            player.GetDamage(DamageClass.Summon) += 0.25f;
            player.GetDamage(DamageClass.Ranged) += 0.25f;
            player.GetDamage(DamageClass.Throwing) += 0.25f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.FragmentSolar, 12);
            recipe.AddIngredient(ItemID.FragmentNebula, 12);
            recipe.AddIngredient(ItemID.FragmentStardust, 12);
            recipe.AddIngredient(ItemID.FragmentVortex, 12);
            recipe.AddIngredient(ItemID.LunarBar, 8);
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