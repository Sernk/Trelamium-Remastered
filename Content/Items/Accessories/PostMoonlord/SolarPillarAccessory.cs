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
    public class SolarPillarAccessory : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Solar Artifact");
            //Tooltip.SetDefault("'The power of the Solar Pillar compressed into this small artifact'"
            //    + "\nIncreases melee damage by 24%"
            //    + "\nIncreases melee speed by 22%"
            //    + "\nIncreases maximum life by 120"
            //    + "\nMelee attacks ingite enemies with Solar Flare Debuff");
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
            player.statLifeMax2 += 120;
            player.GetDamage(DamageClass.Melee) += 0.24f;
            player.GetAttackSpeed(DamageClass.Melee) += 0.22f;
        }
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FragmentSolar, 18);
            recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}