using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Accessories.PreHardmode
{
    public class BundleOfSludges : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Bundle Of Sludges");
            //Tooltip.SetDefault("Increases jump height"
            //+ "\nIncreases damage, critical strike chance by 5, movement speed, damage reduction,"
            //+ "melee speed, mana and life regeneration by 15%"
            //+ "\nIncreases maximum mana and life by 30, Increases your max minions by 1");
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
            player.endurance += 0.15f;
            player.GetAttackSpeed(DamageClass.Melee) += 0.15f;
            player.moveSpeed += 0.15f;

            player.GetDamage(DamageClass.Melee) += 0.15f;
            player.GetDamage(DamageClass.Magic) += 0.15f;
            player.GetDamage(DamageClass.Ranged) += 0.15f;
            player.GetDamage(DamageClass.Throwing) += 0.15f;
            player.GetDamage(DamageClass.Summon) += 0.15f;

            player.GetCritChance(DamageClass.Melee) += 5;
            player.GetCritChance(DamageClass.Magic) += 5;
            player.GetCritChance(DamageClass.Ranged) += 5;
            player.GetCritChance(DamageClass.Throwing) += 5;

            player.lifeRegen += 15;
            player.manaRegen += 15;

            player.statLifeMax2 += 30;
            player.statManaMax2 += 30;

            player.maxMinions++;
            player.jumpBoost = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BlackSludgeContainer>());
            recipe.AddIngredient(ModContent.ItemType<BlueSludgeContainer>());
            recipe.AddIngredient(ModContent.ItemType<ContagiousSludgeContainer>());
            recipe.AddIngredient(ModContent.ItemType<FlamingSludgeContainer>());
            recipe.AddIngredient(ModContent.ItemType<FrozenSludgeContainer>());
            recipe.AddIngredient(ModContent.ItemType<GreenSludgeContainer>());
            recipe.AddIngredient(ModContent.ItemType<MurkySludgeContainer>());
            recipe.AddIngredient(ModContent.ItemType<PurpleSludgeContainer>());
            recipe.AddIngredient(ModContent.ItemType<RedSludgeContainer>());
            recipe.AddIngredient(ModContent.ItemType<YellowSludgeContainer>());
            recipe.AddTile(114);
            recipe.Register();

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ModContent.ItemType<BlackSludgeContainer>());
            recipe1.AddIngredient(ModContent.ItemType<BlueSludgeContainer>());
            recipe1.AddIngredient(ModContent.ItemType<CursedSludgeContainer>());
            recipe1.AddIngredient(ModContent.ItemType<FlamingSludgeContainer>());
            recipe1.AddIngredient(ModContent.ItemType<FrozenSludgeContainer>());
            recipe1.AddIngredient(ModContent.ItemType<GreenSludgeContainer>());
            recipe1.AddIngredient(ModContent.ItemType<MurkySludgeContainer>());
            recipe1.AddIngredient(ModContent.ItemType<PurpleSludgeContainer>());
            recipe1.AddIngredient(ModContent.ItemType<RedSludgeContainer>());
            recipe1.AddIngredient(ModContent.ItemType<YellowSludgeContainer>());
            recipe1.AddTile(114);
            recipe1.Register();
        }
    }
}