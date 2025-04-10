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
    public class TungstenKunai : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Tungsten Kunai");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.crit = 4;
            Item.rare = 1;
            Item.width = 20;
            Item.height = 64;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 1;
            Item.knockBack = 2.5f;
            Item.maxStack = 999;
            Item.shootSpeed = 9.5f;
            Item.DamageType = DamageClass.Throwing;
            Item.noMelee = true;
            Item.consumable = true;
            Item.autoReuse = false;
            Item.noUseGraphic = true;
            Item.value = Terraria.Item.buyPrice(0, 0, 0, 45);
            Item.shoot = ModContent.ProjectileType<TungstenKunaiProjectile>();
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(30);
            recipe.AddIngredient(ItemID.TungstenBar, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}