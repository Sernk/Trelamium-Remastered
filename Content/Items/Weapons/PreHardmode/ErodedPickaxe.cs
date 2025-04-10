using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class ErodedPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Eroded Pickaxe");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.crit = 4;
            Item.rare = 1;
            Item.width = 30;
            Item.height = 30;
            Item.useAnimation = 19;
            Item.useTime = 19;
            Item.useStyle = 1;
            Item.pick = 50;
            Item.knockBack = 1.5f;
            Item.DamageType = DamageClass.Melee;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 0, 55, 0);
            Item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RustyCog>(), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}