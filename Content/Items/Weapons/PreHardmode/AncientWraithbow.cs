using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class AncientWraithbow : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ancient Wraithbow");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 25;
            Item.crit = 8;
            Item.rare = 2;
            Item.width = 30;
            Item.height = 64;
            Item.useAnimation = 24;
            Item.useTime = 24;
            Item.useStyle = 5;
            Item.knockBack = 2.5f;
            Item.shootSpeed = 12f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 1, 50, 0);
            Item.UseSound = SoundID.Item5;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Arrow;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 30);
            recipe.AddIngredient(ItemID.Cobweb, 14);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}