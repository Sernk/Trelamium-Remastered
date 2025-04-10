using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class SeraphimShot : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Seraphim Shot");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 18;
            Item.crit = 4;
            Item.rare = 2;
            Item.width = 22;
            Item.height = 54;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 5;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 18f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 2, 50, 0);
            Item.UseSound = SoundID.Item11;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Bullet;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AncientFossil>(), 10);
            recipe.AddIngredient(ItemID.FlareGun);
            recipe.AddIngredient(ItemID.Amber, 5);
            recipe.AddIngredient(ItemID.Sapphire, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}