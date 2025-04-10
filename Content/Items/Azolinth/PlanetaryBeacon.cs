using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Items;
using TrelamiumRemastered.Content.NPCs.Azolinth;

namespace TrelamiumRemastered.Content.Items.Azolinth
{
	public class PlanetaryBeacon : ModItem
	{
		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Planetary Beacon");
            //Tooltip.SetDefault("Sends a distress signal to the A.Z.O");
        }

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.rare = -12;
			Item.useAnimation = 22;
			Item.useTime = 22;
			Item.useStyle = 4;
			Item.UseSound = SoundID.Item44;
			Item.consumable = false;
		}
		public override bool CanUseItem(Player player)
		{
            return !NPC.AnyNPCs(ModContent.NPCType<AzolinthHead>());
		}

		public override bool? UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<AzolinthHead>());
            SoundEngine.PlaySound(SoundID.Roar, player.position);
			return true;
		}
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(Mod, "Planetary Beacon", "Can Be Used More Than Once");
            line.OverrideColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
            tooltips.Add(line);
        }
        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<UnknownTechnology>(), 5);
            recipe.AddIngredient(ItemID.FragmentVortex, 8);
            recipe.AddIngredient(ItemID.FragmentStardust, 8);
            recipe.AddIngredient(ItemID.LunarBar, 4);
            recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}