using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class AlluviumPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Alluvium Pickaxe");
            // Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.damage = 22;
            Item.crit = 4;
            Item.rare = 5;
            Item.width = 40;
            Item.height = 40;
            Item.useAnimation = 14;
            Item.useTime = 14;
            Item.useStyle = 1;
            Item.pick = 95;
            Item.knockBack = 3.5f;
            Item.autoReuse = true;
            Item.DamageType = DamageClass.Melee;
            Item.useTurn = true;
            Item.value = Terraria.Item.buyPrice(0, 2, 50, 0);
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AlluviumBar>(), 14);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}