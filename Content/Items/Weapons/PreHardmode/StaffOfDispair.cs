using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Items.DruidofBloom;
using TrelamiumRemastered.Content.Projectiles.Dusts;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class StaffOfDispair : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Staff of Despair");
            // Tooltip.SetDefault("Casts a live-stealing beam");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.damage = 28;
            Item.rare = 3;
            Item.width = 54;
            Item.height = 54;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 5;
            Item.mana = 12;
            Item.shootSpeed = 8f;
            Item.knockBack = 3.5f;
            Item.DamageType = DamageClass.Magic;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 2, 50, 0);
            Item.UseSound = SoundID.Item8;
            Item.shoot = ModContent.ProjectileType<DispairBeamProjectile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Obsidian, 16);
            recipe.AddIngredient(ModContent.ItemType<OvergrowthStaff>());
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}