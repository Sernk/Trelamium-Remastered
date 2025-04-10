using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Tiles.Stations;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class MarinaPulsar : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Marina Pulsar");
            // Tooltip.SetDefault("transforms arrows into typhoons");
        }
        public override void SetDefaults()
        {
            Item.damage = 38;
            Item.crit = 4;
            Item.rare = 4;
            Item.width = 22;
            Item.height = 54;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 5;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 18f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 8, 50, 0);
            Item.UseSound = SoundID.Item5;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Arrow;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            type = ProjectileID.Typhoon;
            return true;
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