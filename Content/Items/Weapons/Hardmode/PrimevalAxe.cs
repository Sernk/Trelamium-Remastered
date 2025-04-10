using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.Hardmode
{
    public class PrimevalAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Primeval Axe");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 24;
            Item.crit = 4;
            Item.rare = 3;
            Item.width = 34;
            Item.height = 34;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 1;
            Item.axe = 55;
            Item.knockBack = 5f;
            Item.DamageType = DamageClass.Melee;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 2, 50, 0);
            Item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PrimevalClaw>(), 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}