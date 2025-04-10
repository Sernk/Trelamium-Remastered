using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class ObsidianScimitar : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Obsidian Scimitar");
            // Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.crit = 4;
            Item.rare = 1;
            Item.width = 44;
            Item.height = 46;
            Item.useAnimation = 23;
            Item.useTime = 23;
            Item.useStyle = 1;
            Item.knockBack = 6.5f;
            Item.shootSpeed = 10f;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.value = Terraria.Item.buyPrice(0, 2, 50, 0);
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Obsidian, 18);
            recipe.AddIngredient(ItemID.Silk, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}