using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.NPCs.Permafrost;

namespace TrelamiumRemastered.Content.Items.Permafrost
{
	public class TemporalLens : ModItem
	{
		public override void SetStaticDefaults()
		{
            // DisplayName.SetDefault("Temporal Lens");
            // Tooltip.SetDefault("Summons the ancient Temporal Overseer");
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
            return player.ZoneSnow && !Main.dayTime && !NPC.AnyNPCs(ModContent.NPCType<PermafrostBoss>()) && !NPC.AnyNPCs(ModContent.NPCType<PermafrostRun>());
		}

		public override bool? UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<PermafrostBoss>());
            SoundEngine.PlaySound(SoundID.Roar, player.position);
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IceBlock, 25);
            recipe.AddIngredient(ItemID.Lens, 3);
            recipe.AddIngredient(ItemID.SoulofSight, 3);
            recipe.AddIngredient(ItemID.SoulofNight, 6);
            recipe.AddIngredient(ItemID.SoulofLight, 6);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}