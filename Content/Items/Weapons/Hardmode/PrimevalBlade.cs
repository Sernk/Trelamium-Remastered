using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class PrimevalBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Primeval Blade");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 40;
            Item.crit = 4;
            Item.rare = 5;
            Item.width = 56;
            Item.height = 56;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.useStyle = 1;
            Item.knockBack = 8f;
            Item.shootSpeed = 15f;
            Item.DamageType = DamageClass.Melee;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 4, 50, 0);
            Item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PrimevalClaw>(), 16);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}