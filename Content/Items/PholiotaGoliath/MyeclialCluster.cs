using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.NPCs.PholiotaGoliath;
namespace TrelamiumRemastered.Content.Items.PholiotaGoliath
{
	public class MyeclialCluster : ModItem
	{
		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Myeclial Cluster");
            //Tooltip.SetDefault("Summons the Pholiota Goliath");
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
            return Main.dayTime && !NPC.AnyNPCs(ModContent.NPCType<PholiotaGoliathBoss>());
		}

		public override bool? UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<PholiotaGoliathBoss>());
            SoundEngine.PlaySound(SoundID.Roar, player.position);
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Mushroom, 25);
            recipe.AddIngredient(ModContent.ItemType<NatureEssence>(), 6);
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
        }
	}
}