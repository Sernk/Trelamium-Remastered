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
    public class TinKunai : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Tin Kunai");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.crit = 4;
            Item.rare = 0;
            Item.width = 20;
            Item.height = 64;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 1;
            Item.knockBack = 1.75f;
            Item.maxStack = 999;
            Item.shootSpeed = 8f;
            Item.DamageType = DamageClass.Throwing;
            Item.noMelee = true;
            Item.consumable = true;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.value = Terraria.Item.buyPrice(0, 0, 0, 35);
            Item.shoot = ModContent.ProjectileType<TinKunaiProjectile>();
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(30);
            recipe.AddIngredient(ItemID.TinBar, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}