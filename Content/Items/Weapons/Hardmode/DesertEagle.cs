using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class DesertEagle : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Desert Eagle");
            // Tooltip.SetDefault("Fires bullets in a double burst");
        }

        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.rare = 3;
            Item.width = 38;
            Item.height = 20;
            Item.useAnimation = 14;
            Item.useTime = 14;
            Item.useStyle = 5;
            Item.reuseDelay = 8;
            Item.shootSpeed = 18f;
            Item.knockBack = 3.5f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 10, 0, 0);
            Item.UseSound = SoundID.Item40;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Bullet;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PrimevalClaw>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}