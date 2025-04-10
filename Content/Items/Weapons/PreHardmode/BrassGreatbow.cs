using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class BrassGreatbow : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Brass Greatbow");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.crit = 8;
            Item.rare = 1;
            Item.width = 26;
            Item.height = 54;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 5;
            Item.knockBack = 2.5f;
            Item.shootSpeed = 12f;
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 3, 50, 0);
            Item.UseSound = SoundID.Item5;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Arrow;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BrassChunk>(), 16);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}