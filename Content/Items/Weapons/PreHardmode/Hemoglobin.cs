using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class Hemoglobin : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Hemoglobin");
            // Tooltip.SetDefault("Hitting enemies has a chance to heal you");
        }
        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.crit = 4;
            Item.rare = 2;
            Item.width = 20;
            Item.height = 64;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 1;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 12f;
            Item.DamageType = DamageClass.Throwing;
            Item.noMelee = true;
            Item.autoReuse = false;
            Item.noUseGraphic = true;
            Item.value = Terraria.Item.buyPrice(0, 3, 50, 0);
            Item.shoot = ModContent.ProjectileType<HemoglobinProjectile>();
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CrimtaneBar, 20);
            recipe.AddIngredient(ItemID.TissueSample, 8);
            recipe.AddIngredient(ItemID.ViciousPowder, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}