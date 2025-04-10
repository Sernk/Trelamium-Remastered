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
    [AutoloadEquip(EquipType.Head)]

    public class OmnichromeHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Omni-chrome Helmet");
            //Tooltip.SetDefault("Increases throwning damage & critical strike chance by 35%");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.rare = 10;
            Item.defense = 38;
            Item.value = Terraria.Item.buyPrice(0, 30, 0, 0);
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlines = true;
        }

        public override bool IsArmorSet(Terraria.Item head, Terraria.Item body, Terraria.Item legs)
        {
            return body.type == ModContent.ItemType<OmnichromeChestguard>() && legs.type == ModContent.ItemType<OmnichromeCuisses>();
        }

        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Throwing) += 35;
            player.GetDamage(DamageClass.Throwing) += 0.35f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Your stats increase depending on your movement speed and state.\nMoving at maximum velocity will increase damage, and melee speed by 50%\nAt 50% of your maximum health your mana usage will be decreased by 30%\nAt 15% of health, you will surpass maximum velocity.";
            float playerVel = player.velocity.Length() / 2;
            player.GetDamage(DamageClass.Melee) += 10f * playerVel / 120;
            player.GetDamage(DamageClass.Magic) += 10f * playerVel / 120;
            player.GetDamage(DamageClass.Ranged) += 10f * playerVel / 120;
            player.GetDamage(DamageClass.Throwing) += 10f * playerVel / 120;
            player.GetDamage(DamageClass.Summon) += 10f * playerVel / 120;
            player.GetAttackSpeed(DamageClass.Melee) += 10f * playerVel / 120;

            if (player.statLife <= (player.statLifeMax2 * 0.50f))
            {
                player.manaCost -= 30;
            }
            if (player.statLife <= (player.statLifeMax2 * 0.15f))
            {
                player.GetDamage(DamageClass.Melee) += 25f * playerVel / 80;
                player.GetDamage(DamageClass.Magic) += 25f * playerVel / 80;
                player.GetDamage(DamageClass.Ranged) += 25f * playerVel / 80;
                player.GetDamage(DamageClass.Throwing) += 25f * playerVel / 80;
                player.GetDamage(DamageClass.Summon) += 25f * playerVel / 80;
                player.GetAttackSpeed(DamageClass.Melee) += 25f * playerVel / 80;
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.FragmentStardust, 8);
            recipe.AddIngredient(ModContent.ItemType<SublunarFragmentation>(), 5);
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