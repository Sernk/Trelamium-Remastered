using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class AerialStriker : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Aerial Striker");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.crit = 4;
            Item.rare = 3;
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
            Item.value = Terraria.Item.buyPrice(0, 6, 0, 0);
            Item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AerialEssence>(), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}