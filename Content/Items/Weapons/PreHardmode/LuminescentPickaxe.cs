using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class LuminescentPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Luminescent Pickaxe");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.crit = 4;
            Item.rare = 1;
            Item.width = 44;
            Item.height = 44;
            Item.useAnimation = 18;
            Item.useTime = 18;
            Item.useStyle = 1;
            Item.pick = 55;
            Item.knockBack = 2f;
            Item.DamageType = DamageClass.Melee;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 1, 25, 0);
            Item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<LuminescentGeode>(), 14);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}