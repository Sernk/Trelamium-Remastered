using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Tiles.Stations;
using TrelamiumRemastered.Content.Projectiles;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class AquamarineScythe : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Aquamarine Scythe");
            // Tooltip.SetDefault("Creates Aquatic Sickles on swing");
        }

        public override void SetDefaults()
        {
            Item.damage = 40;
            Item.crit = 10;
            Item.rare = 6;
            Item.width = 42;
            Item.height = 42;
            Item.useAnimation = 24;
            Item.useTime = 24;
            Item.useStyle = 1;
            Item.knockBack = 2.5f;
            Item.shootSpeed = 15f;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.value = Terraria.Item.buyPrice(0, 10, 0, 0);
            Item.UseSound = SoundID.Item71;
            Item.shoot = ModContent.ProjectileType<AquatineSickleProjectile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Aquamarine>(), 12);
            recipe.AddIngredient(ItemID.SoulofNight, 8);
            recipe.AddTile(ModContent.TileType<AquaticForgeTile>());
            recipe.Register();
        }
    }
}