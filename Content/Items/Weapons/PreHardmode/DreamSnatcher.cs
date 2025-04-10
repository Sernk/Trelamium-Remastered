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
    public class DreamSnatcher : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Dream Snatcher");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 18;
            Item.crit = 4;
            Item.rare = 2;
            Item.width = 20;
            Item.height = 64;
            Item.useAnimation = 16;
            Item.useTime = 16;
            Item.useStyle = 1;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 14f;
            Item.DamageType = DamageClass.Throwing;
            Item.noMelee = true;
            Item.autoReuse = false;
            Item.noUseGraphic = true;
            Item.value = Terraria.Item.buyPrice(0, 5, 50, 0);
            Item.shoot = ModContent.ProjectileType<DreamSnatcherProjectile>();
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DemoniteBar, 20);
            recipe.AddIngredient(ItemID.ShadowScale, 8);
            recipe.AddIngredient(ItemID.VilePowder, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}