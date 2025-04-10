using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class PrimefuryBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Primefury Blade");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 65;
            Item.crit = 4;
            Item.rare = 8;
            Item.width = 56;
            Item.height = 56;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 1;
            Item.knockBack = 5f;
            Item.shootSpeed = 14f;
            Item.DamageType = DamageClass.Melee;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 8, 50, 0);
            Item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PrimefuryShard>(), 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}