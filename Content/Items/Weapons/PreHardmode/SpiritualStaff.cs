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
    public class SpiritualStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Spiritual Staff");
            // Tooltip.SetDefault("Creates a pillar of spiritual energy");
        }
        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.rare = 5;
            Item.width = 54;
            Item.height = 54;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 1;
            Item.mana = 8;
            Item.shootSpeed = 0.001f;
            Item.knockBack = 3.5f;
            Item.DamageType = DamageClass.Magic;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 2, 50, 0);
            Item.UseSound = SoundID.Item8;
            Item.shoot = ModContent.ProjectileType<SpiritualEnergyProjectile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AlluviumBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}