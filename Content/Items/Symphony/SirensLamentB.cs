using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Tiles.Stations;
namespace TrelamiumRemastered.Content.Items.Symphony
{
    public class SirensLamentB : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Siren's Lament");
            // Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.damage = 26;
            Item.crit = 4;
            Item.rare = 6;
            Item.width = 28;
            Item.height = 66;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 5;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 18f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 12, 0, 0);
            Item.UseSound = SoundID.Item5;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Arrow;
        }
    
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DepthStone>(), 12);
            recipe.AddTile(ModContent.TileType<AquaticForgeTile>());
            recipe.Register();
        }
    }
}