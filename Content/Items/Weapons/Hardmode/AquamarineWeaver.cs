using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Tiles.Stations;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class AquamarineWeaver : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Aquamarine Weaver");
            // Tooltip.SetDefault("Fires homing water typhoons");
        }

        public override void SetDefaults()
        {
            Item.damage = 38;
            Item.crit = 10;
            Item.rare = 6;
            Item.width = 42;
            Item.height = 42;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 1;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 16f;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.value = Terraria.Item.buyPrice(0, 10, 0, 0);
            Item.UseSound = SoundID.Item1;
            Item.shoot = ProjectileID.Typhoon;
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