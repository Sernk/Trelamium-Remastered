using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Items.Weapons.PreHardmode;
using TrelamiumRemastered.Content.Projectiles.Dusts;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class CreationClaymore : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Creation Claymore");
            // Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.crit = 10;
            Item.rare = 5;
            Item.width = 64;
            Item.height = 64;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 1;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 22f;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.value = Terraria.Item.buyPrice(0, 30, 0, 0);
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<GenasisBoltProjectile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<StormGenasis>());
            recipe.AddIngredient(ItemID.BrokenHeroSword);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}