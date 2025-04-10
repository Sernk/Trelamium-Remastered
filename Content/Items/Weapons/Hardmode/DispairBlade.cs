using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Dusts;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class DispairBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Despair Blade");
            // Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.crit = 10;
            Item.rare = 4;
            Item.width = 42;
            Item.height = 42;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.knockBack = 5.5f;
            Item.shootSpeed = 16f;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 5, 50, 0);
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<DispairBoltProjectile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<NecromanticRemnant>(), 16);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}