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
    public class Trinity : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Trinity");
            // Tooltip.SetDefault("Inflicts Shadowflames on enemy hit");
        }
        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.crit = 4;
            Item.rare = 3;
            Item.width = 20;
            Item.height = 64;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 1;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 14f;
            Item.DamageType = DamageClass.Throwing;
            Item.noMelee = true;
            Item.autoReuse = false;
            Item.noUseGraphic = true;
            Item.value = Terraria.Item.buyPrice(0, 4, 50, 0);
            Item.shoot = ModContent.ProjectileType<TrinityProjectile>();
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DreamSnatcher>());
            recipe.AddIngredient(ModContent.ItemType<PurityImpailer>());
            recipe.AddIngredient(ModContent.ItemType<Flamberge>());
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ModContent.ItemType<Hemoglobin>());
            recipe1.AddIngredient(ModContent.ItemType<PurityImpailer>());
            recipe1.AddIngredient(ModContent.ItemType<Flamberge>());
            recipe1.AddTile(TileID.Anvils);
            recipe1.Register();
        }
    }
}