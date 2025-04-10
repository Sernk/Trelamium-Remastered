using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Accessories.PostMoonlord
{
    [AutoloadEquip(EquipType.Balloon)]
    public class NovaPillarAccessory : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Celestial Artifact");
            //Tooltip.SetDefault("'The power of the celestial pillars compressed into this small artifact'"
            //    + "\nIncreases max minions by 2, and minion knockback by 20%"
            //    + "\nIncreases damage by 18%, dexterity by 20%, and critical strike chance by 10%"
            //    + "\nIncreases ranged and throwing velocity by 15%"
            //    + "\nIncreases maximum health and mana by 110, you 35% chance not to consume ammo"
            //    + "\nStanding still makes you invisible, increasing damage, Melee attacks inflict Daybreak"
            //    + "\nEnemies drop nebula flares, and minions increase damage depending on the player's velocity");
        }
        public override void SetDefaults()
		{
            Item.height = 30;
            Item.width = 30;
            Item.rare = 8;
            Item.accessory = true;
            Item.value = Terraria.Item.buyPrice(0, 10, 0, 0);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            #region Damage Values
            player.GetDamage(DamageClass.Melee) += 0.18f;
            player.GetDamage(DamageClass.Magic) += 0.18f;
            player.GetDamage(DamageClass.Summon) += 0.18f;
            player.GetDamage(DamageClass.Ranged) += 0.18f;
            player.GetDamage(DamageClass.Ranged) += 0.18f;

            player.GetCritChance(DamageClass.Melee) += 10;
            player.GetCritChance(DamageClass.Magic) += 10;
            player.GetCritChance(DamageClass.Ranged) += 10;
            player.GetCritChance(DamageClass.Throwing) += 10;
            #endregion
            player.maxMinions += 2;
            player.GetKnockback(DamageClass.Summon).Base += 0.20f;
            player.moveSpeed += 0.20f;
            player.GetAttackSpeed(DamageClass.Melee) += 0.20f;
            player.statLifeMax2 += 110;
            player.statManaMax2 += 110;
            player.shroomiteStealth = true;
            player.ammoCost75 = true;
            player.setNebula = true;
        }
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SolarPillarAccessory>());
            recipe.AddIngredient(ModContent.ItemType<StardustPillarAccessory>());
            recipe.AddIngredient(ModContent.ItemType<VortexPillarAccessory>());
            recipe.AddIngredient(ModContent.ItemType<NebulaPillarAccessory>());
            recipe.AddIngredient(ItemID.LunarBar, 10);
            recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}