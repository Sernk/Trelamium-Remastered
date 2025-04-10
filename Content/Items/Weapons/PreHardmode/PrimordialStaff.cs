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
    public class PrimordialStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Primordial Staff");
            // Tooltip.SetDefault("");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.rare = 1;
            Item.width = 54;
            Item.height = 54;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 5;
            Item.mana = 4;
            Item.shootSpeed = 8f;
            Item.knockBack = 3.5f;
            Item.DamageType = DamageClass.Magic;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 0, 35, 0);
            Item.UseSound = SoundID.Item8;
            Item.shoot = ModContent.ProjectileType<PrimordialStaffProjectile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PrimevalBar>(), 10);
            recipe.AddIngredient(ItemID.AntlionMandible, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}