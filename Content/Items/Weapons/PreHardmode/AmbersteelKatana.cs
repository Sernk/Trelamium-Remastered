using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class AmbersteelKatana : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ambersteel Katana");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.crit = 10;
            Item.rare = 3;
            Item.width = 40;
            Item.height = 44;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = 1;
            Item.knockBack = 1.5f;
            Item.DamageType = DamageClass.Melee;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.value = Terraria.Item.buyPrice(0, 8, 0, 0);
            Item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AmbersteelAlloy>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}