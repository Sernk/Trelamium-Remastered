using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class GalaticKunai : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Galatic Kunai");
            /* Tooltip.SetDefault("Bounces on tiles"
                + "\nCreates spacial energy on contact of enemies and tiles"); */
        }

        public override void SetDefaults()
        {
            Item.damage = 60;
            Item.crit = 4;
            Item.rare = 9;
            Item.width = 54;
            Item.height = 56;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.knockBack = 3.5f;
            Item.shootSpeed = 28f;
            Item.DamageType = DamageClass.Throwing;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.useTurn = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 20, 0, 0);
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<GalaticDaggerProjectile>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<GalaticCore>(), 18);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}