using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class HypersonicBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Hypersonic Blade");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 85;
            Item.crit = 12;
            Item.rare = 7;
            Item.width = 56;
            Item.height = 56;
            Item.useAnimation = 16;
            Item.useTime = 16;
            Item.useStyle = 1;
            Item.knockBack = 4.5f;
            Item.shootSpeed = 16f;
            Item.DamageType = DamageClass.Melee;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 10, 0, 0);
            Item.UseSound = SoundID.Item1;
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