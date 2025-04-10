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
    public class Galathrower : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Galathrower");
            // Tooltip.SetDefault("Sprays a long range of cosmic stardust");
        }
        public override void SetDefaults()
        {
            Item.damage = 95;
            Item.crit = 4;
            Item.rare = 9;
            Item.width = 56;
            Item.height = 22;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.useStyle = 5;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 10f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 7, 50, 0);
            Item.UseSound = SoundID.Item34;
            Item.shoot = ModContent.ProjectileType<GalathrowerProjectile>();
            Item.useAmmo = AmmoID.Gel;
        }
       public override void AddRecipes()
       {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<GalaticCore>(), 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
       }
    }
}