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
    public class NebulaPillarAccessory : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Nebula Artifact");
            //Tooltip.SetDefault("'The power of the Nebula Pillar compressed into this small artifact'"
            //    + "\nIncreases magic damage by 20%"
            //    + "\nIncreases magic crit by 12%"
            //    + "\nIncreases maximum mana by 100"
            //    + "\nEnemies have a small chance to drop nebula flares");
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
            player.statManaMax2 += 100;
            player.GetDamage(DamageClass.Magic) += 0.20f;
            player.GetCritChance(DamageClass.Magic) += 12;
            player.setNebula = true;
        }
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FragmentNebula, 18);
            recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}