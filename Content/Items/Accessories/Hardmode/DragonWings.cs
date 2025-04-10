using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace TrelamiumRemastered.Content.Items.Accessories.Hardmode
{
	[AutoloadEquip(EquipType.Wings)]
	public class DragonWings : ModItem
	{
		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Dragon Wings");
            //Tooltip.SetDefault("Allows Flight"
            //       + "\nFlight Time: 165"
            //       + "\nAcceleration 3");
            ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(165, 15f, 3f);
        }

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 20;
            Item.value = Terraria.Item.buyPrice(0, 20, 0, 0);
            Item.rare = 8;
			Item.accessory = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 165;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.35f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 15f;
			acceleration *= 3f;
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PrimevalClaw>(), 12);
            recipe.AddIngredient(ItemID.SoulofFright, 8);
            recipe.AddIngredient(ItemID.SoulofFlight, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}