using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class PrimordialClaymore : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Primordial Claymore");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.crit = 4;
            Item.rare = 1;
            Item.width = 48;
            Item.height = 48;
            Item.useAnimation = 22;
            Item.useTime = 22;
            Item.useStyle = 1;
            Item.knockBack = 4.5f;
            Item.DamageType = DamageClass.Melee;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 0, 35, 0);
            Item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PrimevalBar>(), 10);
            recipe.AddIngredient(ItemID.AntlionMandible, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}