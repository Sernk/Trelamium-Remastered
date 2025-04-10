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
    public class VortexPillarAccessory : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Vortex Artifact");
            //Tooltip.SetDefault("'The power of the Vortex Pillar compressed into this small artifact'"
            //    + "\nIncreases ranged damage by 20%"
            //    + "\nIncreases accuracy & velocity by 14%"
            //    + "\nYou gain an additional 35% chance not to consume ammo"
            //    + "\nYou will become invisible while standing still"
            //    + "\nEnemies are less likely to target you");
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
            player.ammoCost75 = true;
            player.GetDamage(DamageClass.Ranged) += 0.20f;
            player.GetCritChance(DamageClass.Ranged) += 12;
            player.shroomiteStealth = true;
        }
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FragmentVortex, 18);
            recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}