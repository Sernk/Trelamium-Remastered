using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered;

namespace TrelamiumRemastered.Content.Items.Accessories.PreHardmode
{
    public class VentureBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Venturer Boots");
            //Tooltip.SetDefault("Increases movement speed by 22%"
            //    + "\nGrants immunity to Mighty Wind, Wet, Slow, and any debuff revolving around movement speed"
            //    + "\nAllows the wearer to run super fast & gives a rocket boost"
            //    + "\nAllows the player to walk on liquids"
            //    + "\nAllows the player to walk on Meteorite & Hellstone"
            //    + "\nWalking on mud decreases your movement speed by 10% but increases damage reduction by 8%"
            //    + "\nTraveling in the rain increases damage reduction by 13% but decreases movement speed by 5%");
        }
        public override void SetDefaults()
		{
            Item.height = 30;
            Item.width = 30;
            Item.rare = 3;
            Item.accessory = true;
            Item.value = Terraria.Item.buyPrice(0, 0, 35, 0);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<TrelamiumModPlayer>().ventureBoots = true;
            player.buffImmune[BuffID.WindPushed] = true;
            player.buffImmune[BuffID.Slow] = true;
            player.buffImmune[BuffID.Burning] = true;
            player.buffImmune[BuffID.Wet] = true;
            player.moveSpeed += 0.22f;
            player.rocketBoots = 10;

        }
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LightningBoots);
            recipe.AddIngredient(ItemID.ObsidianWaterWalkingBoots);
            recipe.AddIngredient(ItemID.LuckyHorseshoe);
            recipe.AddIngredient(ItemID.Feather, 8);
            recipe.AddIngredient(ItemID.Gel, 5);
            recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}