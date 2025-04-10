using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Items;

namespace TrelamiumRemastered.Content.Items.Accessories.PreHardmode
{
    public class DesertCharm : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Desert Charm");
            //Tooltip.SetDefault("Grants immunity to 'Mighty Wind'"
            //    + "\nIncreases damage by 20% when in the desert");
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
            player.buffImmune[BuffID.WindPushed] = true;
            if (player.ZoneDesert)
            {
                player.GetDamage(DamageClass.Melee) += 0.2f;
                player.GetDamage(DamageClass.Ranged) += 0.2f;
                player.GetDamage(DamageClass.Magic) += 0.2f;
                player.GetDamage(DamageClass.Throwing) += 0.2f;
                player.GetDamage(DamageClass.Summon) += 0.2f;
            }
        }
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<PrimevalBar>(), 20);
            recipe.AddTile(16);
			recipe.Register();
		}
	}
}