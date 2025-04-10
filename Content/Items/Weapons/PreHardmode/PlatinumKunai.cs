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
    public class PlatinumKunai : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Platinum Kunai");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 18;
            Item.crit = 4;
            Item.rare = 2;
            Item.width = 20;
            Item.height = 64;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 1;
            Item.knockBack = 3.5f;
            Item.maxStack = 999;
            Item.shootSpeed = 12.5f;
            Item.DamageType = DamageClass.Throwing;
            Item.noMelee = true;
            Item.consumable = true;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.value = Terraria.Item.buyPrice(0, 0, 0, 55);
            Item.shoot = ModContent.ProjectileType<PlatinumKunaiProjectile>();
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(30);
            recipe.AddIngredient(ItemID.PlatinumBar, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}