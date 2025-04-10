using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class AmbersteelPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ambersteel Pickaxe");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 18;
            Item.crit = 4;
            Item.rare = 3;
            Item.width = 36;
            Item.height = 36;
            Item.useAnimation = 14;
            Item.useTime = 14;
            Item.useStyle = 1;
            Item.pick = 60;
            Item.knockBack = 2.5f;
            Item.DamageType = DamageClass.Melee;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 2, 50, 0);
            Item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AmbersteelAlloy>(), 16);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}