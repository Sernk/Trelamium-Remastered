using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class Gelatin : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Gelatin");
            // Tooltip.SetDefault("");
            ItemID.Sets.Yoyo[Item.type] = true;
            ItemID.Sets.GamepadExtraRange[Item.type] = 8;
            ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.crit = 4;
            Item.rare = 1;
            Item.width = 30;
            Item.height = 26;
            Item.useAnimation = 16;
            Item.useTime = 16;
            Item.useStyle = 1;
            Item.knockBack = 2.5f;
            Item.shootSpeed = 10f;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.value = Terraria.Item.buyPrice(0, 1, 80, 0);
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<GelatinProjectile>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Gel, 15);
            recipe.AddIngredient(ItemID.WoodYoyo);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}