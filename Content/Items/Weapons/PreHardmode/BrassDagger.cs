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
    public class BrassDagger : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Brass Dagger");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.crit = 4;
            Item.rare = 3;
            Item.width = 14;
            Item.height = 38;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 1;
            Item.knockBack = 1.5f;
            Item.maxStack = 999;
            Item.shootSpeed = 18f;
            Item.DamageType = DamageClass.Throwing;
            Item.noMelee = true;
            Item.consumable = true;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.value = Terraria.Item.buyPrice(0, 0, 0, 80);
            Item.shoot = ModContent.ProjectileType<BrassDaggerProjectile>();
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(75);
            recipe.AddIngredient(ModContent.ItemType<BrassChunk>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}