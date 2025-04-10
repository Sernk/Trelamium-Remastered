using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class ErodedMallet : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Eroded Mallet");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.crit = 4;
            Item.rare = 1;
            Item.width = 36;
            Item.height = 36;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.useStyle = 1;
            Item.hammer = 50;
            Item.knockBack = 6.5f;
            Item.DamageType = DamageClass.Melee;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 0, 55, 0);
            Item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RustyCog>(), 14);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}