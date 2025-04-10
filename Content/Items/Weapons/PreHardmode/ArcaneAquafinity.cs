using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Projectiles.Dusts;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class ArcaneAquafinity : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Arcane Aquafinity");
            // Tooltip.SetDefault("");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.damage = 22;
            Item.rare = 2;
            Item.width = 32;
            Item.height = 32;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 5;
            Item.mana = 5;
            Item.shootSpeed = 8f;
            Item.knockBack = 1.5f;
            Item.DamageType = DamageClass.Magic;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 2, 50, 0);
            Item.UseSound = SoundID.Item8;
            Item.shoot = ModContent.ProjectileType<ArcaneAquafinityProjectile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Aquamarine>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}