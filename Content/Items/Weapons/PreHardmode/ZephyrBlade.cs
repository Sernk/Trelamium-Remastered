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
    public class ZephyrBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Zephyr Blade");
            // Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.damage = 28;
            Item.crit = 4;
            Item.rare = 2;
            Item.width = 54;
            Item.height = 54;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 1;
            Item.knockBack = 7.5f;
            Item.shootSpeed = 10f;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.DamageType = DamageClass.Melee;
            Item.value = Terraria.Item.buyPrice(0, 8, 50, 0);
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<ZephyrFeatherProjectile>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Feather, 10);
            recipe.AddIngredient(ItemID.GoldBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.Feather, 10);
            recipe1.AddIngredient(ItemID.PlatinumBar, 5);
            recipe1.AddTile(TileID.Anvils);
            recipe1.Register();
        }
    }
}