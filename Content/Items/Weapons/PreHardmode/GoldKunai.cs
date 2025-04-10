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
    public class GoldKunai : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Gold Kunai");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 18;
            Item.crit = 4;
            Item.rare = 1;
            Item.width = 20;
            Item.height = 64;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 1;
            Item.knockBack = 2.5f;
            Item.maxStack = 999;
            Item.shootSpeed = 10.5f;
            Item.DamageType = DamageClass.Throwing;
            Item.noMelee = true;
            Item.consumable = true;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.value = Terraria.Item.buyPrice(0, 0, 0, 50);
            Item.shoot = ModContent.ProjectileType<GoldKunaiProjectile>();
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(30);
            recipe.AddIngredient(ItemID.GoldBar, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}