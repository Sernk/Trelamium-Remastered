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
    public class StardustPillarAccessory : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Stardust Artifact");
            //Tooltip.SetDefault("'The power of the Stardust Pillar compressed into this small artifact'"
            //    + "\nIncreases max minions by 2"
            //    + "\nIncreases minion damage by 25%"
            //    + "\nIncreases dexterity by 20%"
            //    + "\nIncreases minion knockback by 20%");
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
            player.maxMinions += 2;
            player.GetKnockback(DamageClass.Summon).Base += 0.20f;
            player.GetDamage(DamageClass.Summon) += 0.22f;
            player.GetAttackSpeed(DamageClass.Melee) += 0.20f;
        }
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FragmentStardust, 18);
            recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}