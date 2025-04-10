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
    public class AvianEiserne : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Avian Eiserne");
            //Tooltip.SetDefault("'Holds the soul of the misguided angel...'"
            //    + "\nLeaves fragments of metal in enemies on contact");
        }
        public override void SetDefaults()
        {
            Item.damage = 28;
            Item.crit = 4;
            Item.rare = 2;
            Item.width = 78;
            Item.height = 74;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 1;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 18f;
            Item.DamageType = DamageClass.Throwing;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.value = Terraria.Item.buyPrice(0, 10, 75, 0);
            Item.shoot = ModContent.ProjectileType<AvianEiserneProjectile>();
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AerialEssence>(), 8);
            recipe.AddIngredient(ItemID.Feather, 9);
            recipe.AddIngredient(ItemID.FallenStar, 4);
            recipe.AddTile(TileID.SkyMill);
            recipe.Register();
        }
    }
}