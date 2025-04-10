using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Tiles.Stations;
using TrelamiumRemastered.Content.Projectiles.Dusts;
namespace TrelamiumRemastered.Content.Items.Symphony
{
    public class TideOfTheGods : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Tide Of The Gods");
            //Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 26;
            Item.crit = 10;
            Item.rare = 6;
            Item.width = 48;
            Item.height = 72;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 1;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 20f;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 5, 0, 0);
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<LamentWaveProjectile>();
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