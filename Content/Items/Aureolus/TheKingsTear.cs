using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Items;

namespace TrelamiumRemastered.Content.Items.Aureolus
{
	public class TheKingsTear : ModItem
	{
		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("The King's Tear");
            //Tooltip.SetDefault("Starts the rain"
            //    + "\nRain will be invisible for a short amount of time");
        }

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 20;
			Item.rare = 2;
			Item.useAnimation = 22;
			Item.useTime = 22;
			Item.useStyle = 4;
			Item.UseSound = SoundID.Item44;
			Item.consumable = false;
		}
		public override bool CanUseItem(Player player)
		{
            return !Main.raining;
		}

        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            int num1 = 86400;
            int num2 = num1 / 24;
            Main.rainTime = Main.rand.Next(num2 * 8, num1);
            if (Main.rand.Next(3) == 0)
            {
                Main.rainTime += Main.rand.Next(0, num2);
            }

            float num3 = 1f;
            if (Main.rand.Next(2) == 0)
            {
                num3 += 0.05f;
            }
            if (Main.rand.Next(3) == 0)
            {
                num3 += 0.10f;
            }
            if (Main.rand.Next(4) == 0)
            {
                num3 += 0.15f;
            }
            if (Main.rand.Next(5) == 0)
            {
                num3 += 0.20f;
            }
            Main.rainTime = (int)((float)Main.rainTime * num3);
            Main.raining = true;
            return true;
        }  

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.RainCloud, 10);
            recipe.AddIngredient(ModContent.ItemType<AerialEssence>(), 5);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
        }
	}
}