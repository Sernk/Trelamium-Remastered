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
    public class Aspire : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Aspire");
            //Tooltip.SetDefault("Fires a short-ranged beam that heals you");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.rare = 2;
            Item.width = 48;
            Item.height = 48;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 5;
            Item.mana = 12;
            Item.shootSpeed = 12f;
            Item.knockBack = 3.5f;
            Item.DamageType = DamageClass.Magic;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 5, 30, 0);
            Item.UseSound = SoundID.Item8;
            Item.shoot = ModContent.ProjectileType<AspireBeamProjectile>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GoldBar, 10);
            recipe.AddIngredient(ItemID.Ruby, 8);
            recipe.AddIngredient(ItemID.LifeCrystal, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.PlatinumBar, 10);
            recipe1.AddIngredient(ItemID.Ruby, 8);
            recipe1.AddIngredient(ItemID.LifeCrystal, 2);
            recipe1.AddTile(TileID.Anvils);
            recipe1.Register();
        }
    }
}