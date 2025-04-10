using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class TideBreaker : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Tide Breaker");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.crit = 4;
            Item.rare = 4;
            Item.width = 70;
            Item.height = 28;
            Item.useAnimation = 6;
            Item.useTime = 6;
            Item.useStyle = 5;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 16f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 7, 50, 0);
            Item.UseSound = SoundID.Item99;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Bullet;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Megashark);
            recipe.AddIngredient(ItemID.SoulofFright, 10);
            recipe.AddIngredient(ModContent.ItemType<SeaEssence>(), 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}