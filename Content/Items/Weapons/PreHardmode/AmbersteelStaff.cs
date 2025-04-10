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
    public class AmbersteelStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ambersteel Staff");
            // Tooltip.SetDefault("");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.damage = 24;
            Item.rare = 3;
            Item.width = 50;
            Item.height = 50;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 5;
            Item.mana = 8;
            Item.shootSpeed = 14.5f;
            Item.knockBack = 4f;
            Item.DamageType = DamageClass.Magic;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 8, 0, 0);
            Item.UseSound = SoundID.Item8;
            Item.shoot = ModContent.ProjectileType<AmbersteelBoltProjectile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AmbersteelAlloy>(), 14);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}