using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Items.Symphony;
using TrelamiumRemastered.Content.Projectiles;
using TrelamiumRemastered.Content.Tiles.Stations;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class AquaticScourge : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Aquatic Scourge");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 80;
            Item.crit = 4;
            Item.rare = 6;
            Item.width = 56;
            Item.height = 56;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.useStyle = 1;
            Item.knockBack = 8f;
            Item.shootSpeed = 15f;
            Item.DamageType = DamageClass.Melee;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 18, 50, 0);
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<AquaticScourgeProjectile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<TideOfTheGods>());
            recipe.AddIngredient(ItemID.BrokenHeroSword);
            recipe.AddIngredient(ModContent.ItemType<Aquamarine>(), 4);
            recipe.AddIngredient(ItemID.SoulofLight, 8);
            recipe.AddTile(ModContent.TileType<AquaticForgeTile>());
            recipe.Register();
        }
    }
}