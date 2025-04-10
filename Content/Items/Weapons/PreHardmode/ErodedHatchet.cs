using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class ErodedHatchet : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Eroded Hatchet");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.crit = 4;
            Item.rare = 1;
            Item.width = 36;
            Item.height = 32;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 1;
            Item.axe = 15;
            Item.knockBack = 4.5f;
            Item.DamageType = DamageClass.Melee;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 0, 55, 0);
            Item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RustyCog>(), 16);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}