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
    public class BladeOfWaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Blade of Waves");
            // Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.damage = 18;
            Item.crit = 4;
            Item.rare = 2;
            Item.width = 54;
            Item.height = 54;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 1;
            Item.knockBack = 2.5f;
            Item.shootSpeed = 5f;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.value = Terraria.Item.buyPrice(0, 8, 50, 0);
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<StagnantWaveProjectile>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SeaEssence>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}