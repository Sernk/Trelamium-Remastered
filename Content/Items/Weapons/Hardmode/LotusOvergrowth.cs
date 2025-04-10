using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrelamiumRemastered.Content.Items.DruidofBloom;
using TrelamiumRemastered.Content.Projectiles;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class LotusOvergrowth : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Lotus Overgrowth");
            // Tooltip.SetDefault("Casts a wave of overgrowth branches that chase enemies");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.damage = 70;
            Item.rare = 8;
            Item.width = 54;
            Item.height = 54;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 5;
            Item.mana = 14;
            Item.shootSpeed = 8f;
            Item.knockBack = 3.5f;
            Item.DamageType = DamageClass.Magic;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 18, 35, 0);
            Item.UseSound = SoundID.Item8;
            Item.shoot = ModContent.ProjectileType<Lotus1BranchHeadProjectile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<OvergrowthStaff>());
            recipe.AddIngredient(ModContent.ItemType<NatureEssence>(), 5);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}