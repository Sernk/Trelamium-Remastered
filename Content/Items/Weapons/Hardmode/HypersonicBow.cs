using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class HypersonicBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Hypersonic Pulsebow");
            // Tooltip.SetDefault("Fires arrows at high velocity");
        }

        public override void SetDefaults()
        {
            Item.damage = 60;
            Item.rare = 7;
            Item.width = 26;
            Item.height = 56;
            Item.useAnimation = 16;
            Item.useTime = 16;
            Item.useStyle = 5;
            Item.shootSpeed = 35f;
            Item.knockBack = 5f;
            Item.DamageType = DamageClass.Ranged;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.value = Terraria.Item.buyPrice(0, 12, 0, 0);
            Item.UseSound = SoundID.Item5;
            Item.shoot = 10;
            Item.useAmmo = AmmoID.Arrow;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<NanoPrism>(), 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}