using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using TrelamiumRemastered.Content.Items;

namespace TrelamiumRemastered.Content.Items.Accessories.Hardmode
{
	[AutoloadEquip(EquipType.Wings)]
	public class TwilightWings : ModItem
	{
		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Twilight Wings");
            //Tooltip.SetDefault("Allows Flight"
            //       + "\nFlight Time: 150"
            //       + "\nAcceleration 1.5");
        }

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 20;
            Item.value = Terraria.Item.buyPrice(0, 10, 0, 0);
            Item.rare = 5;
			Item.accessory = true;
            ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(150, 10f, 1.4f);
        }
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 150;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 10f;
			acceleration *= 1.5f;
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<TwilightDust>(), 30);
            recipe.AddIngredient(ItemID.SoulofFlight, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}