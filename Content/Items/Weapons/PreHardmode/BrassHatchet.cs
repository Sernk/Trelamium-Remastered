using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrelamiumRemastered.Content.Items.Weapons.PreHardmode
{
    public class BrassHatchet : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Brass Hatchet");
            // Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.crit = 4;
            Item.rare = 3;
            Item.width = 48;
            Item.height = 48;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.useStyle = 1;
            Item.hammer = 80;
            Item.axe = 20;
            Item.knockBack = 5.5f;
            Item.autoReuse = true;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.useTurn = true;
            Item.value = Terraria.Item.buyPrice(0, 2, 50, 0);
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BrassChunk>(), 14);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}