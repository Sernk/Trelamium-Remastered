using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.NPCs.Pyron;

namespace TrelamiumRemastered.Content.Items.Pyron
{
	public class SolarMandibleTotem : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Solar Mandible Totem");
			// Tooltip.SetDefault("Summons the imfamous solar devourer...");
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
			return player.position.Y / 16f > Main.maxTilesY - 200 && !NPC.AnyNPCs(ModContent.NPCType<PyronHead>());
		}

		public override bool? UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<PyronHead>());
			SoundEngine.PlaySound(SoundID.Roar, player.position);
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HellstoneBar, 5);
			recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}