using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.NPCs.ParadoxHive;

namespace TrelamiumRemastered.Content.Items.ParadoxHive
{
	public class WarpedMirror : ModItem
	{
		public override void SetStaticDefaults()
		{
            //DisplayName.SetDefault("Warped Mirror");
            //Tooltip.SetDefault("Summons the Paradoxical Hivemind"
            //    + "\nUse at your own risk...");
        }

		public override void SetDefaults()
		{
            Item.width = 20;
            Item.height = 20;
            Item.rare = -12;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 4;
            Item.UseSound = SoundID.Item44;
            Item.consumable = false;
        }
		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(ModContent.NPCType<ParadoxHiveBoss>());
		}
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(Mod, "Warped Mirror", "Can Be Used More Than Once");
            line.OverrideColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
            tooltips.Add(line);
        }
        public override bool? UseItem(Player player)
		{
            Main.NewText("AZ0Did Solius lead you here? How cute...", new Color(255, 30, 30));
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<ParadoxHiveBoss>());
            SoundEngine.PlaySound(SoundID.Roar, player.position);
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            //recipe.AddIngredient(ModContent.ItemType<FragmentedCrystal>(), 12); 
            recipe.AddIngredient(ItemID.MagicMirror);
            recipe.AddIngredient(ModContent.ItemType<SublunarFragmentation>(), 5);
            recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}