using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Items;
using TrelamiumRemastered.Content.NPCs.Aureolus;

namespace TrelamiumRemastered.Content.Items.Aureolus
{
	public class EnragedNimbus : ModItem
	{
		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Enraged Nimbus");
            //Tooltip.SetDefault("Summons the Ruler of Skies");
        }

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 20;
			Item.rare = -12;
			Item.useAnimation = 22;
			Item.useTime = 22;
			Item.useStyle = 4;
			Item.UseSound = SoundID.Item44;
			Item.consumable = true;
		}
		public override bool CanUseItem(Player player)
		{
            return Main.raining && !NPC.AnyNPCs(ModContent.NPCType<AureolusBosss>());
		}

		public override bool? UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<AureolusBosss>());
            SoundEngine.PlaySound(SoundID.Roar, player.position);
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Cloud, 10);
            recipe.AddIngredient(ItemID.RainCloud, 10);
            recipe.AddIngredient(ModContent.ItemType<AerialEssence>(), 4);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
        }
	}
}