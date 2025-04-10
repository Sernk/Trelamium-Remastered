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
    public class Flamberge : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("The Flamberge");
            // Tooltip.SetDefault("Combusts into hellfire on enemy contact");
        }
        public override void SetDefaults()
        {
            Item.damage = 22;
            Item.crit = 4;
            Item.rare = 3;
            Item.width = 20;
            Item.height = 64;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 1;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 12f;
            Item.DamageType = DamageClass.Throwing;
            Item.noMelee = true;
            Item.autoReuse = false;
            Item.noUseGraphic = true;
            Item.value = Terraria.Item.buyPrice(0, 5, 75, 0);
            Item.shoot = ModContent.ProjectileType<FlambergeProjectile>();
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HellstoneBar, 18);
            recipe.AddIngredient(ItemID.Obsidian, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}