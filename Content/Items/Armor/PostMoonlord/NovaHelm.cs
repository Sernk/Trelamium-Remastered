using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Armor.PostMoonlord
{
    [AutoloadEquip(EquipType.Head)]

    public class NovaHelm : ModItem
    {
        //public override void SetStaticDefaults()
        //{
        //    DisplayName.SetDefault("Nova Helmet");
        //    Tooltip.SetDefault("Increases critical strike chance by 15%");
        //}
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 10;
            Item.defense = 24;
            Item.value = Terraria.Item.buyPrice(0, 7, 75, 0);
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlines = true;
        }

        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == ModContent.ItemType<NovaPlate>() && legs.type == ModContent.ItemType<NovaCuisses>();
        }

        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Melee) += 15;
            player.GetCritChance(DamageClass.Magic) += 15;
            player.GetCritChance(DamageClass.Throwing) += 15;
            player.GetCritChance(DamageClass.Ranged) += 15;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Weapons inflict 'Novaburn'";
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.FragmentSolar, 14);
            recipe.AddIngredient(ItemID.FragmentNebula, 14);
            recipe.AddIngredient(ItemID.FragmentStardust, 14);
            recipe.AddIngredient(ItemID.FragmentVortex, 14);
            recipe.AddIngredient(ItemID.LunarBar, 10);
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